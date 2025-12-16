using HelpDesk.Models;
using HelpDesk.Repositorios.Chamados;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly IChamadoRepositorio _chamadoRepositorio;

        public ChamadosController(IChamadoRepositorio chamadoRepositorio)
        {
            _chamadoRepositorio = chamadoRepositorio; 
        }

        public IActionResult Index()
        {
            List<ChamadoModel> Chamados = _chamadoRepositorio.BuscarChamados(); 
            return View(Chamados);
        }

        public IActionResult Detalhes()
        {
            return View();
        }
    }
}
