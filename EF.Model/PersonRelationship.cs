using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.API.Models
{
    [Table("PersonRelationship")]
    public class PersonRelationship
    {
        [Key]
        public int Id { get; set; }
        public int PersonId1 { get; set; }
        public int? PersonId2 { get; set; }
        public short RelationType { get; set; }
        public int? RelationId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
        
        public virtual ICollection<PersonRelationship> PersonRelationship1 { get; set; }
        public virtual PersonRelationship PersonRelationship2 { get; set; }
    }
}