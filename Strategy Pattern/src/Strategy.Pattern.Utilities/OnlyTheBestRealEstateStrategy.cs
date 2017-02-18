using System;
using System.Linq;
using System.Text.RegularExpressions;
using Strategy.Pattern.Core.Models;
using Strategy.Pattern.Core.Contracts;

namespace Strategy.Pattern.Utilities
{
    public class OnlyTheBestRealEstateStrategy : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var agencyPropertyName = FormatName(agencyProperty.Name);
            var agencyPropertyAddress = FormatAddress(agencyProperty.Address);

            return agencyPropertyName.ToLower() == databaseProperty.Name.ToLower() &&
                    agencyPropertyAddress.ToLower() == databaseProperty.Address.ToLower();
        }

        private string FormatName(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("property value can not be null", "Name");

            var nameWithoutComma = propertyName.Replace(",", "");
            var suburbFormattedName = Regex.Replace(nameWithoutComma, @" \(([^)]*)\)", 
                new MatchEvaluator(FormatSuburb));

            return Regex.Replace(suburbFormattedName, @"[^\w\s\-\,]", "").Replace("-", " ");
        }

        private string FormatAddress(string propertyAddress)
        {
            if (string.IsNullOrEmpty(propertyAddress))
                throw new ArgumentException("property value can not be null", "Address");

            var address = propertyAddress.Replace("-", " ");
            var count = address.Count(a => a == ',');
            if (count == 1)
                return address;

            else
            {
                var addressParts = address.Split(',');
                return string.Format("{0},{1}{2}", addressParts[0], addressParts[1], addressParts[2]);
            }
        }

        private string FormatSuburb(Match m)
        {
            return m.ToString().Replace(" (", ", ").Replace(")", "");
        }
    }
}
