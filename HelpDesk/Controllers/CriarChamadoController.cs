using HelpDesk.Migrations;
using HelpDesk.Models;
using HelpDesk.Repositorios.Chamados;
using HelpDesk.Repositorios.Informacoes;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Controllers
{
    public class CriarChamadoController : Controller
    {
        private readonly IChamadoInformacoesRepositorio _chamadoInformacoesRepositorio;
        private readonly IChamadoRepositorio _chamadoRepositorio; 

        public CriarChamadoController(IChamadoInformacoesRepositorio chamadoInformacoesRepositorio, IChamadoRepositorio chamadoRepositorio)
        {
            _chamadoInformacoesRepositorio = chamadoInformacoesRepositorio;
            _chamadoRepositorio = chamadoRepositorio;
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

        [HttpPost]
        public IActionResult Criar(ChamadoModel chamado)
        {
            _chamadoRepositorio.CriarChamado(chamado);
            return RedirectToAction("Index", "Home");
        }

    }
}
