using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TypeOfProduct : IEntity
    {
        public int TypeOfProductId { get; set; }
        public string TypeOfProductName { get; set; }
        public string TypeOfProductCode { get; set; }
        public string TypeOfProductDescription { get; set; }
        public bool TypeOfProductDisplay { get; set; }
        public bool TypeOfProductPrinter { get; set; }
        public bool TypeOfProductState { get; set; }
    }
}
