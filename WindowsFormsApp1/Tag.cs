using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Tag
    {
        //class variables
        private int tagId;
        private string tagName;
        private string tagDetails;

        //getters and setters (encapsulates variables)
        public int TagId { get => tagId; set => tagId = value; }
        public string TagName { get => tagName; set => tagName = value; }
        public string TagDetails { get => tagDetails; set => tagDetails = value; }

        //paramaterized constructor
        public Tag(int tagId, string tagName, string tagDetails)
        {
            TagId = tagId;
            TagName = tagName;
            TagDetails = tagDetails;
        }

        //default constructor
        public Tag()
        {
            TagId = 0; //change to make sure id will be unique
            TagName = "Tag";
            TagDetails = "Tag Details";
        }
    }
}
