using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalog.Data.Mapping;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(keyExpression: c => c.Id);

        builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(250)");

        builder.HasMany(navigationExpression: c => c.Produtos).WithOne(c => c.Categoria).HasForeignKey(c => c.CategoriaId);

        builder.ToTable("Categorias");
    }
}