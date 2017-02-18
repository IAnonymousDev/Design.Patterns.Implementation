using Autofac;
using Strategy.Pattern.Core.Contracts;
using Strategy.Pattern.Core.Models;
using Strategy.Pattern.Public.Enums;
using System;

namespace Strategy_Pattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var agencyProperty = new Property()
            {
                AgencyCode = AgencyCode.OTBRE,
                Name = "“*Super*-High! APARTMENTS (Sydney)”", //"Apartments Summit The",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                Latitude = -33.8711893m,
                Longitude = 151.2127022m
            };

            var databaseProperty = new Property()
            {
                AgencyCode = AgencyCode.OTBRE,
                Name = "Super High Apartments, Sydney", //"The Summit Apartments",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                Latitude = -33.8711893m,
                Longitude = 151.2145022m
            };

            Startup.IoCConfiguration();

            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                //try
                //{
                    var propertyMatcherService = scope.Resolve<IPropertyMatchingService>();
                    var isMatch = propertyMatcherService.MatchProperty(agencyProperty, databaseProperty);
                    Console.WriteLine("Properties matched successfully!");
                    Console.ReadLine();

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Properties matched successfully!");
                //    Console.ReadLine();
                //}                
            }
        }
    }
}
