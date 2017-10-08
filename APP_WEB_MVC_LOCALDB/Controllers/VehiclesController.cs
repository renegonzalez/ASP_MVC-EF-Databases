using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APP_WEB_MVC_LOCALDB.Context;
using APP_WEB_MVC_LOCALDB.Models;

namespace APP_WEB_MVC_LOCALDB.Controllers
{
    public class VehiclesController : Controller
    {
        private LocalDBContext db = new LocalDBContext();

        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            var vehiculos = db.vehiculos.Include(v => v.cliente).Include(v => v.tipo);
            return View(await vehiculos.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = await db.vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.clienteID = new SelectList(db.clientes, "id", "nombre");
            ViewBag.tipoVehiculoID = new SelectList(db.tiposVehiculos, "id", "nombre");
            return View();
        }

        // POST: Vehicles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,matricula,marca,modelo,numBastidor,tipoVehiculoID,clienteID")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.vehiculos.Add(vehiculo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.clienteID = new SelectList(db.clientes, "id", "nombre", vehiculo.clienteID);
            ViewBag.tipoVehiculoID = new SelectList(db.tiposVehiculos, "id", "nombre", vehiculo.tipoVehiculoID);
            return View(vehiculo);
        }

        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = await db.vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteID = new SelectList(db.clientes, "id", "nombre", vehiculo.clienteID);
            ViewBag.tipoVehiculoID = new SelectList(db.tiposVehiculos, "id", "nombre", vehiculo.tipoVehiculoID);
            return View(vehiculo);
        }

        // POST: Vehicles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,matricula,marca,modelo,numBastidor,tipoVehiculoID,clienteID")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.clienteID = new SelectList(db.clientes, "id", "nombre", vehiculo.clienteID);
            ViewBag.tipoVehiculoID = new SelectList(db.tiposVehiculos, "id", "nombre", vehiculo.tipoVehiculoID);
            return View(vehiculo);
        }

        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = await db.vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Vehiculo vehiculo = await db.vehiculos.FindAsync(id);
            db.vehiculos.Remove(vehiculo);
            await db.SaveChangesAsync();
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
