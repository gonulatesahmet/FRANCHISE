using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public class OrderStateEnum
    {
        public enum OrderState
        {
            Onaylanacak = 0,
            Hazirlaniyor = 1,
            Onaylandi = 2
        }
    }
}
