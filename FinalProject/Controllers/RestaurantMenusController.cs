using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class RestaurantMenusController : Controller
    {
        private FinalProjectContext db = new FinalProjectContext();

        // GET: RestaurantMenus
        public async Task<ActionResult> Index()
        {
            return View(await db.RestaurantMenus.ToListAsync());
        }

        // GET: RestaurantMenus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantMenu restaurantMenu = await db.RestaurantMenus.FindAsync(id);
            if (restaurantMenu == null)
            {
                return HttpNotFound();
            }
            return View(restaurantMenu);
        }

        // GET: RestaurantMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,item,price,qty")] RestaurantMenu restaurantMenu)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantMenus.Add(restaurantMenu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(restaurantMenu);
        }

        // GET: RestaurantMenus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantMenu restaurantMenu = await db.RestaurantMenus.FindAsync(id);
            if (restaurantMenu == null)
            {
                return HttpNotFound();
            }
            return View(restaurantMenu);
        }

        // POST: RestaurantMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,item,price,qty")] RestaurantMenu restaurantMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantMenu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(restaurantMenu);
        }

        // GET: RestaurantMenus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantMenu restaurantMenu = await db.RestaurantMenus.FindAsync(id);
            if (restaurantMenu == null)
            {
                return HttpNotFound();
            }
            return View(restaurantMenu);
        }

        // POST: RestaurantMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RestaurantMenu restaurantMenu = await db.RestaurantMenus.FindAsync(id);
            db.RestaurantMenus.Remove(restaurantMenu);
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
