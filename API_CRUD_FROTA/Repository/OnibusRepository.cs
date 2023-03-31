using API_CRUD_FROTA.Data;
using API_CRUD_FROTA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_FROTA.Repository {
    public class OnibusRepository : IOnibusRepository {

        private readonly BancoContext _bancoContext;

        public OnibusRepository(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public Onibus ReturnOnibusPorId(int? id) {
            return _bancoContext.Onibus.FirstOrDefault(x => x.Id == id);
        }

        public Onibus AddOnibus([FromBody] Onibus onibus) {
            try {
                onibus.OnibusTrim();
                _bancoContext.Onibus.Add(onibus);
                _bancoContext.SaveChanges();
                return onibus;
            }
            catch (Exception error) {
                throw new Exception(error.Message);
            }
        }

        public List<Onibus> ReturnListOnibus() {
            return _bancoContext.Onibus.ToList();
        }

        public Onibus UpdateOnibus(Onibus onibus) {
            try {
                Onibus onibusDB = ReturnOnibusPorId(onibus.Id);
                if (onibusDB == null) throw new Exception("Desculpe, ônibus não encontrado!");
                
                onibusDB.Modelo = onibus.Modelo;
                onibusDB.Marca = onibus.Marca;
                onibusDB.Renavam = onibus.Renavam;
                onibusDB.Placa = onibus.Placa;
                onibusDB.AnoFab = onibus.AnoFab;
                onibusDB.Cor = onibus.Cor;

                onibusDB.OnibusTrim();
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
    }
}
