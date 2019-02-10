using System;
using System.Collections;
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
        private List<Tag> itemTags; //change tags to List type (or other)?

        //getters and setters (encapsulates variables)
        public int ItemId { get => itemId; set => itemId = value; }
        public string ItemText { get => itemText; set => itemText = value; }
        public string ItemDetails { get => itemDetails; set => itemDetails = value; }
        public bool ItemIsComplete { get => itemIsComplete; set => itemIsComplete = value; }
        public DateTime ItemDueDate { get => itemDueDate; set => itemDueDate = value; }
        public List<Tag> ItemTags { get => itemTags; set => itemTags = value; }

        //paramaterized constructor
        public Item(int itemId, string itemText, string itemDetails, bool itemIsComplete, DateTime itemDueDate, List<Tag> itemTags)
        {
            ItemId = itemId;
            ItemText = itemText;
            ItemDetails = itemDetails;
            ItemIsComplete = itemIsComplete;
            ItemDueDate = itemDueDate;
            ItemTags = itemTags;
        }

        //default constructor
        public Item()
        {
            ItemId = 0; //change to make sure id will be unique
            ItemText = "Item Text";
            ItemDetails = "Item Details";
            ItemIsComplete = false;
            ItemDueDate = DateTime.Now.AddDays(1); //change to another time? (default is tomorrow)
            ItemTags = new List<Tag>();
        }

        //copy constructor
        public Item(Item item)
        {
            ItemId = item.itemId; //don't want same id even if it's a copy
            ItemText = item.itemText;
            ItemDetails = item.itemDetails;
            ItemIsComplete = item.itemIsComplete;
            ItemDueDate = item.itemDueDate;
            ItemTags = item.itemTags;
        }

        //class functions (move some/all of these to tag class?)
        public void AddTagToItem(Tag tag)
        {
            if(ItemTags.Contains(tag))
            {
                Console.WriteLine("Item already has this tag");
            } else
            {
                ItemTags.Add(tag);
            }
        }

        public void RemoveTagFromItem(Tag tag)
        {
            if (ItemTags.Contains(tag))
            {
                ItemTags.Remove(tag);
                
            }
            else
            {
                Console.WriteLine("Item does not have this tag.");
            } 
        }

        public void ListAllItemTagNames()
        {
            if (ItemTags.Count > 0) {
                foreach (Tag item in ItemTags)
                {
                    Console.WriteLine(item.TagName);
                }
            } else
            {
                Console.WriteLine("This item has no tags.");
            }
            
        }

        public void ListAllItemTagValues()
        {
            if (ItemTags.Count > 0)
            {
                foreach (Tag item in ItemTags)
                {
                    Console.WriteLine("Tag Id: {0}, Tag Name: {1}, Tag Details: {2}", item.TagId, item.TagName, item.TagDetails);
                }
            } else
            {
                Console.WriteLine("This item has no tags.");
            }    
        }
    }
}
