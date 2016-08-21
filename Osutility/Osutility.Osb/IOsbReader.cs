﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osutility.Osb
{
  public interface IOsbReader : IDisposable
  {
    IList<OsbInfo> ReadAll();
  }
}
