using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;

namespace OsuService.LocalService
{
    public class FileCore
    {
        /// <summary>
        /// 选择文件对话框（单选）
        /// </summary>
        /// <param name="path">默认定位到的目录</param>
        /// <returns>文件的地址</returns>
        public string GetFilePathFromDialog(string path)
        {
            string fileName1 = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName1 = ofd.FileName;
            }

            return fileName1;
        }

        /// <summary>
        /// 选择文件对话框（多选）
        /// </summary>
        /// <param name="path">默认定位到的目录</param>
        /// <returns>文件的地址</returns>
        public string[] GetAnyFilePathFromDialog(string path)
        {
            string[] fileNames1 = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileNames1 = ofd.FileNames;
            }

            return fileNames1;
        }


        /// <summary>
        /// 浏览目录对话框
        /// </summary>       
        public string GetDirPathFromDialog(string path)
        {
            string p = path;  //默认路径
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择文件夹";
            fbd.SelectedPath = p;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                p = fbd.SelectedPath;  //获取选择的路径
            }
            return p;
        }

        /// <summary>
        /// 修改文件的扩展名
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="NewExtension">新的扩展名</param>
        /// <returns>是否成功执行</returns>
        public bool ChangeFileExtension(string filePath, string NewExtension)
        {
            bool b = false;

            if (!(("." + NewExtension) == Path.GetExtension(filePath)))  //要修改扩展名的文件与修改扩展名一致，就退出
            {
                try  //尝试运行
                {
                    FileInfo f = new FileInfo(filePath);
                    string newName = Path.ChangeExtension(f.FullName, NewExtension);   //修改扩展名后的文件名
                    if (File.Exists(newName))
                        File.Delete(newName);
                    f.MoveTo(newName);  //重命名文件
                    b = true;
                }
                catch { } //忽略抛出异常                         
            }
            return b;
        }
    }
}
