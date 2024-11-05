namespace EdirSalesBancoDeDados.Domain
{
    public class Solicitacao : EntityBase
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        public ICollection<Grupo>? Grupos { get; set; } = new List<Grupo>(); // Grupo opcional
        public ICollection<Municipe> Municipes { get; set; } = new List<Municipe>();
    }
}
