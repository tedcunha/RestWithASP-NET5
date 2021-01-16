using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5.Model
{
    [Table("cadusuario")]
    public class UsuarioModel
    {
        [Column("Id")]
        public int Id { get; set; }
     
        [Column("Nome")]
        public string Nome { get; set; }
        
        [Column("SobreNome")]
        public string SobreNome { get; set; }
        
        [Column("Endereco")]
        public string Endereco { get; set; }
        
        [Column("Genero")]
        public string Genero { get; set; }
    }
}
