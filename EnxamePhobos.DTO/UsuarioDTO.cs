using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public DateTime DataNascUsuario { get; set; }
        public string UsuarioTp { get; set; }
    }
}
