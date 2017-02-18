using System;
using System.Linq;
using Strategy.Pattern.Core.Contracts;
using Strategy.Pattern.Core.Models;

namespace Strategy.Pattern.Utilities
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
