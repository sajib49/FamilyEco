using FE.API.Models;
using System.Data.Entity;

namespace FE.API.DataAccess
{
    public class FamilyEcoDbContext : DbContext
    {
        public FamilyEcoDbContext() : base("name=FamilyEcoDbContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonBiographical> PersonBiographicals { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }
        public virtual DbSet<PersonProfile> PersonProfiles { get; set; }
        public virtual DbSet<PersonRelationship> PersonRelationships { get; set; }
    }
}