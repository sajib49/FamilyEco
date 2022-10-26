using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.API.Models
{
    [Table("PersonContact")]
    public class PersonContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }
        public string PhotoSite { get; set; }
        public string HomeTel { get; set; }
        public string WorkTel { get; set; }
        public string Mobile { get; set; }
        public string Skype { get; set; }
        public string Address { get; set; }
        public string Other { get; set; }
        public virtual Person Person { get; set; }
    }
}