using System.Text.Json.Serialization;

namespace ProjetoAnunciosMilTec.Core.Request.Servicos;

public class DeleteServicoRequest
{
    [JsonIgnore]
    public long Id { get; set; }
}