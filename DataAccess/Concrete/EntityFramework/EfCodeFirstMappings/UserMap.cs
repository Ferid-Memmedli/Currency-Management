using Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Entities.EfCodeFirstMappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(m => m.UserID);

            Property(m => m.Email)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("Index1") { IsUnique = true }));

            Property(m => m.Password).HasMaxLength(64).IsRequired().HasColumnType("nchar");
        }
    }
}
