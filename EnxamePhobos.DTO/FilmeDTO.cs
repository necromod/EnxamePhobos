using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DTO
{
    public class FilmeDTO
    {
        public int IdFilme { get; set; }
        public string TituloFilme { get; set; }
        public string ProdutoraFilme { get; set; }
        public string UrlImgFilme { get; set; }
        public string GeneroFilme_Id { get; set; }
        public string ClassificacaoFilme_Id { get; set; }

    }
}
