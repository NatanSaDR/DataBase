using FluentMigrator.Runner;

namespace EdirSalesBancoDeDados.Application.DTOs.ViewDetails
{
    public class DetalheGrupoDTO
    {
        public int IdGrupo { get; set; }
        public string NomeGrupo { get; set; }
        public List<DetalheMunicipeGrupo> Municipes { get; set; } = new List<DetalheMunicipeGrupo>();
    }
}
