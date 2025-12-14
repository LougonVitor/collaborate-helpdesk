using HelpDesk.Helper;
using HelpDesk.Models;
using HelpDesk.Repositorios.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessionUser _sessaoUser;


        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ISessionUser sessaoUser)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessaoUser = sessaoUser;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos(); 
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.CriarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuario Criado com sucesso";
                    return RedirectToAction("Index");

                }
                TempData["MensagemErro"] = "Preencha todos os campos corretamente";
                return View(usuario);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, algo Deu errado: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.EditarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuario editado com sucesso";
                    return RedirectToAction("Index");
                }
                TempData["MensagemErro"] = "Preencha todos os campos corretamente";
                return View(usuario);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool IsApagado = _usuarioRepositorio.ApagarUsuario(id);
                if (IsApagado)
                {
                    TempData["MensagemSucesso"] = "Usuario apagado com suscesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Nao foi possivel apagar esse usuario tente novamente mais tarde";

                }

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado: {err.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
