using SistemaContatos.Models;

namespace SistemaContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);
        ContatoModel ListarPorId(int id);

        bool Apagar(int id);
    }
}
