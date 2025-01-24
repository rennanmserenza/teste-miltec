using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IProdutoService : IAnuncioService<Produto>
{
    new Task CriarAsync(Produto produto);
}