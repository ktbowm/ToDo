using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //testing begin
            Tag t1 = new Tag();
            Tag t2 = new Tag(2, "daily", "occurs every day");
            Tag t3 = new Tag();
            List<Tag> tagList = new List<Tag>();
            List<Tag> tagList2 = new List<Tag>();
            tagList.Add(t1);
            tagList.Add(t2);
            tagList2.Add(t2);

            Item i1 = new Item();
            Item i2 = new Item(2, "i2 text", "i2 details", true, DateTime.Now, tagList);
            Item i3 = new Item(i1)
            {
                ItemText = "i3 text",
                ItemDetails = "i3 details"
            };
            i3.ItemTags.Clear();
            i3.ItemTags = tagList2;
            i2.RemoveTagFromItem(t3);
            i2.RemoveTagFromItem(t2);

            i1.PrintAllItemValues();
            i2.PrintAllItemValues();
            i3.PrintAllItemValues();
            //testing end

        }
    }
}
