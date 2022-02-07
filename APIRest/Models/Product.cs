using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public Product()
        {

        }
        public Product(int id,string nombre,double precio, int cantidad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }
    }

}