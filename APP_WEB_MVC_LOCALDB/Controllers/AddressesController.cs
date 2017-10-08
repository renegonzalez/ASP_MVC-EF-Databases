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
    public class AddressesController : Controller
    {
        private LocalDBContext db = new LocalDBContext();

        // GET: Addresses
        public async Task<ActionResult> Index()
        {
            return View(await db.direccionesCliente.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosDireccion direccion = await db.direccionesCliente.FindAsync(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,direccion,cp,provincia")] DatosDireccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.direccionesCliente.Add(direccion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(direccion);
        }

        // GET: Addresses/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosDireccion datosDireccion = await db.direccionesCliente.FindAsync(id);
            if (datosDireccion == null)
            {
                return HttpNotFound();
            }
            return View(datosDireccion);
        }

        // POST: Addresses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,direccion,cp,provincia,cliente.id")] DatosDireccion datosDireccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosDireccion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(datosDireccion);
        }

        // GET: Addresses/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosDireccion direccion = await db.direccionesCliente.FindAsync(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            DatosDireccion direccion = await db.direccionesCliente.FindAsync(id);
            db.direccionesCliente.Remove(direccion);
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
