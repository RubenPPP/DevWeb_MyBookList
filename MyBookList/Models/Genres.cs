using System.ComponentModel.DataAnnotations;

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
        public string Genre { get; set; }
    }
}
