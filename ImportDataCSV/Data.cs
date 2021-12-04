using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportDataCSV;

namespace ImportDataCSV
{
    class Data
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"Customer {ID} Name: {Name}, Status: {Status}";
        }
    }
}
