using API_CRUD_FROTA.Models.ValidationModels;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD_FROTA.Models {
    public class Motorista {
        
        public int Id { get; set; }

        [Required (ErrorMessage = "Campo obrigatório!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "Campo inválido!")]
        public string? Rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [ValidationCPF(ErrorMessage = "Campo inválido!")]
        public string? Cpf { get; set; }

        [ValidationEmail(ErrorMessage = "E-mail inválido!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(9, ErrorMessage = "Campo inválido!")]
        [MaxLength(9, ErrorMessage = "Campo inválido!")]
        public string? Tel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [ValidationDateNascimento(ErrorMessage = "Campo inválido!")]
        public DateTime? DataNascimento { get; set; }

        public virtual List<Onibus>? Onibus { get; set; }

        public void MotoristaTrim() {
            Name = Name.Trim();
            Rg = Rg.Trim();
            Cpf = Cpf.Trim();
            Email = Email.Trim();
            Tel = Tel.Trim();
        }
    }
}
