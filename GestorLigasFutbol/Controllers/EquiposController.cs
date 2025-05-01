using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    // [Authorize]
    public class EquiposController : Controller
    {
        public IActionResult Index()
        {
            //Establecer la conexion 
            using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
            {
                // Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                using (SqlCommand cmd = new("spGetEquipos", con))
                {
                    //se define el tipo de commandType
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd); //ejecutar comando
                    DataTable dt = new();//creacion de tabla
                    da.Fill(dt); //llenado de tabla
                    da.Dispose();  //eliminacion de recursos
                    List<Equipos> lista = new(); //creando una lista

                    for (int i = 0; i < dt.Rows.Count; i++) //recorrido dentro del data table para agregar a una lista
                    {
                        lista.Add(new Equipos() // creacion de objeto de tipo UsuarioModel
                        {
                            //Agregando valores para cada parametro del modelo
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            Nombre = dt.Rows[i][1].ToString(),
                            Logo= Convert.ToByte( dt.Rows[i][2]),
                            CorreoE = dt.Rows[i][3].ToString(),
                            Lugar = dt.Rows[i][4].ToString(),
                            Capitan = dt.Rows[i][5].ToString(),
                            FechaFundacion=Convert.ToDateTime(dt.Rows[i][6]),
                            Descripcion = dt.Rows[i][7].ToString(),
                            NumIdentificacion = Convert.ToInt32(dt.Rows[i][8]),
                            IdCampeonato = Convert.ToInt32(dt.Rows[i][9]),
                        });
                    }
                    ViewBag.Equipos = lista; //contendra lo que este en la lista
                    con.Close(); // cerrar conexion
                }
                return View();
            }
        }

        public IConfiguration Configuration { get; }
        //constructor
        public EquiposController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
