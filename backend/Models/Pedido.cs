using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Pedido
    {
        public List<Pizza> Pedidos { get; set; }

        public Pedido()
        {
            List<string> ingredientes = new List<string>();
            ingredientes.Add("Peperoni");
            ingredientes.Add("Jamon");
            Pizza pizza = new Pizza(0, "Original", "Grande", ingredientes, 90);

            Pedidos = new List<Pizza>();
            Pedidos.Add(pizza);
        }
    }
}
