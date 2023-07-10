using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Situation
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
