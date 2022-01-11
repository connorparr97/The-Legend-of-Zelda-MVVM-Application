using System;
using System.Collections.Generic;
using System.Text;

namespace TLOZ.Models
{
    public class SingleGameModel
    {

        public class Rootobject
        {
            public bool success { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string developer { get; set; }
            public string publisher { get; set; }
            public string released_date { get; set; }
            public int __v { get; set; }
        }


    }
}
