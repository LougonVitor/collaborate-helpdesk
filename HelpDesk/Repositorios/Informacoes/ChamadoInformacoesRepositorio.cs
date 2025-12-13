using HelpDesk.Data;
using HelpDesk.Models;

namespace HelpDesk.Repositorios.Informacoes
{
    public class ChamadoInformacoesRepositorio : IChamadoInformacoesRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ChamadoInformacoesRepositorio(BancoContext BancoContext)
        {
            _bancoContext = BancoContext;
        }
        public List<CategoriaModel> ListarCategoria()
        {
            return _bancoContext.Categorias.ToList();
        }

        public List<LocalizacaoModel> ListarLocalizacao()
        {
            return _bancoContext.Localizacoes.ToList();
        }

        public List<TipoModel> ListarTipos()
        {
            return _bancoContext.Tipos.ToList();
        }
    }
}
