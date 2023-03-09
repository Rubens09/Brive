using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static Brive.Controllers.HomeController;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Policy;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Routing;

namespace Brive.Models
{
    public class Metodos_lectura
    {
        #region Conexion_BD
        public static SqlConnection Conexion_bd()
        {
            string sqry = "";
            var cadenaConexion = "Server = MSI-PROGRAMACIO;Database = bd_brive; Connection Timeout = 2; Pooling = false;User ID = sa; Password = P4ssw0rd.; Trusted_Connection = False";
            SqlConnection conn = new SqlConnection(cadenaConexion);
            return conn;
        }
        #endregion Conexion_BD
        #region Producto
        public static listado_productos Listar_producto(string lista)
        {
            DataTable tbl = new DataTable();
            SqlConnection conn = Conexion_bd();
            SqlCommand cmd;
            SqlDataAdapter adaptadorSql;
            cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Buscar_producto";
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@codigo_producto", lista));
            adaptadorSql = new SqlDataAdapter(cmd);
            adaptadorSql.Fill(tbl);
            conn.Close();
            listado_productos listado=new listado_productos();
            listado.Lista_productos = new List<productos>();
            foreach (DataRow row in tbl.Rows)
            {
                productos items=new productos();
                items.codigo_producto = Convert.ToInt32(row["codigo_producto"]);
                items.descripcion = row["producto"].ToString();
                items.cantidad = Convert.ToInt32(row["cantidad"]);
                items.sucursal = row["sucursal"].ToString();
                listado.Lista_productos.Add(items);
            }
            return listado;
        }
        public static stock_producto stock_producto(int codigo_producto, int sucursal)
        {
            DataTable tbl = new DataTable();
            SqlConnection conn = Conexion_bd();
            SqlCommand cmd;
            SqlDataAdapter adaptadorSql;
            cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "stock_producto";
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@codigo_producto", codigo_producto));
            cmd.Parameters.Add(new SqlParameter("@id_sucursal", sucursal));
            adaptadorSql = new SqlDataAdapter(cmd);
            adaptadorSql.Fill(tbl);
            conn.Close();
            stock_producto lista=new stock_producto();
            foreach (DataRow row in tbl.Rows)
            {
                lista.codigo_producto = Convert.ToInt32(row["codigo_producto"]);
                lista.producto = row["producto"].ToString();
                lista.precio = Convert.ToDouble(row["precio"]);
                lista.stock = Convert.ToInt32(row["stock"]);
                lista.sucursal = row["sucursal"].ToString();
            }
            return lista;
        }
        #endregion Producto
        #region Sucursal
        public static listado_sucursales Listar_sucursal()
        {
            DataTable tbl = new DataTable();
            SqlConnection conn = Conexion_bd();
            SqlCommand cmd;
            SqlDataAdapter adaptadorSql;
            cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Listar_sucursal";
            conn.Open();
            adaptadorSql = new SqlDataAdapter(cmd);
            adaptadorSql.Fill(tbl);
            conn.Close();
            listado_sucursales listado = new listado_sucursales();
            listado.Lista_sucursales = new List<sucursales>();
            foreach (DataRow row in tbl.Rows)
            {
                sucursales items= new sucursales();
                items.id_sucursal = Convert.ToInt32(row["id_sucursal"]);
                items.sucursal = row["sucursal"].ToString();
                listado.Lista_sucursales.Add(items);
            }
            return listado;
        }
        #endregion Sucursal
    }
}