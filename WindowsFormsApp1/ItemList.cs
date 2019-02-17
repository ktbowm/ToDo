using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    class ItemList
    {
        //class variables
        private int itemListId;
        private string itemListName;
        private string itemListDetails;
        private Boolean itemListIsComplete;
        private LinkedList<Item> itemListCompleteItems;
        private LinkedList<Item> itemListIncompleteItems;

        //getters and setters (encapsulates variables)
        public int ItemListId { get => itemListId; set => itemListId = value; }
        public string ItemListName { get => itemListName; set => itemListName = value; }
        public string ItemListDetails { get => itemListDetails; set => itemListDetails = value; }
        public bool ItemListIsComplete { get => itemListIsComplete; set => itemListIsComplete = value; }
        internal LinkedList<Item> ItemListCompleteItems { get => itemListCompleteItems; set => itemListCompleteItems = value; }
        internal LinkedList<Item> ItemListIncompleteItems { get => itemListIncompleteItems; set => itemListIncompleteItems = value; }

        //parameterized constructor
        public ItemList(int itemListId, string itemListName, string itemListDetails, LinkedList<Item> itemListItems, List<ItemList> allItemLists)
        {
            ItemListId = itemListId;
            ItemListName = itemListName;
            ItemListDetails = itemListDetails;
            ItemListCompleteItems = new LinkedList<Item>();
            ItemListIncompleteItems = new LinkedList<Item>();
            foreach (Item item in itemListItems)
            {
                if (item.ItemBelongsToList == null)
                {
                    AddItemToList(item);
                }
                else
                {
                    Console.WriteLine("The item {0} belongs to the list {1}.", item.ItemText, item.ItemBelongsToList.ItemListName);
                } 
            }
            ItemListIsComplete = (itemListIncompleteItems.Count == 0) ? true : false;
            allItemLists.Add(this);
        }

        //default constructor
        public ItemList(List<ItemList> allItemLists)
        {
            ItemListId = 0; //change to make sure id will be unique
            ItemListName = "Item List";
            ItemListDetails = "Item List Details";
            ItemListIsComplete = true;
            ItemListCompleteItems = new LinkedList<Item>();
            ItemListIncompleteItems = new LinkedList<Item>();
            allItemLists.Add(this);

        }

        //class functions
        public void AddItemToList(Item item)
        {
            if(item.ItemBelongsToList == this)
            {
                Console.WriteLine("This list already contains this item.");
            }
            else if (item.ItemBelongsToList == null) //rearrange if else so this check goes first, add this check to remove function?
            {
                if (item.ItemIsComplete)
                {
                    ItemListCompleteItems.AddLast(item); //change to different add method? this adds to end of list
                }
                else
                {
                    ItemListIncompleteItems.AddLast(item); //change to different add method? this adds to end of list
                }
                item.ItemBelongsToList = this;
                ItemListIsComplete = (ItemListIncompleteItems.Count == 0) ? true : false;
            } else
            {
                Console.WriteLine("This item belongs to the list {0}.", item.ItemBelongsToList.ItemListName);
            }
        }

        public void RemoveItemFromList(Item item)
        {
            if (item.ItemBelongsToList == this)
            {
                if (item.ItemIsComplete)
                {
                    ItemListCompleteItems.Remove(item);
                }
                else
                {
                    ItemListIncompleteItems.Remove(item);
                }
                item.ItemBelongsToList = null; //is setting this to null ok? removing from list = deleting item?
                ItemListIsComplete = (ItemListIncompleteItems.Count == 0) ? true : false;
            }
            else
            {
                Console.WriteLine("This list does not contain this item.");
            }
        } 

        public void UpdateListCompletionAfterItemCheck(Item item)
        {
            if(item.ItemIsComplete)
            {
                ItemListIncompleteItems.Remove(item);
                ItemListCompleteItems.AddLast(item);
            } else
            {
                ItemListCompleteItems.Remove(item);
                ItemListIncompleteItems.AddLast(item);
            }
            ItemListIsComplete = (ItemListIncompleteItems.Count == 0) ? true : false;
        }

        //need to finish - will depend how ui works
        //add visible bool to item class for if an item shows in ui?
        public void FilterByTag(Tag tag)
        {
            foreach (Item item in ItemListCompleteItems)
            {
                if(item.ItemTags.Contains(tag))
                {
                    //show these items in filtered list
                } else
                {
                    //don't show these items in filtered list
                }
            }
            foreach (Item item in ItemListIncompleteItems)
            {
                if (item.ItemTags.Contains(tag))
                {
                    //show these items in filtered list
                }
                else
                {
                    //don't show these items in filtered list
                }
            }
        }

        public void DeleteItemList(List<ItemList> allItemLists)
        {
            if (ItemListCompleteItems.Count > 0)
            {
                foreach (Item item in ItemListCompleteItems)
                {
                    item.ItemBelongsToList = null; //this will prevent unnecessary RemoveItemFromList call in DeleteItem function (it is unnecessary to update list values since entire list is being deleted)
                    item.DeleteItem();
                }
            }
            if (ItemListIncompleteItems.Count > 0)
            {
                foreach (Item item in ItemListIncompleteItems)
                {
                    item.ItemBelongsToList = null; //this will prevent unnecessary RemoveItemFromList call in DeleteItem function (it is unnecessary to update list values since entire list is being deleted)
                    item.DeleteItem();
                }
            }
            allItemLists.Remove(this);
            //remove item list from stored data
            //account for the item list's id no longer being in use?
        }

        //data output functions
        public void PrintAllItemListValues()
        {
            Console.WriteLine("Item List Id: {0}", ItemListId);
            Console.WriteLine("Item List Name: {0}", ItemListName);
            Console.WriteLine("Item List Details: {0}", ItemListDetails);
            Console.WriteLine("Item List Is Complete: {0}", ItemListIsComplete);
            PrintAllItemListItems();
        }

        public void PrintAllItemListItems()
        {
            Console.WriteLine("Completed Items:");
            PrintAllItemListCompleteItems();
            Console.WriteLine("Uncompleted Items:");
            PrintAllItemListIncompleteItems();
        }

        public void PrintAllItemListCompleteItems()
        {
            if(ItemListCompleteItems.Count > 0)
            {
                foreach (Item item in ItemListCompleteItems)
                {
                    Console.WriteLine(item.ItemText);
                }
            }
            else
            {
                Console.WriteLine("There are no completed items in this list.");
            }
        }

        public void PrintAllItemListIncompleteItems()
        {
            if (ItemListIncompleteItems.Count > 0)
            {
                foreach (Item item in ItemListIncompleteItems)
                {
                    Console.WriteLine(item.ItemText);
                }
            }
            else
            {
                Console.WriteLine("There are no uncompleted items in this list.");
            }
        }
    }
}
