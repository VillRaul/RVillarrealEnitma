using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ServiceProducto.ProductoClient serviceProducto = new ServiceProducto.ProductoClient();
            var resultProducto = serviceProducto.GetAll();
            if (resultProducto.Correct) 
            {
                producto.Productos = resultProducto.Objects.ToList();
                
            }
            return View(producto);
            //ML.Result result = BL.Producto.GetAll();
            
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();


            if (IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                ML.Result result = new ML.Result();


                if (result.Correct)
                {

                    return View(producto);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ServiceProducto.ProductoClient serviceProducto = new ServiceProducto.ProductoClient();
            ML.Result result = new ML.Result();

            if (producto.IdProducto == 0)
            {
                var resultProducto = serviceProducto.Add(producto);
                //result = BL.Producto.Add(producto);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha agregado el producto en la BD";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha agregado el producto en la BD por " + result.ErrorMessage;
                }
            }
            else
            {
                //result = BL.Producto.Update(producto);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "el producto se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al realizar la actualizacion" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
    }
}