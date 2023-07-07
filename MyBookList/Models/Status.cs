﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBookList.Models
{
    public class Status
    {
        /// <summary>
        /// PK de um utilizador a que refere o estado
        /// </summary>
        [Key, Column(Order = 0)]
        [Required, ForeignKey(nameof(Member))]
        public int MemberFK { get; set; }
        public Members Member { get; set; }

        /// <summary>
        /// PK de um livro a que refere o estado
        /// </summary>
        [Key, Column(Order = 1)]
        [Required, ForeignKey(nameof(Book))]
        public int BookFK { get; set; }
        public Books Book { get; set; }

        /// <summary>
        /// Estado atual da relação entre o utilizador e o livro (Já leu; Planeado para ler; Desistiu de ler)
        /// </summary>
        [Required(ErrorMessage = "É obrigatório a seleção de um estado!")]
        public string State { get; set; }

        /// <summary>
        /// Classificação dada pelo utilizador ao livro (0-10)
        /// </summary>
        public decimal ScoreRating { get; set; }

        /// <summary>
        /// Crítica dada pelo utilizador ao livro
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Data da crítica dada pelo utiliador ao livro
        /// </summary>
        public string ReviewDate { get; set; }
    }
}