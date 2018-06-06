using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public class Messager
    {
        /// <summary>
        /// Displays styled MessageBox with Title, Message and a button
        /// </summary>
        /// <param name="Title">The title to show</param>
        /// <param name="Message">The message to show</param>
        public static void Show(string Title, string Message)
        {
            Message message = new Message(Title,Message);
            message.ShowDialog();
        }
       /// <summary>
       /// Displays the file details in a messagebox
       /// </summary>
       /// <param name="file"></param>
        public static void ShowFile(Class.File file)
        {
            string title="";
            string messageString = "";
            if (file.isText)
            {
                title = "Text message from "+file.FromUser.Name;
                messageString = "You got a text message from "+file.FromUser.Email+" on "+file.Datetime.ToString("dd/MM/yy HH:mm")+"\nThe message is:\n\n"+file.Data;
            }
            else
            {
                title = "File from " + file.FromUser.Name;
                messageString = "You got a file from " + file.FromUser.Email + " on " + file.Datetime.ToString("dd/MM/yy HH:mm") + "\n Download the file here is:\n\n" + file.Data;

            }
            Message message = new Message(title, messageString, 300,450);
            message.ShowDialog();
        }
    }
}
