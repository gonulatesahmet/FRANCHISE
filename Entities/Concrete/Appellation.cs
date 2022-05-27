using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Appellation : IEntity
    {
        public int AppellationId { get; set; }
        public string AppellationName { get; set; }
        public string AppellationCode { get; set; }
        public string AppellationDescription { get; set; }
        public bool AppellationState { get; set; }
    }
}
