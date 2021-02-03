using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital1.DB;
using Vital1.Models.ViewModels;

namespace Vital1.Controllers
{

    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListaProductoViewModels> lst;
            using (vital1Entities db = new vital1Entities())
            {
                lst = (from d in db.Producto 
                       select new ListaProductoViewModels
                       {
                           Prod_Id = d.Prod_Id,
                           Prod_Desk = d.Prod_Desk,
                           Prod_Cant = d.Prod_Cant,
                           Prod_estado = d.Prod_estado

                       }).ToList();
            }
            return View(lst);

        }

        public ActionResult Nuevo()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Nuevo(ProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (vital1Entities db = new vital1Entities())
                    {
                        var oProducto = new Producto();
                        oProducto.Prod_Id = model.Prod_Id;
                        oProducto.Prod_Desk = model.Prod_Desk;
                        oProducto.Prod_Cant = model.Prod_Cant;
                        oProducto.Prod_estado = false;

                        db.Producto.Add(oProducto);
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public ActionResult Editar(int Id)
        {
            ProductoViewModels model = new ProductoViewModels();
            using (vital1Entities db = new vital1Entities())
            {
                var oProducto = db.Producto.Find(Id);

                model.Prod_Id = oProducto.Prod_Id;
                model.Prod_Desk = oProducto.Prod_Desk;
                model.Prod_Cant = oProducto.Prod_Cant;
            }
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Editar(ProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (vital1Entities db = new vital1Entities())
                    {
                        var oProducto = db.Producto.Find(model.Prod_Id);
                        oProducto.Prod_Desk = model.Prod_Desk;
                        oProducto.Prod_Cant = model.Prod_Cant;

                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public ActionResult Eliminar(int Id)
        {
            using (vital1Entities db = new vital1Entities())
            {

                var oProducto = db.Producto.Find(Id);
                oProducto.Prod_estado = true;
                db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("~/Producto/");
        }

        public ActionResult Agregar(int Id)
        {
            ProductoViewModels model = new ProductoViewModels();
            using (vital1Entities db = new vital1Entities())
            {
                var oProducto = db.Producto.Find(Id);

                model.Prod_Id = oProducto.Prod_Id;
                model.Prod_Desk = oProducto.Prod_Desk;
                model.Prod_Cant = oProducto.Prod_Cant;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar(ProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (vital1Entities db = new vital1Entities())
                    {
                        var ohistorial = new Historial();
                        ohistorial.Hist_Cant = model.Hist_Cant;
                        ohistorial.Prod_Id = model.Prod_Id;
                        ohistorial.Hist_Fecha = DateTime.Now;

                        var oProducto = db.Producto.Find(model.Prod_Id);
                        oProducto.Prod_Desk = model.Prod_Desk;
                        oProducto.Prod_Cant = (model.Prod_Cant + model.Hist_Cant);

                        db.Historial.Add(ohistorial);
                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Historico(int Id)
        {

            List<ListaProductoViewModels> lst;
            using (vital1Entities db = new vital1Entities())
            {
                lst = (from d in db.Producto
                       join Hist in db.Historial on d.Prod_Id equals Hist.Prod_Id into Histo
                       from His in Histo
                       where d.Prod_Id == Id
                       select new ListaProductoViewModels
                       {
                            Prod_Id = d.Prod_Id,
                            Prod_Desk = d.Prod_Desk,
                            Cant_total = His.Hist_Cant,
                            Fecha = His.Hist_Fecha
                       }
                       ).ToList();
            }
            return View(lst);

        }


    }
}