using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Auth : IEntity
    {
        public int AuthId { get; set; }
        public string AuthName { get; set; }
        public string AuthCode { get; set; }
        public string AuthDescription { get; set; }
        public bool AuthState { get; set; }
    }
}
