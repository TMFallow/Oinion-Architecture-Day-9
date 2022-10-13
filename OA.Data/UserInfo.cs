using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data
{
    public class UserInfo : BaseEntity
    {
        
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual User User { get; set; }
    }
}
