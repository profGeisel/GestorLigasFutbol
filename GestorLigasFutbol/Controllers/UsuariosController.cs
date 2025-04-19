using Microsoft.AspNetCore.Mvc;
using GestorLigasFutbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;

namespace GestorLigasFutbol.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            //Establecer la conexion 
            using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
            {
                // Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                using (SqlCommand cmd = new("spGetUsuarios", con))
                {
                    //se define el tipo de commandType
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd); //ejecutar comando
                    DataTable dt = new();//creacion de tabla
                    da.Fill(dt); //llenado de tabla
                    da.Dispose();  //eliminacion de recursos
                    List<UsuarioModel> lista = new(); //creando una lista

                    for (int i = 0; i < dt.Rows.Count; i++) //recorrido dentro del data table para agregar a una lista
                    {
                        lista.Add(new UsuarioModel() // creacion de objeto de tipo UsuarioModel
                        {
                            //Agregando valores para cada parametro del modelo
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            Nombre = dt.Rows[i][1].ToString(),
                            ApellidoP = dt.Rows[i][2].ToString(),
                            ApellidoM = dt.Rows[i][3].ToString(),
                            CorreoE = dt.Rows[i][4].ToString(),
                            Contrasena = dt.Rows[i][5].ToString(),
                            IdTipoUsuario= Convert.ToInt32(dt.Rows[i][6]),                        

                        });
                    }
                    ViewBag.Usuarios = lista; //contendra lo que este en la lista
                    con.Close(); // cerrar conexion
                }
                return View();
            }
            }
           
        public IConfiguration Configuration { get; }
        //constructor
        public UsuariosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        //metodo para registrar
        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                //Establecer la conexion que inicializa la configuracion con la cadena ConnectionStrings
                using (SqlConnection con = new(Configuration["ConnectionStrings:BdConexion"]))
                {
                    //Instruccion para ejecutar procedimiento almacenado con la conexion a bd
                    using (SqlCommand cmd = new("spInsertarUsuarios", con))
                    {

                        //se especifica el tipo 
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //Se especifica el parametro nombre, su tipo y el valor en el modelo 
                        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = usuario.Nombre;
                        cmd.Parameters.Add("@ApellidoP", System.Data.SqlDbType.VarChar).Value = usuario.ApellidoP;
                        cmd.Parameters.Add("@ApellidoM", System.Data.SqlDbType.VarChar).Value = usuario.ApellidoM;
                        cmd.Parameters.Add("@CorreoE", System.Data.SqlDbType.VarChar).Value = usuario.CorreoE;
                        cmd.Parameters.Add("@Contrasena", System.Data.SqlDbType.VarChar).Value = usuario.Contrasena;
                        cmd.Parameters.Add("@TipoUsuario", System.Data.SqlDbType.VarChar).Value = usuario.IdTipoUsuario;
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
