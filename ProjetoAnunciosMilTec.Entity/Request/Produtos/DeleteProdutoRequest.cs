using System.Text.Json.Serialization;

namespace ProjetoAnunciosMilTec.Core.Request.Produtos;

public class DeleteProdutoRequest
{
    [JsonIgnore]
    public long Id { get; set; }
}