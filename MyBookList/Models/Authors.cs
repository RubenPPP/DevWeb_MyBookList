using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyBookList.Models
{
    public class Authors
    {
        public Authors()
        {
            BookList = new HashSet<Books>();
        }

        /// <summary>
        /// PK para a tabela Authors
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome de um Autor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Biografia de um Autor
        /// </summary>
        [AllowNull]
        [Display(Name = "Biografia")]
        [StringLength(2000)]
        public string Biography { get; set; }

        /// <summary>
        /// Data de Nascimento de um Autor
        /// </summary>
        // public string Birthdate { get; set; }

        /// <summary>
        /// Lista de Livros escritos por um Autor
        /// </summary>
        [AllowNull]
        [Display(Name = "Livros")]
        public ICollection<Books>? BookList { get; set; }
    }
}