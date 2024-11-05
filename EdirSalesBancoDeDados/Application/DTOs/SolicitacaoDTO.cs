using EdirSalesBancoDeDados.Domain;

namespace EdirSalesBancoDeDados.Application.DTOs
{
    public class SolicitacaoDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        public List<int>? IdGrupos { get; set; } = new List<int>(); // Grupo opcional
        public List<int>? IdMunicipes { get; set; } = new List<int>(); // Grupo opcional
    }
}
