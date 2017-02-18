using System;
using Strategy.Pattern.Core.Models;
using Strategy.Pattern.Core.Contracts;

namespace Strategy.Pattern.Utilities
{
    public class LocationRealEstateStrategy : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var acceptableDistance = GetAccetableDistanceInDegrees();

            if (agencyProperty.Latitude == Decimal.Zero)
                throw new ArgumentException("property value can not be 0", "Latitude");

            if (agencyProperty.Longitude == Decimal.Zero)
                throw new ArgumentException("property value can not be 0", "Longitude");

            var diffLatitude = databaseProperty.Latitude - agencyProperty.Latitude;
            var diffLongitude = databaseProperty.Longitude - agencyProperty.Longitude;

            return agencyProperty.AgencyCode == databaseProperty.AgencyCode &&
                 (diffLatitude == 0 || diffLatitude <= acceptableDistance) &&
                 (diffLongitude == 0 || diffLongitude <= acceptableDistance);
        }

        private decimal GetAccetableDistanceInDegrees()
        {
            //if 1 = 111000 then x = 200; //x = 1 / (111000 / 200)
            var OneDegreeInMeters = 111000m;
            var distanceInMeters = 200m;
            return Decimal.Divide(1, Decimal.Divide(OneDegreeInMeters, distanceInMeters));
        }
    }
}
