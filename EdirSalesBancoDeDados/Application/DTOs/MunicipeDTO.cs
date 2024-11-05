using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EdirSalesBancoDeDados.Application.DTOs
{
    public class MunicipeDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime Aniversario { get; set; } 
        public string Lougradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Observacao { get; set; }
        public string Email { get; set; }
        public List<int> GruposId { get; set; } = new List<int>();
    }
}
