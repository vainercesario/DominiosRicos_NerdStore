﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class CatagoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(keyExpression: c=> c.Id);

            builder.Property(c => c.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

            builder.HasMany(navigationExpression: c => c.Produtos)
                .WithOne(navigationExpression: p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            builder.ToTable("Categorias");
        }
    }
}
