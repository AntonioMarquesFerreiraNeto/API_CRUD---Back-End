using System.ComponentModel.DataAnnotations;

namespace API_CRUD_FROTA.Models.ValidationModels {
    public class ValidationDateNascimento : ValidationAttribute {
        public override bool IsValid(object? value) {
            return ValidarDataNascimento(value.ToString());
        }

        public bool ValidarDataNascimento(string value) {
            DateTime dataNascimento = DateTime.Parse(value).Date;
            DateTime dataAtual = DateTime.Now.Date;

            long dias = (int)dataAtual.Subtract(dataNascimento).TotalDays;
            int idade = (int)dias / 365;

            if (dataNascimento > dataAtual || idade > 132) {
                return false;
            } 
            return true;
        }
    }
}

