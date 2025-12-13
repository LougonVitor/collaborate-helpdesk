using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpDesk.Models
{
    public class CriarChamadoModel
    {
        [ValidateNever]
        public List<TipoModel> ListaTipo { get; set; }

        [ValidateNever]
        public List<CategoriaModel> ListaCategoria { get; set; }

        [ValidateNever]
        public List<LocalizacaoModel> ListaLocalizacao { get; set; }
        public ChamadoModel Chamado { get; set; }
    }
}
