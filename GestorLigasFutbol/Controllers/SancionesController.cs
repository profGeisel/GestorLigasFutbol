using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GestorLigasFutbol.Controllers
{
    public class SancionesController : Controller
    {
        public IActionResult Index()
        {
            //Establecer la conexion 
            using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
            {
                // Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                using (SqlCommand cmd = new("spGetSanciones", con))
                {
                    //se define el tipo de commandType
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd); //ejecutar comando
                    DataTable dt = new();//creacion de tabla
                    da.Fill(dt); //llenado de tabla
                    da.Dispose();  //eliminacion de recursos
                    List<SancionesModel> lista = new(); //creando una lista

                    for (int i = 0; i < dt.Rows.Count; i++) //recorrido dentro del data table para agregar a una lista
                    {
                        lista.Add(new SancionesModel() // creacion de objeto de tipo UsuarioModel
                        {
                            //Agregando valores para cada parametro del modelo
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            Activa = Convert.ToBoolean(dt.Rows[i][1]),
                            IdJugador = Convert.ToInt32(dt.Rows[i][2]),
                            IdEquipo = Convert.ToInt32(dt.Rows[i][3]),
                            IdCampeonato = Convert.ToInt32(dt.Rows[i][4]),
                            IdTipoS=Convert.ToInt32(dt.Rows [i][5]),
                        });
                    }
                    ViewBag.Sanciones = lista; //contendra lo que este en la lista
                    con.Close(); // cerrar conexion
                }
                return View();
            }
        }

        public IConfiguration Configuration { get; }
        //constructor
        public SancionesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }

}
