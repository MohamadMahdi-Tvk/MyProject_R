using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.DataAccess.Models.Abstratction;

namespace MyProject.DataAccess.Models;

public class Role : BaseEntity
{
    public string Title { get; set; }

    public ICollection<User> Users { get; set; }
}

public class RoleConfiguration : BaseEntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(10);

        
    }
}
