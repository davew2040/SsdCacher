using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code.Logger
{
    public class NullLogger : ILogger
    {
        public void WriteLine(string message)
        {
        }
    }
}
