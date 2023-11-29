using EstaparGarage.Bussinees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Mapping
{
    public class GaragemMapping : IEntityTypeConfiguration<Garagem>
    {
        public void Configure(EntityTypeBuilder<Garagem> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Codigo)
                .IsRequired()
                .HasColumnType("vachar(50)");

            builder.Property(g => g.Nome)
                .IsRequired()
                .HasColumnType("vachar(50)");

            builder.ToTable("Garangens");

        }
    }
}
