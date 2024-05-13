using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(E => E.Address);
            builder.Property(E => E.Salary).HasColumnType("decimal(12,3)");

            builder.Property(E => E.Gender)
                .HasConversion(
                (Gender) => Gender.ToString(),
                (GenderAsString) => (Gender)Enum.Parse(typeof(Gender), GenderAsString, true));
        }
    }
}
