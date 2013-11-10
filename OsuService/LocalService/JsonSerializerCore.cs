using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsuService.LocalService
{
    /// <summary>
    /// Json转换器
    /// </summary>
    public class JsonSerializerCore
    {
        public JsonSerializerCore()
        {
            this.nfi = new System.Globalization.NumberFormatInfo();
            this.nfi.NumberGroupSeparator = "";
            this.nfi.NumberDecimalSeparator = ".";
        }

        //types:
        // N = null
        // s = string
        // i = int
        // d = double
        // a = array (hashtable)

        private Dictionary<Hashtable, bool> seenHashtables; //for serialize (to infinte prevent loops)
        private Dictionary<ArrayList, bool> seenArrayLists; //for serialize (to infinte prevent loops) lol

        private int pos; //for unserialize

        public bool XMLSafe = true; //This member tells the serializer wether or not to strip carriage returns from strings when serializing and adding them back in when deserializing
        //http://www.w3.org/TR/REC-xml/#sec-line-ends

        public Encoding StringEncoding = new System.Text.UTF8Encoding();

        private System.Globalization.NumberFormatInfo nfi;
        

        public object Deserialize(string str)
        {
            this.pos = 0;
            return deserialize(str);
        }//Deserialize(string str)

        private object deserialize(string str)
        {
            if (str == null || str.Length <= this.pos)
                return new Object();

            int start, end, length;
            string stLen;
            switch (str[this.pos])
            {
                case 'N':
                    this.pos += 2;
                    return null;
                case 'b':
                    char chBool;
                    chBool = str[pos + 2];
                    this.pos += 4;
                    return chBool == '1';
                case 'i':
                    string stInt;
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(";", start);
                    stInt = str.Substring(start, end - start);
                    this.pos += 3 + stInt.Length;
                    return Int32.Parse(stInt, this.nfi);
                case 'd':
                    string stDouble;
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(";", start);
                    stDouble = str.Substring(start, end - start);
                    this.pos += 3 + stDouble.Length;
                    return Double.Parse(stDouble, this.nfi);
                case 's':
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    int bytelen = Int32.Parse(stLen);
                    length = bytelen;
                    //This is the byte length, not the character length - so we migth  
                    //need to shorten it before usage. This also implies bounds checking
                    if ((end + 2 + length) >= str.Length) length = str.Length - 2 - end;
                    string stRet = str.Substring(end + 2, length);
                    while (this.StringEncoding.GetByteCount(stRet) > bytelen)
                    {
                        length--;
                        stRet = str.Substring(end + 2, length);
                    }
                    this.pos += 6 + stLen.Length + length;
                    if (this.XMLSafe)
                    {
                        stRet = stRet.Replace("\n", "\r\n");
                    }
                    return stRet;
                case 'a':
                    //if keys are ints 0 through N, returns an ArrayList, else returns Hashtable
                    start = str.IndexOf(":", this.pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    length = Int32.Parse(stLen);
                    Hashtable htRet = new Hashtable(length);
                    ArrayList alRet = new ArrayList(length);
                    this.pos += 4 + stLen.Length; //a:Len:{
                    for (int i = 0; i < length; i++)
                    {
                        //read key
                        object key = deserialize(str);
                        //read value
                        object val = deserialize(str);

                        if (alRet != null)
                        {
                            if (key is int && (int)key == alRet.Count)
                                alRet.Add(val);
                            else
                                alRet = null;
                        }
                        htRet[key] = val;
                    }
                    this.pos++; //skip the }
                    if (this.pos < str.Length && str[this.pos] == ';')//skipping our old extra array semi-colon bug (er... php's weirdness)
                        this.pos++;
                    if (alRet != null)
                        return alRet;
                    else
                        return htRet;
                default:
                    return "";
            }//switch
        }//unserialzie(object)	
    }//class Serializer
}
