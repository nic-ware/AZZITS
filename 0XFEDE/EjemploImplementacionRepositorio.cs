using System;
using System.Linq;
using Praxys.Fw.Datos;
using Praxys.Fw.Dominio;

namespace Praxys.GP.Datos
{
    // Tener en cuenta que muchos de los metodos son implementaciones de Praxys.Fw
	
	public class AfiliadoRep : Repositorio<Afiliado>, IAfiliadoRep
    {
        public AfiliadoRep(IGPCtx ctx) : base(ctx)
        {
        }

        public AfiliadoCaracteristica CrearAfiliadoCaracteristica(Afiliado afiliado, CaracteristicaAfiliado caracteristica)
        {
            AfiliadoCaracteristica ac = DbContext.Set<AfiliadoCaracteristica>().Create();
            ac.Afiliado = afiliado;
            ac.CaracteristicaAfiliado = caracteristica;
            return ac;
        }

        public AfiliadoPlan CrearAfiliadoPlan(Afiliado afiliado, Plan plan)
        {
            AfiliadoPlan ap = DbContext.Set<AfiliadoPlan>().Create();
            ap.Afiliado = afiliado;
            ap.Plan = plan;
            return ap;
        }

        public AfiliadoPatologia CrearAfiliadoPatologia (Afiliado afiliado, Patologia patologia )
        {
            AfiliadoPatologia apa = DbContext.Set<AfiliadoPatologia>().Create();
            apa.Afiliado = afiliado;
            apa.Patologia = patologia;
            return apa;
        }

        public AfiliadoObservado CrearAfiliadoObservado (Afiliado afiliado)
        {
            AfiliadoObservado apa = DbContext.Set<AfiliadoObservado>().Create();
            apa.Afiliado = afiliado;
            apa.TipoObservacion = TiposObservacion.LasDrogasIndicadas;
            return apa;
        }

        public AfiliadoDatoAdicional CrearAfiliadoDatoAdicional(Afiliado afiliado, DatoAdicionalAfiliado daf)
        {
            AfiliadoDatoAdicional apa = DbContext.Set<AfiliadoDatoAdicional>().Create();
            apa.Afiliado = afiliado;
            apa.DatoAdicionalAfiliado = daf;
            apa.Orden = 1;
            apa.Valor = "1000";
            return apa;
        }

        public AfiliadoInformacionContacto CrearAfiliadoInformacionContacto (Afiliado afiliado)
        {
            AfiliadoInformacionContacto apa = DbContext.Set<AfiliadoInformacionContacto>().Create();
            apa.Afiliado = afiliado;
            apa.IdTipoMedioContacto = IdTiposMedioContacto.Email;
            apa.Uso = Usos.Particular;
            apa.Orden = 1;
            return apa;
        }


        public GrupoFamiliar CrearGrupoFamiliar (Afiliado afiliado)
        {
            GrupoFamiliar apa = DbContext.Set<GrupoFamiliar>().Create();
            apa.Afiliado = afiliado;
            apa.IdAfiliadoTitular = afiliado.IdAfiliado;
            return apa;
        }




        public Afiliado Leer(int idAfiliado, OpcionesLeer<Afiliado> opciones = null)
        {
            return LeerBase(o => o.IdAfiliado == idAfiliado, opciones);
        }

        public Afiliado LeerPorNumeroAfiliado(int idConvenio, string numeroAfiliado, OpcionesLeer<Afiliado> opciones = null)
        {
            return LeerBase(o => o.IdConvenio == idConvenio && o.NumeroAfiliado == numeroAfiliado, opciones);
        }

        public Afiliado LeerPorDocumento(int idConvenio, string tipoDocumento, int numeroDocumento, OpcionesLeer<Afiliado> opciones = null)
        {
            var afiliados = ConsultarBase(opciones, a => a.IdConvenio == idConvenio && a.NumeroDocumento == numeroDocumento);

            return afiliados.ToArray().FirstOrDefault(a => string.Equals((a.TipoDocumento + "").Trim(), (tipoDocumento + "").Trim(), StringComparison.InvariantCultureIgnoreCase));
        }

        public GrupoFamiliarAfiliado CrearGrupoFamiliarAfiliado(GrupoFamiliar grupoFamiliar, Afiliado afiliado)
        {
            GrupoFamiliarAfiliado apa = DbContext.Set<GrupoFamiliarAfiliado>().Create();
            apa.Afiliado = afiliado;
            apa.GrupoFamiliar = grupoFamiliar;
            apa.ParentescoI = GrupoFamiliarAfiliado.Parentesco.Hijo;
            apa.IdAfiliadoTitular = grupoFamiliar.IdAfiliadoTitular;
            return apa;
        }
    }
}
