using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyBookList.Models
{
    public class Members
    {
        public Members()
        {
            StatusList = new HashSet<Status>();
        }

        /// <summary>
        /// PK para a tabela Users
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Username de um Utilizador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [MaxLength(20)]
        [Display(Name = "Nome do Usuário")]
        public string Username { get; set; }

        /// <summary>
        /// Estado de privilégios de um Utilizador (Utilizador, Ajudante, Administrador, ...)
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Estado do Usuário")]
        public string Status { get; set; }

        /// <summary>
        /// País de um Utilizador
        /// </summary>
        [AllowNull]
        [Display(Name = "País")]
        public string? Country { get; set; }

        /// <summary>
        /// Data de Nascimento de um Utilizador
        /// </summary>
        // public string Birthdate { get; set; }


        /// <summary>
        /// Email do utilizador
        /// </summary>
        [EmailAddress(ErrorMessage = "O {0} não está corretamente escrito")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[a-z._0-9]+@gmail.com", ErrorMessage = "O {0} tem de ser do GMail")]
        [StringLength(40)]
        public string Email { get; set; }


        /// <summary>
        /// Lista de Estados atribuidos a Livros interagidos por um Utilizador
        /// </summary>
        [AllowNull]
        [Display(Name = "Lista de Estados")]
        public ICollection<Status>? StatusList { get; set; }


        // ************************************************
        /// <summary>
        /// atributo para efetuar a ligação entre a base 
        /// de dados do 'negócio' e a base de dados da autenticação
        /// </summary>
        public string UserId { get; set; }
        // ************************************************
    }
}