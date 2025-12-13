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
                Chamado = new ChamadoModel(),
                ListaTipo = Tipos,
                ListaCategoria = Categorias,
                ListaLocalizacao = Localizacao
                
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult Criar(CriarChamadoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _chamadoRepositorio.CriarChamado(model.Chamado);

                    TempData["MensagemSucesso"] = "Chamado criado com sucesso";
                    return RedirectToAction("Index", "Home");
                }

                model.ListaTipo = _chamadoInformacoesRepositorio.ListarTipos();
                model.ListaCategoria = _chamadoInformacoesRepositorio.ListarCategoria();
                model.ListaLocalizacao = _chamadoInformacoesRepositorio.ListarLocalizacao();

                TempData["MensagemErro"] = "Preencha todos os campos corretamente";

                return View("Index", model);

                
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado: {err.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
