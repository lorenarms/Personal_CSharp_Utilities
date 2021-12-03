using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomIDGenerator
{
    class Thing
    {
        private String _id;
        private int _num;
        

        public Thing(String id)
        {
            _id = id;
            var rand = new Random();
            _num = rand.Next(100);
        }
        public String GetID()
        {
            return _id;
        }

        public int GetNum()
        {
            return _num;
        }


        
    }
}
