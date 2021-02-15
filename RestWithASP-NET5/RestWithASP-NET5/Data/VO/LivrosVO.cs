using System;

namespace RestWithASP_NET5.Data.VO
{
    public class LivrosVO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public double Preco { get; set; }
        public string Titulo { get; set; }
    }
}
