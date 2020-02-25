using System;

namespace Domain
{

    public class Customer  : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public bool IsRemoved { get; set; }
    }
}
