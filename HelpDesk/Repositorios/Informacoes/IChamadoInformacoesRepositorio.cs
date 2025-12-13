using HelpDesk.Enums;
using HelpDesk.Migrations;
using HelpDesk.Models;

namespace HelpDesk.Repositorios.Informacoes
{
    public interface IChamadoInformacoesRepositorio
    {
        public List<LocalizacaoModel> ListarLocalizacao();
        public List<TipoModel> ListarTipos();
        public List<CategoriaModel> ListarCategoria();
    }
}
