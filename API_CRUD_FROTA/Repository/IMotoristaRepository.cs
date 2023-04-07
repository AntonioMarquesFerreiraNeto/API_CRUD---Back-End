using API_CRUD_FROTA.Models;

namespace API_CRUD_FROTA.Repository {
    public interface IMotoristaRepository {
        public List<Motorista> ListMotoristaAll();
        public Motorista ListMotoristaById(int? id);
        public Motorista CreateMotorista(Motorista motorista);
        public Motorista UpdateMotorista(Motorista motorista);
        public Motorista DeleteMotorista(Motorista motorista);
    }
}
