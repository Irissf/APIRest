using APIRest.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{

    public class ProductsController : ApiController
    {
        private MySqlConnection conection = new MySqlConnection();
        private List<Product> productos = new List<Product>();
        private Product producto;

        //https://localhost:44366/api/products
        public List<Product> GetAllProducts()
        {
            ProductosBD();
            return productos;
        }
      
        //https://localhost:44366/api/products/id
        public IHttpActionResult GetProduct(int id)
        {
            abrirConexion();
            ProductosBD();

            try
            {
                producto = productos[id-1];
                //cambiarlo a un id, del select, no sobre el objeto, esto solo es una prueba
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

            cerrarConexion();
            return Ok(producto);
        }



        #region BASE DATOS
        public void ProductosBD()
        {
            abrirConexion();

            try
            {
                MySqlDataReader reader = null;
                MySqlCommand cm = new MySqlCommand("select * from productos", conection);
                reader = cm.ExecuteReader();

                while (reader.Read())
                {
                    producto = new Product();
                    producto.Id = Convert.ToInt32(reader["id"].ToString());
                    producto.Nombre = reader["nombre"].ToString();
                    producto.Precio = Convert.ToDouble(reader["precio"].ToString());
                    producto.Cantidad = Convert.ToInt32(reader["cantidad"].ToString());

                    productos.Add(producto);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

            cerrarConexion();
        }

        public void abrirConexion()
        {
            string servidor = "localhost";
            string bd = "pruebaapi";
            string usuario = "root";
            string password = "";
            string puerto = "3306";

            string cadenaConexion = "server=" + servidor + ";port=" + puerto + ";user id=" + usuario + ";password=" + password + ";database=" + bd + ";";

            try
            {
                conection.ConnectionString = cadenaConexion;
                conection.Open();
                Console.WriteLine("conectado");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void cerrarConexion()
        {
            conection.Close();
        }

        #endregion
    }
}
