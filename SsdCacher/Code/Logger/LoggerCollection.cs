using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code.Logger
{
    public class LoggerCollection : ILogger
    {
        List<ILogger> loggers;

        public LoggerCollection(params ILogger[] loggers)
        {
            this.loggers = loggers.ToList();
        }

        public void WriteLine(string message)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.WriteLine(message);
            }
        }
    }
}
