using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlers
{
    public class FileBrowser
    {
        #region Constants
        private const int bytesInMB = 1048576;
        private const string patternForDirectories = "*";
        private const string patternForFiles = "*.*";
        #endregion

        #region Methods
        public static FilesData ReturnData(string path)
        {
            FilesData dataInfo = new FilesData();

            dataInfo.oldPath = GetOldPath(path);
            dataInfo.directoryNames = SafeFileEnumerator.EnumerateDirectories(path, patternForDirectories, SearchOption.TopDirectoryOnly);
            dataInfo.fileNames = SafeFileEnumerator.EnumerateFiles(path, patternForFiles, SearchOption.TopDirectoryOnly);
            IEnumerable<string> fileNames = SafeFileEnumerator.EnumerateFiles(path, patternForFiles, SearchOption.AllDirectories);
            
            //calculating the numbers of files in groups
            FileInfo info = null;
            if (fileNames != null)
            {
                foreach (string name in fileNames)
                {
                    info = new FileInfo(name);
                    var sizeOfFile = info.Length / bytesInMB;
                    if (sizeOfFile <= 10) dataInfo.numberOfSmallGroup++;
                    else if (sizeOfFile > 10 && sizeOfFile <= 50) dataInfo.numberOfMiddleGroup++;
                    else dataInfo.numberOfLargeGroup++;
                }
            }
            return dataInfo;
        }
        public static string[] GetFixedDrives()
        {
            List<string> driveNames = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            if (drives != null)
            {
                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Fixed)
                    {
                        driveNames.Add(drive.Name);
                    }
                }
            }
            return driveNames.ToArray();
        }
        private static string GetOldPath(string path)
        {
            if (path.EndsWith(@"\"))
            {
                path = path.Remove((path.Length - 1));
            }
            return Path.GetDirectoryName(path);
        }
        #endregion
    }
}
