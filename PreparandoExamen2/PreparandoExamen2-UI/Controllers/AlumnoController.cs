using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PreparandoExamen2_BL.Listas;
using PreparandoExamen2_ET;
using PreparandoExamen2_UI.Models;
using PreparandoExamen2_BL.Manejadoras;

namespace PreparandoExamen_UI.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Home

        //primera vez que entra
        public ActionResult Index()
        {
            try
            {
                List<ClsAlumnoConNombreDeCurso> alumnosConNombreDeCurso= new List<ClsAlumnoConNombreDeCurso>();
                ClsListadoAlumnosBL listadoBL = new ClsListadoAlumnosBL();
                ClsGestoraCursosBL bl = new ClsGestoraCursosBL();
                List<ClsAlumno> alumnos;
                alumnos = listadoBL.ObtenerListadoAlumnosBL();

                foreach (var item in alumnos)
                {
                    ClsAlumnoConNombreDeCurso oAlumnosConNombreCurso = new ClsAlumnoConNombreDeCurso();
                    oAlumnosConNombreCurso.NombreAlumno = item.NombreAlumno;
                    oAlumnosConNombreCurso.ApellidosAlumno = item.ApellidosAlumno;
                    oAlumnosConNombreCurso.Beca = item.Beca;
                    oAlumnosConNombreCurso.NombreCurso = bl.BuscarCursoPorIdBL(item.IdCurso).NombreCurso;

                    alumnosConNombreDeCurso.Add(oAlumnosConNombreCurso);
                }

                return View(alumnosConNombreDeCurso);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// detalles de la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto persona</returns>
        public ActionResult Details(int id)
        {
            ClsGestoraAlumnosBL gp = new ClsGestoraAlumnosBL();
            ClsGestoraCursosBL gc = new ClsGestoraCursosBL();
            ClsAlumno alumno = gp.BuscarAlumnoPorIdBL(id);
            ClsCurso curso = gc.BuscarCursoPorIdBL(alumno.IdCurso);

            ClsAlumnoConNombreDeCurso oAlumnosConNombreCurso = new ClsAlumnoConNombreDeCurso();

            oAlumnosConNombreCurso.NombreAlumno = alumno.NombreAlumno;
            oAlumnosConNombreCurso.ApellidosAlumno = alumno.ApellidosAlumno;
            oAlumnosConNombreCurso.Beca = alumno.Beca;
            oAlumnosConNombreCurso.NombreCurso = curso.NombreCurso;

            return View(oAlumnosConNombreCurso);
        }

        public ActionResult Delete(int id)
        {
            ClsGestoraAlumnosBL gp = new ClsGestoraAlumnosBL();
            ClsAlumno a = gp.BuscarAlumnoPorIdBL(id);

            return View(a);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            int i = 0;

            ClsGestoraAlumnosBL gp = new ClsGestoraAlumnosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    i = gp.BorrarAlumnoPorIdBL(id);
                }
                catch (Exception)
                {

                    return View("Error");
                }

            }

            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClsAlumno alumno)
        {
            int i = 0;

            ClsGestoraAlumnosBL gp = new ClsGestoraAlumnosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    i = gp.InsertarAlumnoBL(alumno);
                }
                catch (Exception)
                {

                    return View("Error");
                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ClsAlumnoConListadoDeCursos alumnosListadoCursos = new ClsAlumnoConListadoDeCursos();
            ClsGestoraAlumnosBL ga = new ClsGestoraAlumnosBL();
            ClsAlumno a = ga.BuscarAlumnoPorIdBL(id);
            ClsListadoCursosBL listadoCursos = new ClsListadoCursosBL();

            alumnosListadoCursos.ListadoCursos = listadoCursos.ObtenerListadoCursosBL();
            alumnosListadoCursos.NombreAlumno = a.NombreAlumno;
            alumnosListadoCursos.ApellidosAlumno = a.ApellidosAlumno;
            alumnosListadoCursos.Beca = a.Beca;

            return View(alumnosListadoCursos);
        }

        [HttpPost]
        public ActionResult Edit(ClsAlumno alumno)
        {
            int i = 0;

            ClsGestoraAlumnosBL ga = new ClsGestoraAlumnosBL();

            if (!ModelState.IsValid)
            {
                return View(alumno);
            }

            else
            {
                i = ga.ActualizarAlumnoBL(alumno);
            }

            return RedirectToAction("Index");
        }

    }
}