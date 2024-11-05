namespace EdirSalesBancoDeDados.Domain
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
        public int UsuarioCadastroId { get; set; } // Referência ao ID do usuário
        public int UsuarioAlteracaoId { get; set; } // Referência ao ID do usuário
    }
}
