using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class ReadDirection
    {
        [Key]
        public int Id { get; set; }
        public string Direction { get; set; }
    }
}
