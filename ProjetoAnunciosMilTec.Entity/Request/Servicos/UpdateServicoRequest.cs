using System.Text.Json.Serialization;

namespace ProjetoAnunciosMilTec.Core.Request.Servicos;

public class UpdateServicoRequest : BaseFormRequest
{
    [JsonIgnore]
    public long Id { get; set; }
}