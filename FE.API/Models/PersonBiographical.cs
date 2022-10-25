using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.API.Models
{
    [Table("PersonBiographical")]
    public class PersonBiographical
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string BirthPlace { get; set; }

        public string DeathPlace { get; set; }

        public string CauseOfDeath { get; set; }

        public string BurialPlace { get; set; }

        public short? DeathDateType { get; set; }

        public DateTime? DeathDateFrom { get; set; }

        public DateTime? DeathDateTo { get; set; }

        public bool? IsDeathDateBCE { get; set; }

        public virtual Person Person { get; set; }
    }
}