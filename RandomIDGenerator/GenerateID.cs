
//
// This class generates a random string of characters using
// capital letters, lowercase letters, and numbers 0 - 9
// Adjust "ID_SIZE" to make the string longer or shorter
// Use "GetMaxEntries" to calculate how many total unique entries
// can be created (for checking if a table is potentially full)
//
// Sample program included in "Driver.cs", creating a HashTable
// filled with "Things". Add whatever properties to "Things" as
// necessary.
// 



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomIDGenerator
{
    class GenerateID
    {
        const int ID_SIZE = 10;
        private static string[] _pool;

        private static void generatePool()
        {
            _pool = new string[62];
            int index = 0;
            for (int i = 48; i < 58; i++)
            {
                _pool[index] = Char.ToString((char) i);
                index++;
            }

            for (int i = 65; i < 91; i++)
            {
                _pool[index] = Char.ToString((char) i);
                index++;
            }

            for (int i = 97; i < 123; i++)
            {
                _pool[index] = Char.ToString((char) i);
                index++;
            }
        }

        public static string generateUniqueID()
        {
            if (_pool == null)
            {
                generatePool();
            }

            string s = "";
            Random rnd = new Random();
            for (int i = 0; i < ID_SIZE; i++)
            {
                s = s + _pool[rnd.Next(_pool.Length)];
            }

            return s;
        }

        public static double GetMaxEntries()
        {
            return Math.Pow(_pool.Length, ID_SIZE);
        }
    }
}
