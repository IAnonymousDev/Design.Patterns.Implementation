using Strategy_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy_Pattern.Models;
using Strategy_Pattern.Enums;
using Strategy_Pattern.Utilities;
using Autofac.Features.Indexed;

namespace Strategy_Pattern.Services
{
    public class PropertyMatchingService : IPropertyMatchingService
    {
        public IIndex<AgencyCode, IPropertyMatcher> propertyMatchers { get; private set; }
        public PropertyMatchingService(IIndex<AgencyCode, IPropertyMatcher> propertyMatchers)
        {
            this.propertyMatchers = propertyMatchers;
        }

        #region Good Approach
        public bool MatchProperty(Property agencyProperty, Property databaseProperty)
        {
            throw new Exception("test exception");

            var matcher = propertyMatchers[agencyProperty.AgencyCode];
            return matcher.IsMatch(agencyProperty, databaseProperty);
        }
        #endregion

        #region Not So Good Approach
        //public bool MatchProperty(Property agencyProperty, Property databaseProperty)
        //{
        //    AgencyCode agencyCode = (AgencyCode)Enum.Parse(typeof(AgencyCode), agencyProperty.AgencyCode);
        //    switch (agencyCode)
        //    {
        //        case AgencyCode.OTBRE:
        //            return MatchOnlyTheBestRealEstateProperty(agencyProperty, databaseProperty);
        //        case AgencyCode.LRE:
        //            return MatchLocationRealEstateProperty(agencyProperty, databaseProperty);
        //        case AgencyCode.CRE:
        //            return MatchContraryRealEstateProperty(agencyProperty, databaseProperty);
        //        default:
        //            throw new ArgumentException(string.Format("Agency with code {0} is not set up for matching", agencyProperty.AgencyCode));
        //    }
        //}

        //private bool MatchOnlyTheBestRealEstateProperty(Property agencyProperty, Property databaseProperty)
        //{
        //    //return true if both property name and address match after excluding punctuations; else false
        //}

        //private bool MatchLocationRealEstateProperty(Property agencyProperty, Property databaseProperty)
        //{
        //    //Return true if agency code is the same and the property is within 200 metres or 
        //    //less of the actual property location; else false
        //}

        //private bool MatchContraryRealEstateProperty(Property agencyProperty, Property databaseProperty)
        //{
        //    //Return true if the names match when the words in the name of the property are reversed; 
        //    //else false
        //}
        #endregion
    }
}
