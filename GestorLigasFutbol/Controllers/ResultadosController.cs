using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using GestorLigasFutbol.Data;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    // [Authorize]
    public class ResultadosController : Controller
    {
            private readonly DbContextResultados _context;
            public ResultadosController(DbContextResultados context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                var resultados = _context.ObtenerResultados().ToList();

                return View(resultados);
            }
            public IActionResult Insertar()
            {
                return View();
            }

            //metodo para crear un usuario
            [HttpPost]
            public IActionResult Insertar(Resultados Resultados)
            {
                if (ModelState.IsValid)
                {
                    _context.CrearResultado(Resultados.IdEquipo, Resultados.IdEvento, Resultados.Triunfos, Resultados.Empates, Resultados.Derrotas, Resultados.Juegos, Resultados.GolesFavor, Resultados.GolesContra, Resultados.DiferenciaGoles);
                    return RedirectToAction("Index");
                }
                return View();

            }

            //metodo para la actualizacion 
            //GEt de actualizar
            public IActionResult Actualizar(int id)
            {
                var resultados = _context.ObtenerResultadoId(id);
                return View(resultados);
            }
            [HttpPost]
            public IActionResult Actualizar(Resultados Resultados)
            {
                if (ModelState.IsValid && Resultados.Id > 0)
                {
                    _context.ActualizarResultado(Resultados.Id, Resultados.IdEquipo, Resultados.IdEvento, Resultados.Triunfos, Resultados.Empates, Resultados.Derrotas, Resultados.Juegos, Resultados.GolesFavor, Resultados.GolesContra, Resultados.DiferenciaGoles);
                    return RedirectToAction("Index");
                }

                return View();
            }


            //metodo para Eliminar 
            //GEt de Eliminar
            public IActionResult Eliminar(int id)
            {
                var resultado = _context.ObtenerResultadoId(id);
                return View(resultado);
            }
            [HttpPost]
            public IActionResult Eliminar(Resultados Resultados)
            {
                if (Resultados.Id > 0)
                {
                    _context.EliminarResultado(Resultados.Id);
                    return RedirectToAction("Index");
                }

                return View();
            }
        }
    }
