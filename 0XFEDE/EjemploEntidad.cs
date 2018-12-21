
// Modelo Entidad

using System;
using System.Collections.Generic;
using System.Linq;

namespace // MyApp
{

	// Ejemplo enumeration
    #region Enumerations
    public enum Sexos
    {
		// Esto está realizado con Praxys.Fw , modificar para mapear sobre EntityFW.
        [MapearEnum("?", "Inválido")] Invalido = -1,
        [MapearEnum(" ", "Sin asignar")] SinAsignar = 0,
    }
    #endregion Enumerations

	
	// Entidad que implementa interfaces : IConcurrenciaOptimista, ITemporal, IUsuarioEdicion ,IBajaLogica
    public class Afiliado : IConcurrenciaOptimista, ITemporal, IUsuarioEdicion ,IBajaLogica
	
    {
        #region Propiedades

        public virtual string Nombre { get; set; }

        public virtual string NumeroAfiliado { get; set; }

        public virtual string TipoDocumento { get; set; }

        public virtual int? NumeroDocumento { get; set; }

        public virtual DateTime? FechaNacimiento { get; set; }

		
		// Ejemplo definicion propiedad vinculada a una enumeracion.
        public virtual string PropMapeo { get; set; }

        public virtual Props Prop
        {
            get => EnumUtil.Desmapear(PropMapeo, Props.Invalido);
            set => PropMapeo = EnumUtil.Mapear(value);
        }
        public Guid? CreadoPor { get; set; }

        public virtual string Domicilio_Calle { get; set; }

        public virtual string Domicilio_Numero { get; set; }

        public virtual string Domicilio_Observaciones { get; set; }

        public virtual string Domicilio_CodigoPostal { get; set; }

        public virtual int? Domicilio_IdLocalidad { get; set; }

        public virtual Localidad Localidad { get; set; }

        #endregion

        #region Asociaciones

        public virtual ICollection<AfiliadoCaracteristica> Caracteristicas { get; set; }

        public virtual ICollection <AfiliadoPlan> Planes { get; set; }
		
        #endregion

        #region Propiedades derivadas

        public ICollection<AfiliadoCaracteristica> CaracteristicasHabilitadas
        {
            get
            {
                return Caracteristicas?.Where(c => c.Fw_FechaBaja == null).ToList();
            }
        }


        #endregion 

		// Interfaces implementadas.
		
        #region Interfaces

        public virtual DateTime? Fw_FechaBaja { get; set; }

        public virtual byte[] Fw_Edicion { get; set; }

        public virtual DateTime His_FechaDesde { get; set; }

        public virtual DateTime His_FechaHasta { get; set; }

        public virtual int? Fw_IdUsuarioEdicion { get; set; }
        
        #endregion
    }
}
