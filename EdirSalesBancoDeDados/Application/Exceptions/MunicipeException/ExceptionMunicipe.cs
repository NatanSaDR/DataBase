namespace EdirSalesBancoDeDados.Application.Exceptions.MunicipeException
{
    public class ExceptionMunicipe : Exception
    {
        private static readonly Dictionary<TiposDeErrosMunicipeEnum, string> MensagensDeErro 
            = new Dictionary<TiposDeErrosMunicipeEnum, string>
        {
                {TiposDeErrosMunicipeEnum.NaoEncontrado, "Não encontrado na base de dados"},
                {TiposDeErrosMunicipeEnum.MunicipeInvalido, "Municipe inválido" },
                {TiposDeErrosMunicipeEnum.IdInvalido, "Id inválido" }
        };

        public TiposDeErrosMunicipeEnum TiposMensagens {  get; set; }

        public ExceptionMunicipe(TiposDeErrosMunicipeEnum tipoMensagem) 
            : base(MensagensDeErro.ContainsKey(tipoMensagem) ? MensagensDeErro[tipoMensagem] : "Erro desconhecido")
        {
            TiposMensagens = tipoMensagem;
        }
    }
}
