﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oracle.DataAccess.Client;
using WhareHouse.Models;
using System.Data.Entity.Migrations;

namespace WhareHouse.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private WhareHouseWebcn db = new WhareHouseWebcn();
        public ProductsController()
        {
            PRODUCT exp = db.PRODUCT.Find(1);
            if (exp == null)
            {
                CreateProductId();
            }
        }

        // GET: Products
        public ActionResult Index()
        {
          
            var pRODUCT = db.PRODUCT.Include(p => p.PROVIDER);
            return View(pRODUCT.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (db.PRODUCT.Find(1) == null)
            {
                ViewBag.idProduct = 1;
            }
            else
            {
                long idProduct = db.PRODUCT.Max(x => x.IDBARCODE);
                ViewBag.idProduct = idProduct + 1;
            }
            ViewBag.error = 0;
            ViewBag.IDPROVIDER = new SelectList(db.PROVIDER,"IDPROVIDER","COMPANYNAME");
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="BARCODE,PURCHASEPRICE,SALEPRICE,STOCK,CRITICALSTOCK,PRODUCTNAME,PRODUCTFAMILY,PRODUCTTYPE,PRODUCTDESCRIPTION,IDPROVIDER")] PRODUCT pRODUCT)
        {
            if (pRODUCT.IDPROVIDER != 0)
            {
                if (ModelState.IsValid)
                {
                    pRODUCT.STATE = "1";
                    pRODUCT.IDBARCODE = ProductIdAumentate();
                    db.PRODUCT.Add(pRODUCT);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            if (db.PRODUCT.Find(1) == null)
            {
                ViewBag.idProduct = 1;
            }
            else
            {
                long idProduct = db.PRODUCT.Max(x => x.IDBARCODE);
                ViewBag.idProduct = idProduct + 1;
            }
            if (pRODUCT.IDPROVIDER == 0)
            {
                ViewBag.error = 1;
            }
            ViewBag.error = 0;
            ViewBag.IDPROVIDER = new SelectList(db.PROVIDER, "IDPROVIDER", "COMPANYNAME");
            return View(pRODUCT);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPROVIDER = new SelectList(db.PROVIDER, "IDPROVIDER", "COMPANYNAME");
            return View(pRODUCT);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBARCODE,BARCODE,PURCHASEPRICE,SALEPRICE,STOCK,CRITICALSTOCK,PRODUCTNAME,PRODUCTFAMILY,PRODUCTTYPE,PRODUCTDESCRIPTION,IDPROVIDER")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                pRODUCT.STATE = "1";
                db.Set<PRODUCT>().AddOrUpdate(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPROVIDER = new SelectList(db.PROVIDER, "IDPROVIDER", "COMPANYNAME");
            return View(pRODUCT);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            db.PRODUCT.Remove(pRODUCT);
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

        public void CreateProductId()
        {
            Connection objectcon = new Connection();
            OracleConnection con = objectcon.GetConection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "CREATESEQUENCEPRODUCT";
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
                objectcon = null;
            }

        }

        public short ProductIdAumentate()
        {
            Connection objectcon = new Connection();
            OracleConnection con = objectcon.GetConection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SELECTSEQUENCEPRODUCT";
            cmd.Parameters.Add("@IDPRODUCT", OracleDbType.Int64).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            short ProductId = Convert.ToInt16(cmd.Parameters["@IDPRODUCT"].Value.ToString());
            con.Close();
            cmd.Dispose();
            con.Dispose();
            objectcon = null;
            return ProductId;
        }

    }
}
