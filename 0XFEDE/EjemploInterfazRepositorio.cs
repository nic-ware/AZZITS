using Praxys.Fw.Dominio;

namespace Praxys.GP
{
	// Se declaran todas las intercafes, una interfaz es similar a un header de una libreria.
    public interface IAfiliadoRep : IRepositorio<Afiliado>
    {
        Afiliado Leer(int idAfiliado, OpcionesLeer<Afiliado> opciones = null);

        Afiliado LeerPorNumeroAfiliado(int idConvenio, string numeroAfiliado, OpcionesLeer<Afiliado> opciones = null);

        Afiliado LeerPorDocumento(int idConvenio, string tipoDocumento, int numeroDocumento, OpcionesLeer<Afiliado> opciones = null);

        AfiliadoCaracteristica CrearAfiliadoCaracteristica(Afiliado afiliado, CaracteristicaAfiliado caracteristica);

        AfiliadoPlan CrearAfiliadoPlan(Afiliado afiliado, Plan plan);

        AfiliadoPatologia CrearAfiliadoPatologia(Afiliado afiliado, Patologia patologia);

        AfiliadoObservado CrearAfiliadoObservado  (Afiliado afiliado);

        AfiliadoDatoAdicional CrearAfiliadoDatoAdicional(Afiliado afiliado, DatoAdicionalAfiliado daf);

        AfiliadoInformacionContacto CrearAfiliadoInformacionContacto(Afiliado afiliado);

        GrupoFamiliar CrearGrupoFamiliar (Afiliado afiliado);

        GrupoFamiliarAfiliado CrearGrupoFamiliarAfiliado(GrupoFamiliar grupoFamiliar, Afiliado afiliado);



    }
}
