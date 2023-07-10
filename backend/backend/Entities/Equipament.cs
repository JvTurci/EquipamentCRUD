using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace backend.Entities
{
    public class Equipament
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string EquipamentIdentifier { get; set; }

        public int UfSourceId { get; set; }
        public virtual UF? UfSource { get; set; }

        public int UfDestinationId { get; set; }
        public virtual UF UfDestination { get; set; }

        public int ReadDirectionId { get; set; }
        public virtual ReadDirection ReadDirection { get; set; }

        public int SituationId { get; set; }
        public virtual Situation Situation { get; set; }
    }
}
