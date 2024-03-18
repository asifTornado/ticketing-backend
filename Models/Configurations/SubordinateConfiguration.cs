


using Microsoft.EntityFrameworkCore;
using Eapproval.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eapproval.Models.Configurations;

public class SubordinateConfiguration : IEntityTypeConfiguration<SubordinatesClass>
{
    public void Configure(EntityTypeBuilder<SubordinatesClass> builder)
    {
       
       builder.HasOne(x => x.User)
              .WithMany(x => x.TeamMembers)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Restrict);

       builder.HasOne(x => x.Team)
                .WithMany(x => x.Subordinates)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        
   
    }



}