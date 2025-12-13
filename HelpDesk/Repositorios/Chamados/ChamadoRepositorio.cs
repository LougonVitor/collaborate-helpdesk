using HelpDesk.Data;
using HelpDesk.Helper;
using HelpDesk.Models;

namespace HelpDesk.Repositorios.Chamados
{
    public class ChamadoRepositorio : IChamadoRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly ISessionUser _sessionUser;

        public ChamadoRepositorio(BancoContext BancoContext, ISessionUser sessionUser)
        {
            _bancoContext = BancoContext;
            _sessionUser = sessionUser;
        }

        public ChamadoModel CriarChamado(ChamadoModel chamado)
        {
            chamado.DataAbertura = DateTime.Now;
            chamado.Status = Enums.StatusEnum.aberto;
            chamado.DataAtualizacao = DateTime.Now;
            chamado.UsuarioId = 1;
           _bancoContext.Chamados.Add(chamado);
           _bancoContext.SaveChanges();
           return chamado;
        }

    }
}
