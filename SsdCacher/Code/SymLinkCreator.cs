using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code
{
    public class SymLinkCreator
    {
        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        enum SymbolicLink
        {
            File = 0,
            Directory = 1
        }

        public static void CreateSymbolicDirectoryLink(string path, string source)
        {
            CreateSymbolicLink(path, source, SymbolicLink.Directory);
        }
    }
}
