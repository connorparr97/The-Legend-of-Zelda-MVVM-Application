using System;
using System.Collections.Generic;
using System.Text;

namespace TLOZ.Models
{
    public class CharactersModel
    {
        public CharactersModel(string _success, string _count, CharactersModel[] _data, string[] _appearances, string id, string _name, string _descrip, string _gender, string _race, string v)
        {
            success = _success;
            count = _count;
            data = _data;
            appearances = _appearances;
            _id = id;
            name = _name;
            description = _descrip;
            gender = _gender;
            race = _race;
            __v = v; 

        }
            public string success { get; set; }
            public string count { get; set; }
            public CharactersModel[] data { get; set; }
            public string[] appearances { get; set; }
            public string _id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string gender { get; set; }
            public string race { get; set; }
            public string __v { get; set; }


    }
}
