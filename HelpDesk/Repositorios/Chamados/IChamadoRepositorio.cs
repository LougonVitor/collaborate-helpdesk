using HelpDesk.Models;

namespace HelpDesk.Repositorios.Chamados
{
    public interface IChamadoRepositorio
    {
        public ChamadoModel CriarChamado(ChamadoModel chamado);
    }
}
