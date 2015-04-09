using MyParking.DAL.Models;
using MyParking.Framework;

namespace MyParking.DAL.ViewData
{
    public class UsuarioViewData
    {
        public Usuario Usuario { get; set; }
        public Result Resultado { get; set; }
        public bool FirstUsr { get; set; }
    }
}
