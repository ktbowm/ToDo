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
        private ItemList itemBelongsToList;
        private List<Tag> itemTags; //change tags to List type (or other)?

        //getters and setters (encapsulates variables)
        public int ItemId { get => itemId; set => itemId = value; }
        public string ItemText { get => itemText; set => itemText = value; }
        public string ItemDetails { get => itemDetails; set => itemDetails = value; }
        public bool ItemIsComplete { get => itemIsComplete; set => itemIsComplete = value; }
        public DateTime ItemDueDate { get => itemDueDate; set => itemDueDate = value; }
        internal ItemList ItemBelongsToList { get => itemBelongsToList; set => itemBelongsToList = value; }
        public List<Tag> ItemTags { get => itemTags; set => itemTags = value; }

        //paramaterized constructor
        public Item(int itemId, string itemText, string itemDetails, bool itemIsComplete, DateTime itemDueDate, List<Tag> itemTags)
        {
            ItemId = itemId;
            ItemText = itemText;
            ItemDetails = itemDetails;
            ItemIsComplete = itemIsComplete;
            ItemDueDate = itemDueDate;
            ItemBelongsToList = null;
            ItemTags = itemTags;
        }

        //default constructor
        public Item()
        {
            ItemId = 0; //change to make sure id will be unique
            ItemText = "Item Text";
            ItemDetails = "Item Details";
            ItemIsComplete = false;
            ItemDueDate = DateTime.Now.AddDays(1); //change to another time? (default is tomorrow)/let user set a default?
            ItemBelongsToList = null;
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
            ItemBelongsToList = null; //want to change this so list is the destination of the item's copy?
        }

        //class functions (move some/all of these to tag class?)
        public void CheckItem()
        {
            ItemIsComplete = !ItemIsComplete;
            ItemBelongsToList.UpdateListCompletionAfterItemCheck(this);
        }

        public void MoveItemToAnotherList(ItemList newList)
        {
            ItemBelongsToList.RemoveItemFromList(this);
            ItemBelongsToList.AddItemToList(this);
        }

        //add and remove tags
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

        //data output functions
        public void PrintAllItemValues()
        {
            Console.WriteLine("Item Id: {0}", ItemId);
            Console.WriteLine("Item Text: {0}", ItemText);
            Console.WriteLine("Item Details: {0}", ItemDetails);
            Console.WriteLine("Item Is Complete: {0}", ItemIsComplete);
            Console.WriteLine("Item Due Date: {0}", ItemDueDate);
            if(ItemBelongsToList != null)
            {
                Console.WriteLine("Item Belongs to List: {0}", ItemBelongsToList.ItemListName);
            }
            else
            {
                Console.WriteLine("This item does not belong to any list.");
            }
            PrintAllItemTagValues();
        }

        public void PrintAllItemTagNames()
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

        public void PrintAllItemTagValues()
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
