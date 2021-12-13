using Indimin.Challenge.Tasking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indimin.Challenge.Tasking.Infraestructure.EntityConfigurations
{
    public class CitizenTaskConfiguration : IEntityTypeConfiguration<CitizenTask>
    {
        public void Configure(EntityTypeBuilder<CitizenTask> builder)
        {
            builder.ToTable("CitizenTask", TaskingDbContext.DEFAULT_SCHEMA);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseHiLo("citizentaskseq", TaskingDbContext.DEFAULT_SCHEMA);

            builder.Property<int>("_dayOfWeek")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DayOfWeek")
                .IsRequired();

            builder.HasOne<DayOfWeek>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("_dayOfWeek")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<string>("_citizenId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CitizenId")
                .IsRequired();

            builder.Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .IsRequired();

            builder.Property<bool>("_isActive")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsActive")
                .IsRequired();

        }
    }
}
