using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicMVCNorthwind.Models;

namespace BasicMVCNorthwind.Controllers
{
    [HandleError(View="Error")]
    public class ProductsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        //
        // GET: /Products/

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categories).Include(p => p.Suppliers);
            return View(products.ToList());
        }

        //
        // GET: /Products/Details/5
        [HandleError(View = "NoSuchRecordError", ExceptionType = typeof(NoSuchRecordException))]
        public ActionResult Details(int id = 0)
        {
            Products products = db.Products.Find(id);

            if (products == null)
            {
                throw new NoSuchRecordException();
            }
            else
            {
                ViewData["CatName"] = GetCategoryName(products);
                ViewData["SupName"] = GetSupplierName(products);

                return View(products);
            }
        }

        public string GetSupplierName(Products prod)
        {
            var suppliers = db.Suppliers.Find(prod.SupplierID);

            if (suppliers != null)
            {
                return db.Suppliers.Find(prod.SupplierID).CompanyName;
            }
            else
            {
                return "";
            }
        }

        public string GetCategoryName(Products prod)
        {
            var categories = db.Categories.Find(prod.SupplierID);
            if (categories != null)
            {
                return categories.CategoryName;
            }
            else
            {
                return "";
            }
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                throw new Exception("product is null");
                //return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            try
            {
                db.Products.Remove(products);
                db.SaveChanges();
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.ToString());
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term">The name should be term for jquery autocomplete control</param>
        /// <returns></returns>
        public JsonResult List(string term)
        {
            var result = from p in db.Products
                         where p.ProductName.StartsWith(term)
                         select new { label = p.ProductName, id = p.ProductID };

            return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchList(int ProductID)
        {
            Products products = db.Products.Find(ProductID);
            if (products == null)
            {
                throw new Exception("product is null");
                //return HttpNotFound();
            }

            return View(products);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        class NoSuchRecordException : Exception
        {
 
        }
    }
}