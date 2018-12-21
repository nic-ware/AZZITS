using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Praxys.GP.Datos
{
    public class AfiliadoMapeo : EntityTypeConfiguration<Afiliado>
    {
        public AfiliadoMapeo()
        {
            ToTable("Afiliados", "Convenios");
			
			// Ejemplo clave primaria única.
            HasKey(o => o.IdAfiliado);
            
			// Ejemplo clave primaria compuesta:
			// HasKey(o => new { o.IdAfiliado, o.IdCaracteristicaAfiliado });
			
			// Recordar para los mapeos :
			// 		* HasMany -> Utilizado para establecer la relacion HasMany(Objeto).WithRequired(IdObjeto) || HasMany(Objeto).HasForeignKey(IdObjeto) 
			
			//		* HasOptional -> Utilizado para establecer la relacion HasOptional(Objeto).WithRequired(IdObjeto)
			// 		* WithMany -> Utilizado cuando la relacion es uno a uno o +
			// 		* Ignore -> Utilizado para ignorar propiedades y evitar su mapeo.
			// 		* Property -> Utilizado para determinar caracteristicas de las propiedades a Mapear, es decir determinar si es nulleable o no, etc.
			
			HasRequired(o => o.Convenio).WithMany().HasForeignKey(o => o.IdConvenio);
            HasOptional(o => o.Localidad).WithMany().HasForeignKey(o => o.Domicilio_IdLocalidad);
            Property(o => o.Nombre).IsRequired();
            HasMany(o => o.Caracteristicas).WithRequired(o => o.Afiliado);
            HasMany(o => o.Planes).WithRequired(o => o.Afiliado);
            HasMany(o => o.DatosAdicionales).WithRequired(o => o.Afiliado);
            HasMany(o => o.Patologias).WithRequired(o => o.Afiliado);
            HasMany(o => o.GrupoFamiliares).WithRequired(o => o.Afiliado);
            //HasOptional(o => o.GrupoFamiliar).WithRequired(o => o.Afiliado);
            Ignore(o => o.GrupoFamiliar);
            HasOptional(o => o.Observado).WithRequired(o => o.Afiliado);
            HasMany(o => o.InformacionContactos).WithRequired(o => o.Afiliado);
            Ignore(o => o.CaracteristicasHabilitadas);
            Property(o => o.SexoMapeo).IsOptional().HasColumnName("Sexo");
            Ignore(o => o.Sexo);
            Property(o => o.Suspendido).IsRequired();
            HasOptional(o => o.Delegacion).WithMany().HasForeignKey(o => o.IdDelegacion);
            Property(o => o.Fw_Edicion).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(o => o.His_FechaDesde).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(o => o.His_FechaHasta).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
