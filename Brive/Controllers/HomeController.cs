using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Brive.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Brive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        #region Consultas
        [HttpGet("Listar_producto")]
        public listado_productos Listar_producto(string lista)
        {
            return Metodos_lectura.Listar_producto(lista);
        }
        [HttpGet("stock_producto")]
        public stock_producto list_stock_producto(int codigo_producto,int sucursal)
        {
            return Metodos_lectura.stock_producto(codigo_producto,sucursal);
        }
        [HttpGet("Listar_sucursal")]
        public listado_sucursales Listar_sucursal()
        {
            return Metodos_lectura.Listar_sucursal();
        }
        [HttpPost("Compra")]
        public string compra(listado_compra listado_Compra)
        {
            return Metodos_escritura.compra(listado_Compra);
        }
        public class busqueda_producto
        {
            public int codigo_producto { get; set; }
        }
        public class listado_productos
        {
            public List<productos> Lista_productos { get; set; }
        }
        public class productos
        {
            public int codigo_producto { get; set;}
            public string descripcion { get; set; }
            public int cantidad { get; set;}
            public string sucursal { get; set;}
        }
        public class listado_sucursales
        {
            public List<sucursales> Lista_sucursales { get; set; }
        }
        public class sucursales
        {
            public int id_sucursal { get; set; }
            public string sucursal { get; set; }
        }
        public class listado_compra
        {
            public int sucursal { get; set; }
            public List<productos_compra> Lista_compra { get; set; }
        }
        public class productos_compra
        {
            public int codigo_producto { get; set; }            
            public int cantidad { get; set; }
        }
        public class stock_producto
        {
            public int codigo_producto { get; set; }
            public string producto { get; set; }
            public double precio { get; set; }
            public int stock { get; set; }
            public string sucursal { get; set; }
        }
        #endregion Consultas
    }
}
