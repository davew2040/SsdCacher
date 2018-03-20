using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code.Logger
{
    public class SsdCacheLogger : ILogger
    {
        public void WriteLine(string message)
        {
            CacherApp.AppViewModel.OutputText += message + System.Environment.NewLine;
        }
    }
}
