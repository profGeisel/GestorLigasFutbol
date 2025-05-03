using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using GestorLigasFutbol.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    // [Authorize]
    public class ResultadosIndividualesController : Controller
    {
            private readonly DbContextResultadosIndividuales _context;
            public ResultadosIndividualesController(DbContextResultadosIndividuales context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                var resultadosIndividuales = _context.ObtenerResultadosIndividuales().ToList();

                return View(resultadosIndividuales);
            }
            public IActionResult Insertar()
            {
                //COMBO Jugadores
                //Crear lista de Jugadores
                var jugadores = _context.Jugadores.Select(c => new { c.Id, c.Nombre , c.ApellidoP}).ToList();

                // Convertir lista a SelectList para el dropdown List
                ViewBag.Jugadores = new SelectList(jugadores, "Id", "Nombre", "ApellidoP");

                
            return View();
            }

            //metodo para crear un Resultado Individual
            [HttpPost]
            public IActionResult Insertar(ResultadosIndividuales ResultadosIndividuales)
            {
                if (ModelState.IsValid)
                {
                    _context.CrearResultadoIndividual( ResultadosIndividuales.IdJugador, ResultadosIndividuales.Fecha,ResultadosIndividuales.cantidadGoles, ResultadosIndividuales.asistencias, ResultadosIndividuales.tRojas, ResultadosIndividuales.tAmarillas);
                    return RedirectToAction("Index");
                }
                return View();

            }

            //metodo para la actualizacion 
            //GEt de actualizar
            public IActionResult Actualizar(int id)
            {
            //COMBO Jugadores
            //Crear lista de Jugadores
            var jugadores = _context.Jugadores.Select(c => new { c.Id, c.Nombre, c.ApellidoP }).ToList();

            // Convertir lista a SelectList para el dropdown List
            ViewBag.Jugadores = new SelectList(jugadores, "Id", "Nombre", "ApellidoP");

            var resultadoIndividual = _context.ObtenerResultadoIndividualId(id);
                    return View(resultadoIndividual);
            }
            [HttpPost]
            public IActionResult Actualizar(ResultadosIndividuales ResultadosIndividuales)
            {
                if (ModelState.IsValid && ResultadosIndividuales.Id > 0)
                {
                    _context.ActualizarResultadoIndividual(ResultadosIndividuales.Id, ResultadosIndividuales.IdJugador, ResultadosIndividuales.Fecha, ResultadosIndividuales.cantidadGoles, ResultadosIndividuales.asistencias, ResultadosIndividuales.tRojas, ResultadosIndividuales.tAmarillas);
                    return RedirectToAction("Index");
                }

                return View();
            }


            //metodo para Eliminar 
            //GEt de Eliminar
            public IActionResult Eliminar(int id)
            {
                var resultadoIndividual = _context.ObtenerResultadoIndividualId(id);
                return View(resultadoIndividual);
            }
            [HttpPost]
            public IActionResult Eliminar(ResultadosIndividuales ResultadosIndividuales)
            {
                if (ResultadosIndividuales.Id > 0)
                {
                    _context.EliminarResultadoIndividual(ResultadosIndividuales.Id);
                    return RedirectToAction("Index");
                }

                return View();
            }

        

    }
    }
