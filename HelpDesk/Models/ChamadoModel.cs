using HelpDesk.Enums;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class ChamadoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? TecnicoId { get; set; }

        public StatusEnum Status { get; set; }

        [Required(ErrorMessage = "Escolha um tipo válido")]
        [StringLength(30, ErrorMessage = "O tipo deve ter no máximo 30 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Escolha uma categoria válida")]
        [StringLength(30, ErrorMessage = "A categoria deve ter no máximo 30 caracteres")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Escolha uma urgência válida")]
        public UrgenciaEnum Urgencia { get; set; }

        [Required(ErrorMessage = "Informe a localização")]
        [StringLength(30, ErrorMessage = "A localização deve ter no máximo 30 caracteres")]
        public string Localizacao { get; set; }


        [Required(ErrorMessage = "Informe um título")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O título deve ter entre 5 a 30 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a descrição do chamado")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
        public string Descricao { get; set; }


        [RegularExpression(
            @"^(\d{1,3}\.){3}\d{1,3}$",
            ErrorMessage = "IP inválido"
        )]
        public string? Ip { get; set; }

        [StringLength(10, ErrorMessage = "O ramal deve ter no máximo 10 caracteres")]
        public string? Ramal { get; set; }

        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        [StringLength(30)]
        public string NomeUsuario { get; set; }


        public DateTime DataAbertura { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataFechamento { get; set; }
    }
}
