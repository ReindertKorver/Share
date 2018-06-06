using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Class
{
    public class File
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public DateTime Datetime { get; set; }
        public bool isText { get; set; }
        public string EmailToUser { get; set; }
        public User FromUser { get; set; }
        public string FileString { get {
                string FilesAsString="";
                try
                {
                    if (Data.Length <= 20)
                    {
                        FilesAsString = Data + " " + (Datetime.ToString("hh:mm") ?? "");
                    }
                    else
                    {
                        FilesAsString = Data.Substring(0, 20) + "..." + " " + (Datetime.ToString("HH:mm") ?? "");
                    }
                }
                catch (Exception ex) {

                }
                return FilesAsString;
            } }
    }
}
