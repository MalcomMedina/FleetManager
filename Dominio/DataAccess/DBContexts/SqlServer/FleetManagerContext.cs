using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dominio.DataAccess.Entities;
using Dominio.DataAccess.AdaptableContext;
using System.Threading.Tasks;

#nullable disable

namespace Dominio.DataAccess.DBContexts
{
    public partial class FleetManagerContext : DbContext, IStrategyAdaptableContext
    {
        public FleetManagerContext()
        {
        }

        public FleetManagerContext(DbContextOptions<FleetManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbHistoricoDeSesione> TbHistoricoDeSesiones { get; set; }
        public virtual DbSet<TbPantalla> TbPantallas { get; set; }
        public virtual DbSet<TbPantallasRole> TbPantallasRoles { get; set; }
        public virtual DbSet<TbRole> TbRoles { get; set; }
        public virtual DbSet<TbTokensUsuario> TbTokensUsuarios { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }
        public virtual DbSet<TbUsuariosRole> TbUsuariosRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbHistoricoDeSesione>(entity =>
            {
                entity.HasKey(e => e.InseId)
                    .HasName("PK_Vent_tbHistoricoDeSesiones_depe_Id");

                entity.ToTable("tbHistoricoDeSesiones", "Seg");

                entity.Property(e => e.InseId)
                    .ValueGeneratedNever()
                    .HasColumnName("inse_Id");

                entity.Property(e => e.InseAccion).HasColumnName("inse_Accion");

                entity.Property(e => e.InseFechaCrea)
                    .HasColumnType("datetime")
                    .HasColumnName("inse_FechaCrea");

                entity.Property(e => e.InseUsuarioCrea).HasColumnName("inse_UsuarioCrea");

                entity.HasOne(d => d.InseUsuarioCreaNavigation)
                    .WithMany(p => p.TbHistoricoDeSesiones)
                    .HasForeignKey(d => d.InseUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Vent_tbUsuarios_tbHistoricoDeSesiones_pedi_Id");
            });

            modelBuilder.Entity<TbPantalla>(entity =>
            {
                entity.HasKey(e => e.PlaId)
                    .HasName("PK_Seg_tbPantallas_pla_Id");

                entity.ToTable("tbPantallas", "Seg");

                entity.Property(e => e.PlaId)
                    .ValueGeneratedNever()
                    .HasColumnName("pla_Id");

                entity.Property(e => e.PlaDescripcion)
                    .HasMaxLength(50)
                    .HasColumnName("pla_Descripcion");

                entity.Property(e => e.PlaEsActivo).HasColumnName("pla_EsActivo");

                entity.Property(e => e.PlaFechaCrea)
                    .HasColumnType("datetime")
                    .HasColumnName("pla_FechaCrea");

                entity.Property(e => e.PlaFechaModifica)
                    .HasColumnType("datetime")
                    .HasColumnName("pla_FechaModifica");

                entity.Property(e => e.PlaRouteValue)
                    .HasMaxLength(50)
                    .HasColumnName("pla_RouteValue");

                entity.Property(e => e.PlaUsuarioCrea).HasColumnName("pla_UsuarioCrea");

                entity.Property(e => e.PlaUsuarioModifica).HasColumnName("pla_UsuarioModifica");

                entity.HasOne(d => d.PlaUsuarioCreaNavigation)
                    .WithMany(p => p.TbPantallaPlaUsuarioCreaNavigations)
                    .HasForeignKey(d => d.PlaUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbPantallas_pla_UsuarioCrea");

                entity.HasOne(d => d.PlaUsuarioModificaNavigation)
                    .WithMany(p => p.TbPantallaPlaUsuarioModificaNavigations)
                    .HasForeignKey(d => d.PlaUsuarioModifica)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbPantallas_pla_UsuarioModifica");
            });

            modelBuilder.Entity<TbPantallasRole>(entity =>
            {
                entity.HasKey(e => e.PlarolId)
                    .HasName("PK_Seg_tbPantallasRoles_plarol_Id");

                entity.ToTable("tbPantallasRoles", "Seg");

                entity.Property(e => e.PlarolId)
                    .ValueGeneratedNever()
                    .HasColumnName("plarol_Id");

                entity.Property(e => e.PlaId).HasColumnName("pla_Id");

                entity.Property(e => e.PlarolEsActivo).HasColumnName("plarol_EsActivo");

                entity.Property(e => e.PlarolFechaCrea)
                    .HasColumnType("datetime")
                    .HasColumnName("plarol_FechaCrea");

                entity.Property(e => e.PlarolFechaModifica)
                    .HasColumnType("datetime")
                    .HasColumnName("plarol_FechaModifica");

                entity.Property(e => e.PlarolUsuarioCrea).HasColumnName("plarol_UsuarioCrea");

                entity.Property(e => e.PlarolUsuarioModifica).HasColumnName("plarol_UsuarioModifica");

                entity.Property(e => e.RolId).HasColumnName("rol_Id");

                entity.HasOne(d => d.Pla)
                    .WithMany(p => p.TbPantallasRoles)
                    .HasForeignKey(d => d.PlaId)
                    .HasConstraintName("FK_Seg_tbPantallas_tbPantallasRoles_pla_Id");

                entity.HasOne(d => d.PlarolUsuarioCreaNavigation)
                    .WithMany(p => p.TbPantallasRolePlarolUsuarioCreaNavigations)
                    .HasForeignKey(d => d.PlarolUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbPantallasRoles_plarol_UsuarioCrea");

                entity.HasOne(d => d.PlarolUsuarioModificaNavigation)
                    .WithMany(p => p.TbPantallasRolePlarolUsuarioModificaNavigations)
                    .HasForeignKey(d => d.PlarolUsuarioModifica)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbPantallasRoles_plarol_UsuarioModifica");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbPantallasRoles)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Seg_tbRoles_tbPantallasRoles_usu_Id");
            });

            modelBuilder.Entity<TbRole>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK_Seg_Roles_rol_Id");

                entity.ToTable("tbRoles", "Seg");

                entity.Property(e => e.RolId)
                    .ValueGeneratedNever()
                    .HasColumnName("rol_Id");

                entity.Property(e => e.RolDescripcion)
                    .HasMaxLength(50)
                    .HasColumnName("rol_Descripcion");

                entity.Property(e => e.RolEsActivo).HasColumnName("rol_EsActivo");

                entity.Property(e => e.RolFechaCrea)
                    .HasColumnType("datetime")
                    .HasColumnName("rol_FechaCrea");

                entity.Property(e => e.RolFechaModifica)
                    .HasColumnType("datetime")
                    .HasColumnName("rol_FechaModifica");

                entity.Property(e => e.RolUsuarioCrea).HasColumnName("rol_UsuarioCrea");

                entity.Property(e => e.RolUsuarioModifica).HasColumnName("rol_UsuarioModifica");

                entity.HasOne(d => d.RolUsuarioCreaNavigation)
                    .WithMany(p => p.TbRoleRolUsuarioCreaNavigations)
                    .HasForeignKey(d => d.RolUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbRoles_rol_UsuarioCrea");

                entity.HasOne(d => d.RolUsuarioModificaNavigation)
                    .WithMany(p => p.TbRoleRolUsuarioModificaNavigations)
                    .HasForeignKey(d => d.RolUsuarioModifica)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbRoles_rol_UsuarioModifica");
            });

            modelBuilder.Entity<TbTokensUsuario>(entity =>
            {
                entity.HasKey(e => e.TknsId)
                    .HasName("PK_Seg_tbTokensUsuarios_tkns_Id");

                entity.ToTable("tbTokensUsuarios", "Seg");

                entity.Property(e => e.TknsId)
                    .ValueGeneratedNever()
                    .HasColumnName("tkns_Id");

                entity.Property(e => e.TknsDescripcion)
                    .IsRequired()
                    .HasColumnName("tkns_Descripcion");

                entity.Property(e => e.TknsFechaExpiracion)
                    .HasColumnType("datetime")
                    .HasColumnName("tkns_FechaExpiracion");

                entity.Property(e => e.TknsPertenceUsuario).HasColumnName("tkns_PertenceUsuario");

                entity.HasOne(d => d.TknsPertenceUsuarioNavigation)
                    .WithMany(p => p.TbTokensUsuarios)
                    .HasForeignKey(d => d.TknsPertenceUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbTokensUsuarios_tkns_PerteneceUsuario");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId)
                    .HasName("PK_Seg_tbUsuarios_usu_Id");

                entity.ToTable("tbUsuarios", "Seg");

                entity.HasIndex(e => e.UsuNombreDeUsuario, "UNQ_Seg_tbUsuarios_usu_NombreDeUsuario")
                    .IsUnique();

                entity.HasIndex(e => e.UsuNombreDeUsuario, "UNQ_tbUsuarios_usu_NombreDeUsuario")
                    .IsUnique();

                entity.Property(e => e.UsuId)
                    .ValueGeneratedNever()
                    .HasColumnName("usu_Id");

                entity.Property(e => e.UsuContrasenia)
                    .IsRequired()
                    .HasColumnName("usu_Contrasenia");

                entity.Property(e => e.UsuCorreo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("usu_Correo");

                entity.Property(e => e.UsuEsActivo).HasColumnName("usu_EsActivo");

                entity.Property(e => e.UsuFechaCrea)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_FechaCrea");

                entity.Property(e => e.UsuFechaModifica)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_FechaModifica");

                entity.Property(e => e.UsuFotografia)
                    .HasMaxLength(60)
                    .HasColumnName("usu_Fotografia");

                entity.Property(e => e.UsuNoCelular)
                    .HasMaxLength(15)
                    .HasColumnName("usu_NoCelular");

                entity.Property(e => e.UsuNombreDeUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("usu_NombreDeUsuario");

                entity.Property(e => e.UsuUsuarioCrea).HasColumnName("usu_UsuarioCrea");

                entity.Property(e => e.UsuUsuarioModifica).HasColumnName("usu_UsuarioModifica");
            });

            modelBuilder.Entity<TbUsuariosRole>(entity =>
            {
                entity.HasKey(e => e.UsurolId)
                    .HasName("PK_Seg_tbUsuariosRoles_usurol_UserId_usurol_RoleId");

                entity.ToTable("tbUsuariosRoles", "Seg");

                entity.HasIndex(e => new { e.UsuId, e.RolId }, "UNQ_Seg_tbUsuarios_usu_Id_rol_Id")
                    .IsUnique();

                entity.Property(e => e.UsurolId)
                    .ValueGeneratedNever()
                    .HasColumnName("usurol_Id");

                entity.Property(e => e.RolId).HasColumnName("rol_Id");

                entity.Property(e => e.UsuId).HasColumnName("usu_Id");

                entity.Property(e => e.UsurolEsActivo).HasColumnName("usurol_EsActivo");

                entity.Property(e => e.UsurolFechaCrea)
                    .HasColumnType("datetime")
                    .HasColumnName("usurol_FechaCrea");

                entity.Property(e => e.UsurolFechaModifica)
                    .HasColumnType("datetime")
                    .HasColumnName("usurol_FechaModifica");

                entity.Property(e => e.UsurolUsuarioCrea).HasColumnName("usurol_UsuarioCrea");

                entity.Property(e => e.UsurolUsuarioModifica).HasColumnName("usurol_UsuarioModifica");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbUsuariosRoles)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Seg_tbRoles_tbUsuariosRoles_rol_Id");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.TbUsuariosRoleUsus)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbUsuariosRoles_usu_Id");

                entity.HasOne(d => d.UsurolUsuarioCreaNavigation)
                    .WithMany(p => p.TbUsuariosRoleUsurolUsuarioCreaNavigations)
                    .HasForeignKey(d => d.UsurolUsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbUsuariosRoles_usurol_UsuarioCrea");

                entity.HasOne(d => d.UsurolUsuarioModificaNavigation)
                    .WithMany(p => p.TbUsuariosRoleUsurolUsuarioModificaNavigations)
                    .HasForeignKey(d => d.UsurolUsuarioModifica)
                    .HasConstraintName("FK_Seg_tbUsuarios_tbUsuariosRoles_usurol_UsuarioModifica");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
