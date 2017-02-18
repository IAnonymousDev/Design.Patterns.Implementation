using Strategy_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy_Pattern.Models;

namespace Strategy_Pattern.Utilities
{
    public class ContraryRealEstateStrategy : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (string.IsNullOrEmpty(agencyProperty.Name))
                throw new ArgumentException("property value can not be null or empty", "Name");

            var reverseAgencyPropName = string.Join(" ", agencyProperty.Name.Split(' ').Reverse().ToArray());
            return databaseProperty.Name.ToLower() == reverseAgencyPropName.ToLower();
        }
    }
}
