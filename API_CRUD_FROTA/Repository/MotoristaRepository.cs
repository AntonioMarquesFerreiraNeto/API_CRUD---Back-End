using API_CRUD_FROTA.Data;
using API_CRUD_FROTA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_FROTA.Repository {
    public class MotoristaRepository : IMotoristaRepository {

        private readonly BancoContext _bancoContext;

        public MotoristaRepository(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public Motorista ListMotoristaById(int? id) {
            return _bancoContext.Motorista
                .AsNoTracking().Include(x => x.Onibus)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Motorista> ListMotoristaAll() {
            return _bancoContext.Motorista
                .AsNoTracking().Include(x => x.Onibus)
                .ToList();
        }

        public Motorista CreateMotorista(Motorista motorista) {
            try {
                motorista.MotoristaTrim();
                if (ValidationDuplicate(motorista)) throw new Exception("Motorista já se encontra registrado!");
                _bancoContext.Motorista.Add(motorista);
                _bancoContext.SaveChanges();
                return motorista;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Motorista UpdateMotorista(Motorista motorista) {
            try {
                Motorista motoristaDB = ListMotoristaById(motorista.Id);
                
                if (motoristaDB == null) throw new Exception("Desculpe, motorista não encontrado!");
                motorista.MotoristaTrim();
                if (ValidationDuplicateUpdate(motorista, motoristaDB)) throw new Exception("Motorista já se encontra registrado!");
                
                motoristaDB.Name = motorista.Name;
                motoristaDB.Rg = motoristaDB.Rg;
                motoristaDB.Cpf = motorista.Cpf;
                motoristaDB.DataNascimento = motorista.DataNascimento;
                motoristaDB.Tel = motorista.Tel;
                motoristaDB.Email = motorista.Email;

                _bancoContext.Motorista.Update(motoristaDB);
                _bancoContext.SaveChanges();
                return motoristaDB;
            }
            catch (Exception error) {
                throw new Exception(error.Message);
            }
        }

        public Motorista DeleteMotorista(Motorista motorista) {
            try {
                Motorista motoristaDB = ListMotoristaById(motorista.Id);
                if (motoristaDB == null) throw new Exception("Desculpe, motorista não encontrado!");
                _bancoContext.Motorista.Remove(motoristaDB);
                _bancoContext.SaveChanges();
                return motoristaDB;
            }
            catch (Exception error) {
                throw new Exception(error.Message);
            }
        }

        public bool ValidationDuplicate(Motorista motorista) {
            if (_bancoContext.Motorista.Any(x => x.Cpf == motorista.Cpf || x.Rg == motorista.Rg || x.Tel == motorista.Tel || x.Email == motorista.Email)) {
                return true;
            }
            return false;
        }

        public bool ValidationDuplicateUpdate(Motorista motorista, Motorista motoristaDB) {
            if (_bancoContext.Motorista.Any(x =>
                (x.Cpf == motorista.Cpf && motorista.Cpf != motoristaDB.Cpf) ||
                (x.Rg == motorista.Rg && motorista.Rg != motoristaDB.Rg) ||
                (x.Email == motorista.Email && motorista.Email != motoristaDB.Email) ||
                (x.Tel == motorista.Tel && motorista.Tel != motoristaDB.Tel)
                )) {
                return true;
            }
            return false;
        }
    }
}
