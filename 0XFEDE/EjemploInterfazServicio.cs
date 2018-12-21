using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Praxys.Fw.Dominio;

namespace Praxys.GP.Servicios
{
    public interface IAfiliadosSvc
    {
        ResultadoOperacionLeerAfiliado LeerPorIdAfiliado(int idAfiliado);

        ResultadoOperacionLeerAfiliado LeerPorNumeroAfiliado(int idConvenio, string numeroAfiliado);

        ResultadoOperacionLeerAfiliado LeerPorTipoYNumeroDocumento(int idConvenio, string tipoDocumento, int numeroDocumento);

    }

    public class ResultadoOperacionLeerAfiliado : ResultadoOperacion
    {
        public Afiliado Afiliado { get; set; }
    }

}
