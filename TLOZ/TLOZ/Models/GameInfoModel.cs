using System;
using System.Collections.Generic;
using System.Text;

namespace TLOZ.Models
{
    public class GameInfoModel
    {
        public GameInfoModel(string id, string _name, string _description, string _developer, string _publisher
            , string _releasedDate, string v)
        {
            _id = id;
            name = _name;
            description = _description;
            developer = _developer;
            publisher = _publisher;
            released_date = _releasedDate;
            __v = v; 
        }
            public string _id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string developer { get; set; }
            public string publisher { get; set; }
            public string released_date { get; set; }
            public string __v { get; set; }

    }
}
