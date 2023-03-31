using API_CRUD_FROTA.Models;

namespace API_CRUD_FROTA.Repository {
    public interface IOnibusRepository {
        public List<Onibus> ReturnListOnibus();
        public Onibus AddOnibus(Onibus onibus);
        public Onibus ReturnOnibusPorId(int? id);
        public Onibus UpdateOnibus(Onibus onibus);
        public Onibus Delete(int? id);
    }
}
