//Struktóra bazy 

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Entities
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole, string>
    {
        private const string _schema = "hb";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<PersonEntity> People { get; set; }
        public virtual DbSet<BillEntity> Bills { get; set; }
        public virtual DbSet<RelationEntity> Relations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Only for authentication functionality
            builder.HasDefaultSchema("auth");
            base.OnModelCreating(builder);

            builder.Entity<RelationEntity>(ConfigureRelationEntity);
            builder.Entity<PersonEntity>(ConfigurePersonEntity);
            builder.Entity<BillEntity>(ConfigureBillEntity);
        }

        private void ConfigureRelationEntity(EntityTypeBuilder<RelationEntity> entity)
        {
            entity.ToTable("Relations", _schema);
            entity.HasKey(e => e.RelationId);
            entity.Property(e => e.Description).HasColumnType("NVARCHAR(100)");

            var relations = new []
            {
                new RelationEntity{RelationId = 1 , Description = "Father" },
                new RelationEntity{RelationId = 2, Description = "Mother" },
                new RelationEntity{RelationId = 3, Description = "Son" },
                new RelationEntity{RelationId = 4, Description = "Daughter"}
            };

            entity.HasData(relations);
        }

        private void ConfigureBillEntity(EntityTypeBuilder<BillEntity> entity)
        {
            entity.ToTable("Bills", _schema);
            entity.HasKey(e => e.BillId);
            entity.Property(e => e.Description).HasColumnType("NVARCHAR(100)");

            var bills = new[]
            {
                new BillEntity {BillId = 1, Description = "TV", Amount = 3999.99f, CreatedBy = "Emily", CreatedDate = DateTime.Now, PersonId = 1, BillDate = new DateTime(2019,3,4)},
                new BillEntity {BillId = 2, Description = "Washer", Amount = 1000f, CreatedBy = "Emily", CreatedDate = DateTime.Now, PersonId = 1, BillDate = new DateTime(2019,1,25)},
                new BillEntity {BillId = 3, Description = "Audio SYstem", Amount = 5999.00f, CreatedBy = "Emily", CreatedDate = DateTime.Now, PersonId = 1, BillDate = new DateTime(2019,2,10)},
                new BillEntity {BillId = 4, Description = "Groseriec", Amount = 30f, CreatedBy = "Bob", CreatedDate = DateTime.Now, PersonId = 2, BillDate = new DateTime(2019,5,15)},
                new BillEntity {BillId = 5, Description = "Food", Amount = 100f, CreatedBy = "Bob", CreatedDate = DateTime.Now, PersonId = 2, BillDate = new DateTime(2019,5,6)},
                new BillEntity {BillId = 6, Description = "Beer", Amount = 15f, CreatedBy = "Bob", CreatedDate = DateTime.Now, PersonId = 2, BillDate = new DateTime(2019,5,9)},
            };
            entity.HasData(bills);
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("People", _schema);
            entity.HasKey(e => e.PersonId);
            entity.Property(e => e.Description).HasColumnType("NVARCHAR(100)");
            entity.Property(e => e.Name).HasColumnType("NVARCHAR(200)");
            entity.HasOne(x => x.Relation)
                .WithMany(z => z.People)
                .HasForeignKey(f => f.RelationId);

            entity.HasMany(e => e.Bills)
                .WithOne(z => z.Person)
                .HasForeignKey(f => f.PersonId);

            var people = new[]
            {
                new PersonEntity{PersonId = 1, Description = "Girl",Name = "Emily", RelationId = 4 },
                new PersonEntity{PersonId = 2, Description = "head of family", Name = "Bob", RelationId = 1}
            };
            entity.HasData(people);
        }
    }
}
