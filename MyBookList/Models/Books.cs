using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// PK para a tabela Books; Identificador único de um Livro
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression("[0-9]{13}", ErrorMessage = "O formato deve ser do tipo ISBN-13")]
        public string ISBN { get; set; }

        /// <summary>
        /// Título do Livro
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [MaxLength(30)]
        public string Title { get; set; }

        /// <summary>
        /// Descrição do Livro
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista de géneros que correspondem ao Livro
        /// </summary>
        public ICollection<Genres> GenresList { get; set; }

        /// <summary>
        /// Rating médio atribuído ao Livro pelos utilizadores
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// Lista de autores do Livro
        /// </summary>
        public ICollection<Authors> AuthorsList { get; set; }

        /// <summary>
        /// FK da editora do Livro
        /// </summary>
        [ForeignKey(nameof(Publisher))]
        [Display(Name = "Editora")]
        public int PublisherFK { get; set; }

        /// <summary>
        /// Editora do Livro
        /// </summary>
        public Publishers Publisher { get; set; }

        /// <summary>
        /// Lista de Estados dos Utilizadores quanto ao Livro
        /// </summary>
        public ICollection<Status> StatusList { get; set; }
    }
}