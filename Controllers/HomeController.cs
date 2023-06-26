using Entrev1sta.Data;
using Entrev1sta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Entrev1sta.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindContext _DbContext;

        public HomeController(NorthwindContext context)
        {
            _DbContext = context;
        }

        public string NroOrder { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarOrden(int idOrden)
        {
            // Validar si el idOrden es válido
            if (idOrden == 0 || idOrden < 0)
            {
                ModelState.AddModelError("", "El número de orden no puede estar vacío o ser menor a 0.");
                return View();
            }

            // Buscar la orden en la base de datos
            var orden = _DbContext.Orders.Find(idOrden);
            if (orden == null)
            {
                ModelState.AddModelError("", "La orden no existe.");
                return View();
            }

            // Obtener los datos del cliente
            var customer = _DbContext.Customers.Find(orden.CustomerId);
            if (customer == null)
            {
                ModelState.AddModelError("", "El cliente no existe.");
                return View();
            }

            // Crear un modelo con los datos de la orden y el cliente
            var modelo = new OrderViewModel
            {
                OrderId = orden.OrderId,
                CustomerId = orden.CustomerId,
                CustomerName = customer.CompanyName,
                CustomerAddress = customer.Address
            };

            // Devolver una vista con el modelo
            return View(modelo);
        }


        //CODIGO QUE NO FUNCIONA DEBIDO A PROBLEMAS AL INTENTAR CONECTAR CON TABLA 'ORDER DETAILS'
        //A SU VEZ ELIMINE LO RELACIONADO CON ESTE CODIGO PARA QUE AL MENOS PARTE DEL MISMO PUEDA FUNCIONAR
        private IActionResult BuscarOrdenS(int idOrden)
        {
            // Validar si el idOrden es válido
            if (idOrden == 0 || idOrden < 0)
            {
                ModelState.AddModelError("", "El número de orden no puede estar vacío o ser menor a 0.");
                return View();
            }

            var order = _DbContext.Orders.FirstOrDefault(o => o.OrderId == idOrden);

            // Buscar la orden en la base de datos
            var orden = _DbContext.Orders.Find(idOrden);
            if (orden == null)
            {
                ModelState.AddModelError("", "La orden no existe.");
                return View();
            }

            //Si la orden es válida, obtener la información de la compañía del cliente
            var company = _DbContext.Customers
                .Where(c => c.CustomerId == order.CustomerId)
                .Select(c => new { c.CompanyName, c.Address })
                .FirstOrDefault();

            //ESTO NO FUNCIONA DEBIDO A QUE NO PUDE ESTABLECER LA CONEXION CON LA TABLA DE 'ORDER DETAILS'
            /*
            //Obtener la información de los productos pertenecientes a la orden, incluyendo la cantidad y el precio unitario
            var products = _DbContext.OrderDetails
                .Where(od => od.OrderId == idOrden)
                .Select(od => new
                {
                    od.Product.ProductName,
                    od.UnitPrice,
                    od.Quantity,
                    OtherOrders = _DbContext.OrderDetails
                    .Count(od2 => od2.ProductId == od.ProductId && od2.OrderId != idOrden)
                }).ToList();

            //Aqui retornaria una clase similar a OrderViewModel que contenga los campos correspondientes a Order Details y Products que fue lo que falto
            return new
            {
                CompanyName = company.CompanyName,
                Address = company.Address,
                Products = products
            };
            */
            return View(modelo);
        }

    }
}