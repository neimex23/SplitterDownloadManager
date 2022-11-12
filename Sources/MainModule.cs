using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SplitterDownloadManager
{
    public class MainModule
    {
        private DriveModule drive = new DriveModule();

        public void Init()
        {
            Thread.Sleep(100);
            drive.GetService();
        }
    }
}
