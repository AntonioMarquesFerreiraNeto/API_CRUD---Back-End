using API_CRUD_FROTA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_CRUD_FROTA.Data.Map {
    public class MapFrota : IEntityTypeConfiguration<Onibus> {
        public void Configure(EntityTypeBuilder<Onibus> builder) {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Motorista);
        }
    }
}
