using Microsoft.AspNetCore.Mvc;
using GestorLigasFutbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestorLigasFutbol.Controllers
{
    public class TipoUsuariosController : Controller
    {

        //Get TipoUsuarios
        public IActionResult TipoUsuarios()
        {
            //Establecer la conexion 
            using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
            {
                // Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                using (SqlCommand cmd = new("spGetTipoUsuarios", con))
                {
                    //se define el tipo de commandType
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd); //ejecutar comando
                    DataTable dt = new();//creacion de tabla
                    da.Fill(dt); //llenado de tabla
                    da.Dispose();  //eliminacion de recursos
                    List<TipoUsuariosModel> lista = new(); //creando una lista

                    for (int i = 0; i < dt.Rows.Count; i++) //recorrido dentro del data table para agregar a una lista
                    {
                        lista.Add(new TipoUsuariosModel() // creacion de objeto de tipo UsuarioModel
                        {
                            //Agregando valores para cada parametro del modelo
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            Nombre = dt.Rows[i][1].ToString(),

                        });
                    }
                    ViewBag.Usuarios = lista; //contendra lo que este en la lista
                    con.Close(); // cerrar conexion
                }
                return View();
            }
            return View();
        }

        public IConfiguration Configuration { get; }
        //constructor
        public TipoUsuariosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
