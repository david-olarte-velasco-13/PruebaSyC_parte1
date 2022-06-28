using Microsoft.AspNetCore.Mvc;

using pruebaparte1.Datos;
using pruebaparte1.Models;

namespace pruebaparte1.Controllers
{
    public class MantenedorController : Controller
    {
        FacturaDatos _FacturaDatos = new FacturaDatos();
        public IActionResult Listar()
        {
            //Mostrar la lista de facturas

            var oLista = _FacturaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Solo devolver la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(FacturaModel oFactura)
        {
            //Recibir un objeto y guardarlo en la DB
            if (!ModelState.IsValid)
                return View();

            var respuesta = _FacturaDatos.Guardar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult Editar(int Idcliente)
        {
            //Solo devolver la vista
            var ofactura = _FacturaDatos.Obtener(Idcliente);
            return View(ofactura);
        }

        [HttpPost]
        public IActionResult Editar(FacturaModel oFactura)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _FacturaDatos.Editar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }



        public IActionResult Eliminar(int Idcliente)
        {
            //solo devuelve la vista
            var ofactura = _FacturaDatos.Obtener(Idcliente);
            return View(ofactura);
        }

        [HttpPost]
        public IActionResult Eliminar(FacturaModel oFactura)
        {

            var respuesta = _FacturaDatos.Eliminar(oFactura.Idcliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Consultar(int documento  = 0, int valor = 0)
        {
            ViewBag.Documento = documento;
            ViewBag.Valor = valor;
            //Solo devolver la vista
            return View();
        }

        [HttpPost]
        public IActionResult ConsultarByDocumento(int documento)
        {
            //Recibir un objeto y guardarlo en la DB
            if (!ModelState.IsValid)
                return View();

            var respuesta = _FacturaDatos.ValorByDocumento(documento);

            if (respuesta > 0)
                return RedirectToAction("Consultar",new { valor =  respuesta, documento = documento});
            else
                return View();
        }





    }
}
