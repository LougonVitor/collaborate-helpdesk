namespace HelpDesk.Models
{
    public class CriarChamadoModel
    {
        public List<TipoModel> ListaTipo { get; set; }
        public List<CategoriaModel> ListaCategoria { get; set; }
        public List<LocalizacaoModel> ListaLocalizacao { get; set; }
    }
}
