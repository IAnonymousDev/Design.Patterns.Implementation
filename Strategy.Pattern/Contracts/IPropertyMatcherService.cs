using Strategy_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern.Contracts
{
    public interface IPropertyMatchingService
    {
        bool MatchProperty(Property agencyProperty, Property databaseProperty);
    }
}
