using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Masa { get; set; }
        public string Tamaño { get; set; }
        public List<string> Ingredientes { get; set; }
        public string ListaIngredientes
        {
            get { return GetListaIngredientes(); }
        }
        public double Precio { get; set; }

        private Pizza() { }

        public Pizza(int id, string masa, string tamaño, List<string> ingredientes, double precio)
        {
            ID = id;
            Masa = masa;
            Tamaño = tamaño;
            Ingredientes = ingredientes;
            Precio = precio;
        }

        public string GetListaIngredientes()
        {
            string list = String.Empty;
            foreach (string item in Ingredientes)
            {
                if (list == "")
                    list = item;
                else
                    list += ", " + item;
            }
            return list;
        }
    }
}
