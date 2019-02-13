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
            //tags
            Tag t1 = new Tag();
            Tag t2 = new Tag(2, "daily", "occurs every day");
            Tag t3 = new Tag();
            List<Tag> tagList = new List<Tag>();
            List<Tag> tagList2 = new List<Tag>();
            tagList.Add(t1);
            tagList.Add(t2);
            tagList2.Add(t2);

            //items
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

            //item lists
            ItemList l1 = new ItemList();
            l1.AddItemToList(i1);
            l1.AddItemToList(i2);
            l1.AddItemToList(i3);
            l1.RemoveItemFromList(i1);
            LinkedList<Item> l2complete = new LinkedList<Item>();
            LinkedList<Item> l2incomplete = new LinkedList<Item>();
            l2complete.AddLast(i2);
            l2incomplete.AddLast(i1);
            ItemList l2 = new ItemList(2, "List 2", "List 2 Details", l2complete, l2incomplete);
            l2.AddItemToList(i3);

            //output data
            Console.WriteLine("Test Items Output: ");
            i1.PrintAllItemValues();
            i2.PrintAllItemValues();
            i3.PrintAllItemValues();
            Console.WriteLine();
            Console.WriteLine("Test Lists Output: ");
            l1.PrintAllItemListValues();
            l2.PrintAllItemListValues();
            //testing end

        }
    }
}
