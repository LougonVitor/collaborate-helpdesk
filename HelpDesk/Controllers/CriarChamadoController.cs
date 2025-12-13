using HelpDesk.Migrations;
using HelpDesk.Models;
using HelpDesk.Repositorios.Informacoes;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Controllers
{
    public class CriarChamadoController : Controller
    {
        private readonly IChamadoInformacoesRepositorio _chamadoInformacoesRepositorio;

        public CriarChamadoController(IChamadoInformacoesRepositorio chamadoInformacoesRepositorio)
        {
            _chamadoInformacoesRepositorio = chamadoInformacoesRepositorio;
        }

        public IActionResult Index()
        {
            List<TipoModel> Tipos = _chamadoInformacoesRepositorio.ListarTipos();

            List<CategoriaModel> Categorias = _chamadoInformacoesRepositorio.ListarCategoria();

            List<LocalizacaoModel> Localizacao = _chamadoInformacoesRepositorio.ListarLocalizacao();

            var model = new CriarChamadoModel
            {
                ListaTipo = Tipos,
                ListaCategoria = Categorias,
                ListaLocalizacao = Localizacao
            };


            return View(model);
        }

    }
}
