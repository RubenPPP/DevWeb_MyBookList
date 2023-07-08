using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MyBookList.Models
{
    public class Books
    {
        public Books()
        {
            AuthorsList = new HashSet<Authors>();
            GenresList = new HashSet<Genres>();
            StatusList = new HashSet<Status>();
        }
        /// <summary>
        /// PK para a tabela Books; 
        /// </summary>
        // Continua a ser uma melhor prática usar um Id númerico em vez do identificador único de livros (ISBN)
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Identificador único de um Livro
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(13)]
        public string ISBN { get; set; }

        /// <summary>
        /// Título do Livro
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [MaxLength(50)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        /// <summary>
        /// Descrição do Livro
        /// </summary>
        [Display(Name = "Descrição")]
        [StringLength(3000)]
        public string Description { get; set; }

        /// <summary>
        /// Lista de géneros que correspondem ao Livro
        /// </summary>
        [AllowNull]
        [Display(Name = "Géneros")]
        public ICollection<Genres>? GenresList { get; set; }

        /// <summary>
        /// Rating médio atribuído ao Livro pelos utilizadores
        /// </summary>
        //[AllowNull]
        //public decimal Score { get; set; }

        /// <summary>
        /// Lista de autores do Livro
        /// </summary>
        [AllowNull]
        [Display(Name = "Autores")]
        public ICollection<Authors>? AuthorsList { get; set; }

        /// <summary>
        /// FK da editora do Livro
        /// </summary>
        [ForeignKey(nameof(Publisher))]
        [AllowNull]
        public int? PublisherFK { get; set; }

        /// <summary>
        /// Editora do Livro
        /// </summary>
        [AllowNull]
        [Display(Name = "Editora")]
        public Publishers? Publisher { get; set; }

        /// <summary>
        /// Lista de Estados dos Utilizadores quanto ao Livro
        /// </summary>
        [AllowNull]
        public ICollection<Status>? StatusList { get; set; }
    }
}