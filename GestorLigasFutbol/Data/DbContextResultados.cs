using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextResultados:DbContext
    {
        public DbContextResultados(DbContextOptions<DbContextTipoSanciones> options) : base(options)
        {

        }
        //-----------------------------------TIPO SANCIONES----------------------------------------
        //Creando tabla de Tipos de sanciones
        public DbSet<Resultados> Resultados { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla TipoSanciones en BD
            builder.Entity<Resultados>().ToTable("Resultados");
            builder.Entity<Resultados>().HasKey(u => u.Id);
            builder.Entity<Resultados>().Property(u => u.IdEquipo).HasColumnName("idEquipo");
            builder.Entity<Resultados>().Property(u => u.IdEvento).HasColumnName("idEvento");
            builder.Entity<Resultados>().Property(u => u.Triunfos).HasColumnName("triunfos");
            builder.Entity<Resultados>().Property(u => u.Empates).HasColumnName("empates");
            builder.Entity<Resultados>().Property(u => u.Derrotas).HasColumnName("derrotas");
            builder.Entity<Resultados>().Property(u => u.Juegos).HasColumnName("juegos");
            builder.Entity<Resultados>().Property(u => u.GolesFavor).HasColumnName("golesFavor");
            builder.Entity<Resultados>().Property(u => u.GolesContra).HasColumnName("golesContra");
            builder.Entity<Resultados>().Property(u => u.DiferenciaGoles).HasColumnName("diferenciaGoles");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<Resultados> ObtenerResultados()
        {
            return Resultados.FromSqlRaw("exec spGetResultados").ToList();

        }

        //metodo para retornar un usuario segun un id
        public Resultados ObtenerResultadoId(int id)
        {
            var resultados = Resultados.FromSqlInterpolated($"exec spGetResultado {id}").AsEnumerable().FirstOrDefault();
            return resultados;
        }

        //metodo para insertar datos a la tabla
        public void CrearResultado(int idEquipo, int idEvento, int triunfos, int empates, int derrotas, int juegos, int golesFavor, int golesContra, int diferenciaGoles)
        {
            Database.ExecuteSqlRaw("exec spInsertarResultados {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", idEquipo, idEvento, triunfos, empates, derrotas, juegos, golesFavor, golesContra, diferenciaGoles);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarResultado(int id, int idEquipo, int idEvento, int triunfos, int empates, int derrotas, int juegos, int golesFavor, int golesContra, int diferenciaGoles)
        {
            Database.ExecuteSqlRaw("exec spActualizarResultados {0} ,{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", id, idEquipo, idEvento, triunfos, empates, derrotas, juegos, golesFavor, golesContra, diferenciaGoles);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarResultado(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarResultados {0}", id);
        }

    }

}
