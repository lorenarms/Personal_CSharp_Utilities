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
    }
}
