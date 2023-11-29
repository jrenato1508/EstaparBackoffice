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
    public class PassagemMapping : IEntityTypeConfiguration<Passagem>
    {
        public void Configure(EntityTypeBuilder<Passagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeGaragem)
                .IsRequired()
                .HasColumnType("vachar(50)");

            builder.Property(p => p.CarroPlaca)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.CarroMarca)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.CarroModelo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            //builder.HasOne(p => p.Garagem)
            //    .WithOne(g => g.Passagem);

            //builder.HasOne(p => p.FormaPagamento)
            //    .WithOne(f => f.Passagem);

            builder.ToTable("Passagens");
        }
    }
}
