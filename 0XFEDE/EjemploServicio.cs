using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Praxys.Fw.Dominio;


namespace Praxys.GP.Servicios
{
    public class AfiliadosSvc : IAfiliadosSvc
    {
        private readonly IGPCtx _ctx;
        private readonly IAfiliadoRep _afiliadoRep;
        private readonly IFinanciadorAutentificado _financiador;

        public AfiliadosSvc(IGPCtx ctx,
            IAfiliadoRep afiliadoRep,
            IFinanciadorAutentificado financiador)
        {
            _ctx = ctx;
            _afiliadoRep = afiliadoRep;
            _financiador = financiador;

        }


        public ResultadoOperacionLeerAfiliado LeerPorIdAfiliado(int idAfiliado)
        {
            ResultadoOperacionLeerAfiliado res = new ResultadoOperacionLeerAfiliado();

            Afiliado afiliado = _afiliadoRep.Leer(idAfiliado);

            if (afiliado == null || !_financiador.EsConvenioAutorizado(afiliado.IdConvenio))
            {
                res.AgregarError($"No existe el afiliado con IdAfiliado:{idAfiliado}");
                return res;
            }

            res.Afiliado = afiliado;
            return res;
        }

        public ResultadoOperacionLeerAfiliado LeerPorNumeroAfiliado(int idConvenio, string numeroAfiliado)
        {
            ResultadoOperacionLeerAfiliado res = new ResultadoOperacionLeerAfiliado();

            if (!_financiador.EsConvenioAutorizado(idConvenio))
            {
                res.AgregarError($"No existe el Afiliado con Número de Afiliado: [{numeroAfiliado}] en el convenio Id:[{idConvenio}]");
                return res;
            }

            Afiliado afiliado = _afiliadoRep.LeerPorNumeroAfiliado(idConvenio, numeroAfiliado);
            if (afiliado == null)
            {
                res.AgregarError($"No existe el Afiliado con Número de Afiliado: [{numeroAfiliado}] en el convenio Id:[{idConvenio}]");
                return res;
            }

            res.Afiliado = afiliado;
            return res;
        }

        public ResultadoOperacionLeerAfiliado LeerPorTipoYNumeroDocumento(int idConvenio, string tipoDocumento, int numeroDocumento)
        {
            ResultadoOperacionLeerAfiliado res = new ResultadoOperacionLeerAfiliado();

            if (!_financiador.EsConvenioAutorizado(idConvenio))
            {
                res.AgregarError($"No existe el Afiliado con Número de Documento: [{tipoDocumento}] [{numeroDocumento}] en el convenio Id:[{idConvenio}]");
                return res;
            }

            Afiliado afiliado = _afiliadoRep.LeerPorDocumento(idConvenio, tipoDocumento, numeroDocumento);
            if (afiliado == null)
            {
                res.AgregarError($"No existe el Afiliado con Número de Documento: [{tipoDocumento}] [{numeroDocumento}] en el convenio Id:[{idConvenio}]");
                return res;
            }

            res.Afiliado = afiliado;
            return res;
        }
    }
}
