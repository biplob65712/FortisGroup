using FortisGroup.MODELS.EntityModels;

namespace PROJECT01.Models
{
    public class CreateItemVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Status { get; set; }
        public int? CategoryID { get; set; } 
        public ICollection<Category>? Categories { get; set; }
    }
}
