using System.ComponentModel.DataAnnotations;

namespace ProjetoAnunciosMilTec.Entity.Models;

public class Produto : Anuncio
{
    [Required(ErrorMessage = "Selecione uma categoria v�lida.")]
    public string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione um modelo v�lido.")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione uma condi��o v�lida para o produto.")]
    public string Condicao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A quantidade deve ser no m�nimo 1 unidade.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no m�nimo 1 unidade.")]
    public int Quantidade { get; set; }
}