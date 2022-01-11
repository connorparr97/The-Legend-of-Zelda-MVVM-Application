using System;
using System.Collections.Generic;
using System.Text;

namespace TLOZ.Models
{
    public class SingleGameModel
    {
        public SingleGameModel(SingleGameModel _data, string _success, string id, string _name, string _descrip, string _dev, string _pub, string _released, string v)
        {
            data = _data;
            success = _success;
            _id = id;
            name = _name;
            description = _descrip;
            developer = _dev;
            publisher = _pub;
            released_date = _released;
            __v = v;
         
        }

            public string success { get; set; }
            public SingleGameModel data { get; set; }

            public string _id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string developer { get; set; }
            public string publisher { get; set; }
            public string released_date { get; set; }
            public string __v { get; set; }
       
    }
}
