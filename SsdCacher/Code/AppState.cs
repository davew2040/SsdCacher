using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SsdCacher.Code.Logger;
using SsdCacher.Code.ViewModels;
using static SsdCacher.Code.FileCopier;

namespace SsdCacher.Code
{
    public class AppState : SsdCacherViewModel
    {
        public AppState()
        {
        }
        
        public Logger.LoggerCollection AppLogger = new Logger.LoggerCollection(new SsdCacheLogger());

        private FileCountInfo activeFileCopyInfo;
        public FileCountInfo ActiveFileCopyInfo
        {
            get
            {
                if (null == activeFileCopyInfo)
                {
                    return new FileCountInfo();
                }
                return this.activeFileCopyInfo;
            }

            set
            {
                this.activeFileCopyInfo = value;
            }
        }
    }
}
