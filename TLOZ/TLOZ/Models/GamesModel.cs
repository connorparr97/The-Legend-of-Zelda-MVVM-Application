using System;
using System.Collections.Generic;
using System.Text;

namespace TLOZ.Models
{
    public class GamesModel
    {
        public GamesModel(GamesModel[] _data, string _success, string _count, string id, string _name, string _descrip, string _dev, string _pub, string _released, string v, string _image)
        {
            data = _data;
            success = _success;
            count = _count;
            _id = id;
            name = _name;
            description = _descrip;
            developer = _dev;
            publisher = _pub;
            released_date = _released;
            __v = v;
            image = _image; 


        }
            public string success { get; set; }
            public string count { get; set; }
            public GamesModel[] data { get; set; }
            public string _id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string developer { get; set; }
            public string publisher { get; set; }
            public string released_date { get; set; }
            public string __v { get; set; }

        // create extra variable for image links as API doesn't support it 
            public string image { get; set; }
    }
}
