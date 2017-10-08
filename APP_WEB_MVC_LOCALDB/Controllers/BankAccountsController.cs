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
    public class BankAccountsController : Controller
    {
        private LocalDBContext db = new LocalDBContext();

        // GET: BankAccounts
        public async Task<ActionResult> Index()
        {
            return View(await db.datosBancariosCliente.ToListAsync());
        }

        // GET: BankAccounts/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosBancarios datosBancarios = await db.datosBancariosCliente.FindAsync(id);
            if (datosBancarios == null)
            {
                return HttpNotFound();
            }
            return View(datosBancarios);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,banco,sucursal,num_cuenta")] DatosBancarios datosBancarios)
        {
            if (ModelState.IsValid)
            {
                db.datosBancariosCliente.Add(datosBancarios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(datosBancarios);
        }

        // GET: BankAccounts/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosBancarios datosBancarios = await db.datosBancariosCliente.FindAsync(id);
            if (datosBancarios == null)
            {
                return HttpNotFound();
            }
            return View(datosBancarios);
        }

        // POST: BankAccounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,banco,sucursal,num_cuenta")] DatosBancarios datosBancarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosBancarios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(datosBancarios);
        }

        // GET: BankAccounts/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosBancarios datosBancarios = await db.datosBancariosCliente.FindAsync(id);
            if (datosBancarios == null)
            {
                return HttpNotFound();
            }
            return View(datosBancarios);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            DatosBancarios datosBancarios = await db.datosBancariosCliente.FindAsync(id);
            db.datosBancariosCliente.Remove(datosBancarios);
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
