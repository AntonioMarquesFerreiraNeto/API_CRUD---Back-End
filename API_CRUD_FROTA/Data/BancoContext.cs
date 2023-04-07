using API_CRUD_FROTA.Data.Map;
using API_CRUD_FROTA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_FROTA.Data {
    public class BancoContext : DbContext {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {

        }

        //Criando as classes no banco de dados. 
        public DbSet<Onibus> Onibus { get; set; }
        public DbSet<Motorista> Motorista { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new MapFrota());
            base.OnModelCreating(modelBuilder);
        }
    }
}
