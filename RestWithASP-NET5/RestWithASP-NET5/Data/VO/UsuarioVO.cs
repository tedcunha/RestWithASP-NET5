using System.Text.Json.Serialization;

namespace RestWithASP_NET5.Data.VO
{
    public class UsuarioVO
    {
        [JsonPropertyName("Codigo")]
        public int Id { get; set; }
        [JsonPropertyName("Primeiro_Nome")]
        public string Nome { get; set; }
        [JsonPropertyName("Sobre_Nome")]
        public string SobreNome { get; set; }
        [JsonPropertyName("Endereco")]
        public string Endereco { get; set; }
        [JsonPropertyName("Sexo")]
        public string Genero { get; set; }
    }
}
