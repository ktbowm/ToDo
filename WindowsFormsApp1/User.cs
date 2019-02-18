using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class User
    {
        //class variables
        private int userId;
        private string userEmail; //encrypt in future? use username instead?
        private string userPassword; //encrypt in future
        private List<int> userItemListIds; //use ItemListCollection instead (shouldn't need that functionality)?

        //getters and setters (encapsulates variables)
        public int UserId { get => userId; set => userId = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public List<int> UserItemListIds { get => userItemListIds; set => userItemListIds = value; }

        //paramaterized constructor
        public User(int userId, string userEmail, string userPassword)
        {
            UserId = userId; //make sure ids will be unique
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserItemListIds = new List<int>(); //assumes user is new and has no lists
        }

        //class functions
        //edit user's item lists - must call these on current user any time a list is created or removed
        public void AddItemListToUser(int itemListId)
        {
            UserItemListIds.Add(itemListId);
        }

        public void RemoveItemListFromUser(int itemListId)
        {
            if(UserItemListIds.Contains(itemListId))
            {
                UserItemListIds.Remove(itemListId);
            }
        }

        public void DeleteUser()
        {
            //remove stored user data
            //log out
        }
    }
}
