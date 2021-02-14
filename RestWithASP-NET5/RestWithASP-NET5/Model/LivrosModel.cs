using RestWithASP_NET5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5.Model
{
    [Table("livros")]
    public class LivrosModel : BaseEntity
    {
        [Column("Author")]
        public string Author { get; set; }
        [Column("Data_Cadastro")]
        public DateTime Data_Cadastro { get; set; }
        [Column("Preco")]
        public double Preco { get; set; }
        [Column("Titulo")]
        public string Titulo { get; set; }
    }
}
