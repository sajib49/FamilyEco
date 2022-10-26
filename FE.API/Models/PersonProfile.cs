using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.API.Models
{
    [Table("PersonProfile")]
    public class PersonProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Profession { get; set; }
        public string Company { get; set; }
        public string Interests { get; set; }
        public string Activities { get; set; }
        public string BioNotes { get; set; }

    }
}