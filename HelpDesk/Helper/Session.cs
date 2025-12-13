using HelpDesk.Models;
using Newtonsoft.Json;

namespace HelpDesk.Helper
{
    public class Session : ISessionUser
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
           _httpContext = httpContext;     
        }

        public void ApagarSessao()
        {
            _httpContext.HttpContext.Session.Remove("SessaoDoUsuario");
        }

        public UsuarioModel BuscarSessao()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("SessaoDoUsuario");

            if(sessaoUsuario == null)
            {
                return null;
            } else
            {

               return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            }
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string usuarioSession = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("SessaoDoUsuario", usuarioSession);
        }
    }
}
