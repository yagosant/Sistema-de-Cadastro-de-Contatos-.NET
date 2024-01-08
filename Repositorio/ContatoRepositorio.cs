using SistemaContatos.Data;
using SistemaContatos.Models;

namespace SistemaContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
           _bancoContext.Contatos.Add(contato);
           _bancoContext.SaveChanges();

            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoModel = ListarPorId(id);

            if (contatoModel == null)  throw new System.Exception("Não foi possível Excluir o contato");

            _bancoContext.Contatos.Remove(contatoModel);
            _bancoContext.SaveChanges();

            return true;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoModel = ListarPorId(contato.Id);

            if (contatoModel == null) throw new System.Exception("Não foi possível alterar o contato");
            
            contatoModel.Nome = contato.Nome;
            contatoModel.Email = contato.Email;
            contatoModel.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoModel);
            _bancoContext.SaveChanges();
            
            return contatoModel;   
        }

        public List<ContatoModel> BuscarTodos()
        {

            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
