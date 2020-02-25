using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SearchCriterias
{
    public abstract class SearchCriteria
    {

    }

    public class CustomerSearchCriteria : SearchCriteria
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

    }
}
