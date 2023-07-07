using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyBookList.Models
{
    public class Genres
    {
        /// <summary>
        /// PK da tabela Genres
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome ou especificação de um género
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Género")]
        public string Genre { get; set; }

        /// <summary>
        /// Lista de livros com o respetivo género
        /// </summary>
        [AllowNull]
        public ICollection<Books>? BooksList { get; set; }
    }
}
