using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlers
{
    public class FilesData
    {
        public IEnumerable<string> directoryNames { get; set; }
        public IEnumerable<string> fileNames { get; set; }
        public int numberOfSmallGroup { get; set; }
        public int numberOfMiddleGroup { get; set; }
        public int numberOfLargeGroup { get; set; }
        public string oldPath { get; set; }
    }
}
