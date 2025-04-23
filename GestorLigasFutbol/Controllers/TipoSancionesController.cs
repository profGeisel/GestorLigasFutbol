using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GestorLigasFutbol.Controllers
{
    public class TipoSancionesController : Controller
    {
        public IActionResult Index()
        {
            //Establecer la conexion 
            using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
            {
                // Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                using (SqlCommand cmd = new("spGetTipoSanciones", con))
                {
                    //se define el tipo de commandType
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd); //ejecutar comando
                    DataTable dt = new();//creacion de tabla
                    da.Fill(dt); //llenado de tabla
                    da.Dispose();  //eliminacion de recursos
                    List<TipoSancionesModel> lista = new(); //creando una lista

                    for (int i = 0; i < dt.Rows.Count; i++) //recorrido dentro del data table para agregar a una lista
                    {
                        lista.Add(new TipoSancionesModel() // creacion de objeto de tipo UsuarioModel
                        {
                            //Agregando valores para cada parametro del modelo
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            Nombre = dt.Rows[i][1].ToString(),
                            Descripcion = dt.Rows[i][2].ToString(),
                            Tiempo = Convert.ToInt32(dt.Rows[i][3].ToString()),
                            Valor = Convert.ToInt32(dt.Rows[i][4].ToString()),
                            Estado=Convert.ToBoolean(dt.Rows[i][5].ToString()),
                            IdLiga = Convert.ToInt32(dt.Rows[i][6]),
                        });
                    }
                    ViewBag.TipoSanciones = lista; //contendra lo que este en la lista
                    con.Close(); // cerrar conexion
                }
                return View();
            }
        }

        public IConfiguration Configuration { get; }
        //constructor
        public TipoSancionesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //metodo para registrar Tipo Sanciones
        [HttpPost]
        public IActionResult Registrar(TipoSancionesModel tipoSancion)
        {
            if (ModelState.IsValid)
            {
                //Establecer la conexion que inicializa la configuracion con la cadena ConnectionStrings
                using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
                {
                    //Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                    using (SqlCommand cmd = new("spInsertarTipoSanciones", con))
                    {

                        //se especifica el tipo 
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //Se especifica el parametro nombre, su tipo y el valor en el modelo 
                        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = tipoSancion.Nombre;
                        cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar).Value = tipoSancion.Descripcion;
                        cmd.Parameters.Add("@Tiempo", System.Data.SqlDbType.VarChar).Value = tipoSancion.Tiempo;
                        cmd.Parameters.Add("@Valor", System.Data.SqlDbType.VarChar).Value = tipoSancion.Valor;
                        cmd.Parameters.Add("@IdLiga", System.Data.SqlDbType.VarChar).Value = tipoSancion.IdLiga;
                        con.Open();// abri la conexion
                        cmd.ExecuteNonQuery(); // ejecutar los comandos
                        con.Close(); // cerrar la conexion 

                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "Usuario Registrado con exito";
                return Redirect("Index");
            }
            return Redirect("Index");
        }
    }
}



