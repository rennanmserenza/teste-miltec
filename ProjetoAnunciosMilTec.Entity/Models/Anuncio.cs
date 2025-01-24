using System.ComponentModel.DataAnnotations;

namespace ProjetoAnunciosMilTec.Entity.Models
{
    public abstract class Anuncio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome deve ter pelo menos 5 caracteres.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter pelo menos 5 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de publicação não pode ser anterior à data de hoje.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Anuncio), nameof(ValidarDataPublicacao))]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "O valor deve ser maior ou igual a R$ 1,00.")]
        [Range(1.0, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a R$ 1,00.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Selecione uma cidade válida.")]
        public string Cidade { get; set; }

        public static ValidationResult ValidarDataPublicacao(DateTime data, ValidationContext context)
        {
            return data >= DateTime.Today
                ? ValidationResult.Success
                : new ValidationResult("A data de publicação não pode ser anterior à data de hoje.");
        }
    }
}