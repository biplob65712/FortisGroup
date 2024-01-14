using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisGroup.MODELS.EntityModels
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Status { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
