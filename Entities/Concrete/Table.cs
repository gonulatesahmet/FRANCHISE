using Core.Entities;

namespace Entities.Concrete
{
    public class Table : IEntity
    {
        public int TableId { get; set; }
        public int AreaId { get; set; }
        public string TableName { get; set; }
        public string TableCode { get; set; }
        public string TableDescription { get; set; }
        public bool Display { get; set; }
        public bool TableState { get; set; }
    }
}
