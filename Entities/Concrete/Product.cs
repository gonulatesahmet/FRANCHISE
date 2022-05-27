using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public bool StockStatus { get; set; }
        public int CategoryId { get; set; }
        public int TypeOfProductId { get; set; }
        public bool ProductState { get; set; }
    }
}
