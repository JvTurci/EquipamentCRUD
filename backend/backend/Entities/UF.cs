using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class UF
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
    }
}
