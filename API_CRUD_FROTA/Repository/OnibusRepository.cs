using API_CRUD_FROTA.Data;
using API_CRUD_FROTA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_FROTA.Repository {
    public class OnibusRepository : IOnibusRepository {

        private readonly BancoContext _bancoContext;

        public OnibusRepository(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public Onibus ReturnOnibusPorId(int? id) {
            return _bancoContext.Onibus
                .AsNoTracking()
                .Include(x => x.Motorista)
                .FirstOrDefault(x => x.Id == id);
        }

        public Onibus AddOnibus([FromBody] Onibus onibus) {
            try {
                onibus.OnibusTrim();
                if (ValidationDuplicataBus(onibus)) throw new Exception("Ônibus já se encontra registrado!");
                _bancoContext.Onibus.Add(onibus);
                _bancoContext.SaveChanges();
                return onibus;
            }
            catch (Exception error) {
                throw new Exception(error.Message);
            }
        }

        public List<Onibus> ReturnListOnibus() {
            return _bancoContext.Onibus
                .AsNoTracking().Include(x => x.Motorista)
                .ToList();
        }

        public Onibus UpdateOnibus(Onibus onibus) {
            try {
                Onibus onibusDB = ReturnOnibusPorId(onibus.Id);
                if (onibusDB == null) throw new Exception("Desculpe, ônibus não encontrado!");
                onibus.OnibusTrim();
                if (ValidationDuplicataEditBus(onibus, onibusDB)) throw new Exception("Ônibus já se encontra registrado!");
                onibusDB.Modelo = onibus.Modelo;
                onibusDB.Marca = onibus.Marca;
                onibusDB.Renavam = onibus.Renavam;
                onibusDB.Placa = onibus.Placa;
                onibusDB.AnoFab = onibus.AnoFab;
                onibusDB.Cor = onibus.Cor;
                onibusDB.MotoristaId = onibus.MotoristaId;
                _bancoContext.Update(onibusDB);
                _bancoContext.SaveChanges();
                return onibusDB;
            }
            catch (Exception error) {
                throw new Exception(error.Message);
            }
        }

        public Onibus Delete(int? id) {
            try {
                Onibus onibusDB = ReturnOnibusPorId(id);
                if (onibusDB == null) throw new Exception("Desculpe, ônibus não encontrado!");
                _bancoContext.Onibus.Remove(onibusDB);
                _bancoContext.SaveChanges();
                return onibusDB;
            }
            catch (Exception error) {
                throw new Exception(error.Message);
            }
        }

        public bool ValidationDuplicataBus(Onibus onibus) {
            if (_bancoContext.Onibus.Any(x => x.Renavam == onibus.Renavam || x.Placa == onibus.Placa)) {
                return true;
            }
            return false;
        }

        public bool ValidationDuplicataEditBus(Onibus onibus, Onibus onibusDB) {
            if (_bancoContext.Onibus.Any(x => (x.Renavam == onibus.Renavam && onibus.Renavam != onibusDB.Renavam) ||
                (x.Placa == onibus.Placa && onibus.Placa != onibusDB.Placa))) {
                return true;
            }
            return false;
        }
    }
}
