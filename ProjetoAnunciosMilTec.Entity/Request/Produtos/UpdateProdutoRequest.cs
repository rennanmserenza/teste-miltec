using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoAnunciosMilTec.Core.Request.Produtos;

public class UpdateProdutoRequest : BaseFormRequest
{
    [JsonIgnore]
    public long Id { get; set; }

    [Required(ErrorMessage = "Selecione uma categoria válida.")]
    public string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione um modelo válido.")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione uma condição válida para o produto.")]
    public string Condicao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A quantidade deve ser no mínimo 1 unidade.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1 unidade.")]
    public int Quantidade { get; set; }
}