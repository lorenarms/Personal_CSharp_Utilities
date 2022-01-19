using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomIDGenerator
{
    internal class Thing
    {
        private readonly string _id;
        private readonly int _num;
        

        public Thing(string id)
        {
            _id = id;
            var rand = new Random();
            _num = rand.Next(100);
        }
        public string GetId()
        {
            return _id;
        }

        public int GetNum()
        {
            return _num;
        }


        
    }
}
