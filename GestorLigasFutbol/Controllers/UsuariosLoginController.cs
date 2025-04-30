using System.Security.Claims;
using GestorLigasFutbol.Data;
using GestorLigasFutbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GestorLigasFutbol.Controllers
{
    
    public class UsuariosLoginController : Controller
    {

        private readonly ContextLogin _contextLogin;

        public UsuariosLoginController(ContextLogin contextLogin)
        {
            _contextLogin = contextLogin;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal c = HttpContext.User; //obtener objeto que representa a usuario
            if (c.Identity != null) //verifica la identidad del usuario
            {
                if (c.Identity.IsAuthenticated) //verificar autenticacion 
                    return RedirectToAction("Index", "Home");  
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario u)
        {
            try
            {
                using (SqlConnection con = new(_contextLogin.Conexion))
                {
                    using (SqlCommand cmd = new("spValidarUsuarios", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CorreoE", System.Data.SqlDbType.VarChar).Value = u.CorreoE;
                        cmd.Parameters.Add("@Contrasena", System.Data.SqlDbType.VarChar).Value = u.Contrasena;
                        con.Open();
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["CorreoE"] != null && u.CorreoE != null)
                            {
                                List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, u.CorreoE)
                                };
                                ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);

                                AuthenticationProperties p = new();

                                p.AllowRefresh = true;
                                p.IsPersistent = u.MantenerActivo;

                                if (!u.MantenerActivo)
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30);//se cierra en media hora
                                else
                                    p.ExpiresUtc = DateTimeOffset.MaxValue; //mantenga activa indefinidamente

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Error = "Credenciales incorrectas o cuenta no existente";
                            }
                        }
                        con.Close();
                    }
                    return View();
                }
            }catch (System.Exception e)
            {
                ViewBag.Error=e.Message;
                return View();
            }
        }

        [ResponseCache(Duration =0,Location = ResponseCacheLocation.None,NoStore =true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
       
    }
}
