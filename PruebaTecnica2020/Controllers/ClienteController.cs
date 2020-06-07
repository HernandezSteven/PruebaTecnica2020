using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica2020.Models;

namespace PruebaTecnica2020.Controllers
{
    public class ClienteController : Controller
    {
        private SalonesEmpresarialesXYZEntities db = new SalonesEmpresarialesXYZEntities();


        public List<SelectListItem> generateEdad() {
            List<SelectListItem> edad = new List<SelectListItem>();
            for (int i = 0; i < 150; i++){
                edad.Add(new SelectListItem() { Text = ""+i+"", Value = "" + i + "" });
            }
            return edad;

            
                
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Ciudad);
            
            return View(cliente.ToList());

        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "nombreCiudad");
            ViewBag.idDepartamento = new SelectList(db.Departamento, "idDepartamento", "nombreDepartamento");
            ViewBag.idEdad =  generateEdad();
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,identificacionCliente,PrimerNombreCliente,SegundoNombreCliente,PrimerApellidoCliente,SegundoApellidoCliente,telefonoCliente,correoCliente,idCiudad,edadCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "nombreCiudad", cliente.idCiudad);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "nombreCiudad", cliente.idCiudad);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,identificacionCliente,PrimerNombreCliente,SegundoNombreCliente,PrimerApellidoCliente,SegundoApellidoCliente,telefonoCliente,correoCliente,idCiudad,edadCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "nombreCiudad", cliente.idCiudad);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
