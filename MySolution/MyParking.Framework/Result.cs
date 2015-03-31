using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParking.Framework
{
    public class Result
    {
        public enum TipoResult
        {
            OK = 1,
            Error = 2,
            Alert = 3
        };

        public string mensagem { get; set; }
        public TipoResult tipoResultado { get; set; }

        public Result(string mensagem, TipoResult tipoResult)
        {
            this.mensagem = mensagem;
            this.tipoResultado = tipoResult;
        }

        public void AdicionaMensagem(string mensagem, TipoResult tipoResultado)
        {
            this.mensagem = mensagem;
            this.tipoResultado = tipoResultado;
        }
    }
}
