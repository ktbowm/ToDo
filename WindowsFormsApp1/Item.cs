using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Item
    {
        //class variables
        //+created DateTime? +importance ranking (use enum)?
        private int itemId;
        private string itemText;
        private string itemDetails;
        private bool itemIsComplete;
        private DateTime itemDueDate;

        //getters and setters (encapsulates variables)
        public int ItemId { get => itemId; set => itemId = value; }
        public string ItemText { get => itemText; set => itemText = value; }
        public string ItemDetails { get => itemDetails; set => itemDetails = value; }
        public bool ItemIsComplete { get => itemIsComplete; set => itemIsComplete = value; }
        public DateTime ItemDueDate { get => itemDueDate; set => itemDueDate = value; }

        //paramaterized constructor
        public Item(int itemId, string itemText, string itemDetails, bool itemIsComplete, DateTime itemDueDate)
        {
            ItemId = itemId;
            ItemText = itemText;
            ItemDetails = itemDetails;
            ItemIsComplete = itemIsComplete;
            ItemDueDate = itemDueDate;
        }

        //default constructor
        public Item()
        {
            ItemId = 0; //change to make sure id will be unique
            ItemText = "Default Item Text";
            ItemDetails = "Default Item Details";
            ItemIsComplete = false;
            ItemDueDate = DateTime.Now.AddDays(1); //change to another time? (default is tomorrow)
        }

        //copy constructor
        public Item(Item item)
        {
            ItemId = item.itemId; //don't want same id even if it's a copy
            ItemText = item.itemText;
            ItemDetails = item.itemDetails;
            ItemIsComplete = item.itemIsComplete;
            ItemDueDate = item.itemDueDate;
        }

    }
}
