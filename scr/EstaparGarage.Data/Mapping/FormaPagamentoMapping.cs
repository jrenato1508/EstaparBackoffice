using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Mapping
{
    internal class FormaPagamentoMapping : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(f => f.Codigo)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(f => f.Descricao)
                .IsRequired()
                .HasColumnType("Varchar(10)");
        }
    }
}
