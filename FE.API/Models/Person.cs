using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FE.API.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string SurnameNow { get; set; }
        public string SurnameAtBirth { get; set; }
        public string Nickname { get; set; }
        public short? Gender { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public bool? IsDeath { get; set; }
        public short? DeathDateType { get; set; }
        public DateTime? DeathDateFrom { get; set; }
        public DateTime? DeathDateTo { get; set; }
        public bool? IsDeathDateBCE { get; set; }
        public DateTime? BirthDateType { get; set; }
        public DateTime? BirthDateFrom { get; set; }
        public DateTime? BirthDateTo { get; set; }
        public bool? IsBirthDateBCE { get; set; }

        public virtual ICollection<PersonBiographical> PersonBiographicals { get; set; }        
        public virtual ICollection<PersonContact> PersonContacts { get; set; }
        public virtual PersonProfile PersonProfile { get; set; }        
        public virtual ICollection<PersonRelationship> PersonRelationships { get; set; }        
        public virtual ICollection<PersonRelationship> PersonRelationships1 { get; set; }
    }
}