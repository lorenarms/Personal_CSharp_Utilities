
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
    internal class GenerateId
    {
        private static int _idSize = 10;
        private static string[] _pool;

        // generate a pool of characters to pull from, based on ASCII table
        private static void GeneratePool()
        {
            _pool = new string[62];
            var index = 0;

            // numbers
            for (var i = 48; i < 58; i++)
            {
                _pool[index] = char.ToString((char) i);
                index++;
            }

            // capital letters
            for (var i = 65; i < 91; i++)
            {
                _pool[index] = char.ToString((char) i);
                index++;
            }

            // lowercase letters
            for (var i = 97; i < 123; i++)
            {
                _pool[index] = char.ToString((char) i);
                index++;
            }
        }

        // build a unique id from the pool
        public static string GenerateUniqueId()
        {
            // singleton
            if (_pool == null)
            {
                GeneratePool();
            }


            var s = "";
            var rnd = new Random();
            for (int i = 0; i < _idSize; i++)
            {
                // generate a random number, use that as the index in '_pool', add that char to string 's'
                if (_pool != null) s = s + _pool[rnd.Next(_pool.Length)];
            }

            return s;
        }

        // method to determine how many possible id's can be generated from the given pool and id size
        // used to determine if all id's have been exhausted (see 'table' method "AddAThing")
        public static double GetMaxEntries()
        {
            return Math.Pow(_pool.Length, _idSize);
        }

        public void SetIdSize(int size)
        {
            _idSize = size;
        }
    }
}
