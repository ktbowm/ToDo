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

            Console.WriteLine("i1 id: {0}", i1.ItemId);
            Console.WriteLine("i1 text: {0}", i1.ItemText);
            Console.WriteLine("i1 details: {0}", i1.ItemDetails);
            Console.WriteLine("i1 is complete: {0}", i1.ItemIsComplete);
            Console.WriteLine("i1 due date: {0}", i1.ItemDueDate);
            Console.WriteLine("i1 tags: ");
            i1.ListAllItemTagValues();

            Console.WriteLine("i2 id: {0}", i2.ItemId);
            Console.WriteLine("i2 text: {0}", i2.ItemText);
            Console.WriteLine("i2 details: {0}", i2.ItemDetails);
            Console.WriteLine("i2 is complete: {0}", i2.ItemIsComplete);
            Console.WriteLine("i2 due date: {0}", i2.ItemDueDate);
            Console.WriteLine("i2 tags: ");
            i2.ListAllItemTagValues();

            Console.WriteLine("i3 id: {0}", i3.ItemId);
            Console.WriteLine("i3 text: {0}", i3.ItemText);
            Console.WriteLine("i3 details: {0}", i3.ItemDetails);
            Console.WriteLine("i3 is complete: {0}", i3.ItemIsComplete);
            Console.WriteLine("i3 due date: {0}", i3.ItemDueDate);
            Console.WriteLine("i3 tags: ");
            i3.ListAllItemTagValues();
            //testing end

        }
    }
}
