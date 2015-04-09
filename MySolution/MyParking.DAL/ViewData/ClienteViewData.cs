using System.Collections.Generic;
using MyParking.DAL.Models;
using MyParking.Framework;

namespace MyParking.DAL.ViewData
{
    public class ClienteViewData
    {
        public Cliente Cliente { get; set; }
        public Result Resultado { get; set; }

        public IEnumerable<CorVeiculo> ItensCor = new Services.CorService().CorToList();
        public IEnumerable<MarcaVeiculo> ItensMarca = new Services.MarcaService().MarcaToList();

        public ClienteViewData()
        {
            Cliente = new Cliente();
        }

        public ClienteViewData(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}
