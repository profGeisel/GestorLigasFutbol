using GestorLigasFutbol.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using GestorLigasFutbol.Data;

namespace GestorLigasFutbol.Controllers
{
    //restringir la autorizacion 
    //[Authorize]
    public class CampeonatosController : Controller
    {
            private readonly DbContextCampeonatos _context;
            public CampeonatosController(DbContextCampeonatos context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                var campeonatos = _context.ObtenerCampeonatos().ToList();

                return View(campeonatos);
            }
            public IActionResult Insertar()
            {
                return View();
            }

            //metodo para crear un campeonato
            [HttpPost]
            public IActionResult Insertar(Campeonatos Campeonatos)
            {
                if (ModelState.IsValid)
                {
                    _context.CrearCampeonato(Campeonatos.Nombre, Campeonatos.FechaInicio, Campeonatos.FechaCierre, Campeonatos.NumeroEquiposP, Campeonatos.Activo, Campeonatos.IdLiga);
                    return RedirectToAction("Index");
                }
                return View();

            }

            //metodo para la actualizacion 
            //GEt de actualizar
            public IActionResult Actualizar(int id)
            {
                var campeonato = _context.ObtenerCampeonatoId(id);
                return View(campeonato);
            }
            [HttpPost]
            public IActionResult Actualizar(Campeonatos Campeonatos)
            {
                if (ModelState.IsValid && Campeonatos.Id > 0)
                {
                    _context.ActualizarCampeonato(Campeonatos.Id, Campeonatos.Nombre, Campeonatos.FechaInicio, Campeonatos.FechaCierre, Campeonatos.NumeroEquiposP, Campeonatos.Activo, Campeonatos.IdLiga);
                    return RedirectToAction("Index");
                }

                return View();
            }


            //metodo para Eliminar 
            //GEt de Eliminar
            public IActionResult Eliminar(int id)
            {
                var campeonato = _context.ObtenerCampeonatoId(id);
                return View(campeonato);
            }
            [HttpPost]
            public IActionResult Eliminar(Campeonatos Campeonatos)
            {
                if (Campeonatos.Id > 0)
                {
                    _context.EliminarCampeonato(Campeonatos.Id);
                    return RedirectToAction("Index");
                }

                return View();
            }


        }
    }
