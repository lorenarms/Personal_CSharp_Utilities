using System;
using System.Collections.Generic;

namespace ImportDataCSV
{
    class SortingHat : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;

            // id sort
            var idNumberComparison = x.IdNumber.CompareTo(y.IdNumber);
            if (idNumberComparison != 0) return idNumberComparison;

            // First name sort
            //var firstNameComparison = string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
            //if (firstNameComparison != 0) return firstNameComparison;

            // Last name sort
            return string.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
        }
    }
}