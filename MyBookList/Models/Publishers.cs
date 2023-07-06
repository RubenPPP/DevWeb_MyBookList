using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; }

        /// <summary>
        /// Descrição de uma Editora
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista de Livros editados por uma Editora
        /// </summary>
        public ICollection<Books> BookList { get; set; }
    }
}