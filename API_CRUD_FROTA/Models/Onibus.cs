using API_CRUD_FROTA.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD_FROTA.Models {
    public class Onibus {

        public int Id { get; set; }

        public int? MotoristaId { get; set; }

        [Required (ErrorMessage = "Campo obrigatório!")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string? AnoFab { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string? Renavam { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int? Assentos { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string? Placa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public CorBus Cor { get; set; }

        public virtual Motorista? Motorista { get; set; }

        public string? ReturnCorBus() {
            if (Cor == CorBus.Branco) {
                return "Branco";
            }
            else if (Cor == CorBus.Azul) {
                return "Azul";
            }
            else if (Cor == CorBus.Verde) {
                return "Verde";
            }
            else if (Cor == CorBus.Preto) {
                return "Preto";
            }
            else if (Cor == CorBus.Prata) {
                return "Prata";
            }
            else if (Cor == CorBus.Vermelho) {
                return "Vermelho";
            }
            else if (Cor == CorBus.Cinza) {
                return "Cinza";
            }
            else if (Cor == CorBus.Roxo) {
                return "Roxo";
            }
            else {
                return "Não encontramos a cor!";
            }

        }

        public void OnibusTrim() {
            Modelo = Modelo.Trim();
            Marca = Marca.Trim();
            Renavam = Renavam.Trim();
            AnoFab = AnoFab.Trim();
            Placa = Placa.Trim();
        }
    }
}
