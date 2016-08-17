using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osutility.Osb
{
  interface IOsbSerializer : IDisposable
  {
    /// <summary>
   /// Gets the configuration.
   /// </summary>
    OsbConfiguration Configuration { get; }

    /// <summary>
    /// Writes a record to the CSV file.
    /// </summary>
    /// <param name="record">The record to write.</param>
    void Write(string[] record);
  }
}
