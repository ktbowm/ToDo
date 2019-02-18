using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ItemListCollection
    {
        //class variables
        private List<ItemList> itemListCollectionLists;
        private List<Item> itemListCollectionAllCompleteItems;
        private List<Item> itemListCollectionAllIncompleteItems;

        //getters and setters (encapsulates variables)
        internal List<ItemList> ItemListCollectionLists { get => itemListCollectionLists; set => itemListCollectionLists = value; }
        internal List<Item> ItemListCollectionAllCompleteItems { get => itemListCollectionAllCompleteItems; set => itemListCollectionAllCompleteItems = value; }
        internal List<Item> ItemListCollectionAllIncompleteItems { get => itemListCollectionAllIncompleteItems; set => itemListCollectionAllIncompleteItems = value; }

        //paramaterized constructor
        public ItemListCollection(List<ItemList> itemListCollectionLists)
        {
            foreach(ItemList itemList in itemListCollectionLists)
            {
                ItemListCollectionLists.Add(itemList);
                //initiate complete and incomplete lists?
                foreach(Item item in itemList.ItemListCompleteItems)
                {
                    ItemListCollectionAllCompleteItems.Add(item);
                }
                foreach (Item item in itemList.ItemListIncompleteItems)
                {
                    ItemListCollectionAllIncompleteItems.Add(item);
                }
            }
        }

        //class functions
        public void AddItemListToCollection(ItemList itemList)
        {
            if(ItemListCollectionLists.Contains(itemList))
            {
                Console.WriteLine("This collection already has the item list {0}.", itemList.ItemListName);
            } else
            {
                ItemListCollectionLists.Add(itemList);
                foreach(Item item in itemList.ItemListCompleteItems)
                {
                    itemListCollectionAllCompleteItems.Add(item);
                }
                foreach (Item item in itemList.ItemListIncompleteItems)
                {
                    itemListCollectionAllIncompleteItems.Add(item);
                }
            }
        }

        public void RemoveItemListToCollection(ItemList itemList)
        {
            if (ItemListCollectionLists.Contains(itemList))
            {
                ItemListCollectionLists.Remove(itemList);
                foreach (Item item in itemList.ItemListCompleteItems)
                {
                    itemListCollectionAllCompleteItems.Remove(item);
                }
                foreach (Item item in itemList.ItemListIncompleteItems)
                {
                    itemListCollectionAllIncompleteItems.Remove(item);
                }
            }
            else
            {
                Console.WriteLine("This collection does not have the item list {0}.", itemList.ItemListName);
            }
        }

        //data output functions
        public void PrintConsolidatedItemListCollection()
        {
            Console.WriteLine("All complete items:");
            foreach (Item item in ItemListCollectionAllCompleteItems)
            {
                Console.WriteLine(item.ItemText);
            }
            Console.WriteLine("All incomplete items:");
            foreach (Item item in ItemListCollectionAllIncompleteItems)
            {
                Console.WriteLine(item.ItemText);
            }
        }
    }
}
