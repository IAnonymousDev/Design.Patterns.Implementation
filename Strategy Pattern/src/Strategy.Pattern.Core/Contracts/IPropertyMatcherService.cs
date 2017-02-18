using Strategy.Pattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Pattern.Core.Contracts
{
    public interface IPropertyMatchingService
    {
        bool MatchProperty(Property agencyProperty, Property databaseProperty);
    }
}
