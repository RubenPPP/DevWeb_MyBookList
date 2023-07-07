using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyBookList.Models
{
    public class Publishers
    {
        public Publishers()
        {
            BookList = new HashSet<Books>();
        }
        /// <summary>
        /// PK da tabela Publishers
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome de uma Editora
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Descrição de uma Editora
        /// </summary>
        [AllowNull]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        /// <summary>
        /// Lista de Livros editados por uma Editora
        /// </summary>
        [AllowNull]
        [Display(Name = "Livros")]
        public ICollection<Books>? BookList { get; set; }
    }
}