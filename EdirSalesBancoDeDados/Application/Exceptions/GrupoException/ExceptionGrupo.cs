using Microsoft.Extensions.WebEncoders.Testing;

namespace EdirSalesBancoDeDados.Application.Exceptions.GrupoExeption
{
    public class ExceptionGrupo : Exception
    {
        private static readonly Dictionary<TiposDeErrosGrupoEnum, string> MensagensDeErro = new Dictionary<TiposDeErrosGrupoEnum, string> 
        {
            { TiposDeErrosGrupoEnum.IdNotFound, "Não encontrado"}
        };

        public TiposDeErrosGrupoEnum TipoErro {  get; set; }

        public ExceptionGrupo(TiposDeErrosGrupoEnum tipoErro)
            : base(MensagensDeErro.ContainsKey(tipoErro) ? MensagensDeErro[tipoErro] : "Erro desconhecido")
        {
            TipoErro = tipoErro;
        }

    }
}
