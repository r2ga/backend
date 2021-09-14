using backend.Context;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        //private readonly AppDbContext context;
        //public PedidosController(AppDbContext context)
        //{
        //    this.context = context;
        //}

        // GET: api/<PedidosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                Pedido pedido = new Pedido();
                List<string> ingredientes = new List<string>();
                ingredientes.Add("Jamon");
                Pizza pizza = new Pizza(1, "Sartén", "Mediana", ingredientes, 120);
                pedido.Pedidos.Add(pizza);

                return Ok(pedido.Pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}", Name = "GetPedido")]
        public ActionResult Get(int id)
        {
            try
            {
                List<string> ingredientes = new List<string>();
                ingredientes.Add("Peperoni");
                ingredientes.Add("Jamon");
                Pizza pizza = new Pizza(1, "Original", "Grande", ingredientes, 90);
                return Ok(pizza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PedidosController>
        [HttpPost]
        public ActionResult Post([FromBody] object pizza)
        {
            try
            {
                Pizza p = JsonConvert.DeserializeObject<Pizza>(pizza.ToString());
                return Ok(pizza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pizza pizza)
        {
            try
            {
                if (id == 0)
                {
                    Pedido pedido = new Pedido();

                    if (pedido.Pedidos[0].Masa != pizza.Masa)
                        pedido.Pedidos[0].Masa = pizza.Masa;
                    if (pedido.Pedidos[0].Tamaño != pizza.Tamaño)
                        pedido.Pedidos[0].Tamaño = pizza.Tamaño;
                    if (pedido.Pedidos[0].Ingredientes != pizza.Ingredientes)
                        pedido.Pedidos[0].Ingredientes = pizza.Ingredientes;
                    if (pedido.Pedidos[0].Precio != pizza.Precio)
                        pedido.Pedidos[0].Precio = pizza.Precio;

                    return Ok(pedido.Pedidos[0]);
                }
                else
                {
                    return BadRequest("No se encontro ese id, intente con el numero 0.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido.Pedidos.RemoveAt(0);

                return Ok("Se elimino el pedido 0");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
