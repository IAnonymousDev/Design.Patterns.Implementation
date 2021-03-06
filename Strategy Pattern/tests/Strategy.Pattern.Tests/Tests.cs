﻿using Strategy.Pattern.Core.Models;
using Strategy.Pattern.Public.Enums;
using Strategy.Pattern.Utilities;
using System;
using Xunit;

namespace Strategy.Pattern.Tests
{
    public class Tests
    {
        [Fact]
        public void OnlyTheBestRealEstateTest_NameContainsValue_ReturnsTrue()
        {
            var agencyProperty =  new Property()
            {
                AgencyCode = AgencyCode.OTBRE,
                Name = "“*Super*-High! APARTMENTS (Sydney)”", 
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
            };

            var databaseProperty = new Property()
            {
                AgencyCode = AgencyCode.OTBRE,
                Name = "Super High Apartments, Sydney", 
                Address = "32 Sir John Young Crescent, Sydney NSW",
            };

            var matchingStrategy = new OnlyTheBestRealEstateStrategy();
            var isMatch = matchingStrategy.IsMatch(agencyProperty, databaseProperty);

            Assert.True(isMatch);
        }

        [Fact]
        public void OnlyTheBestRealEstateTest_NameContainsNull_ThrowsArgumentException()
        {
            var agencyProperty = new Property()
            {
                AgencyCode = AgencyCode.OTBRE,
                Name = null,
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
            };

            var databaseProperty = new Property()
            {
                AgencyCode = AgencyCode.OTBRE,
                Name = null,
                Address = "32 Sir John Young Crescent, Sydney NSW",
            };

            var matchingStrategy = new OnlyTheBestRealEstateStrategy();

            var ex = Assert.Throws<ArgumentException>(() => matchingStrategy.IsMatch(agencyProperty, databaseProperty));

            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Name", ex.ParamName);
        }

        [Fact]
        public void LocationRealEstateTest_LatitudeContainsZero_ThrowsArgumentException()
        {
            var agencyProperty = new Property()
            {
                AgencyCode = AgencyCode.LRE,
                Latitude = Decimal.Zero,
                Longitude = 151.2127022m
            };

            var databaseProperty = new Property()
            {
                AgencyCode = AgencyCode.LRE,
                Latitude = -33.8711893m,
                Longitude = 151.2145022m
            };

            var matchingStrategy = new LocationRealEstateStrategy();

            var ex = Assert.Throws<ArgumentException>(() => matchingStrategy.IsMatch(agencyProperty, databaseProperty));

            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Latitude", ex.ParamName);
        }
    }
}
