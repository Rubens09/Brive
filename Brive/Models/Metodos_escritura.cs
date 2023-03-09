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
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Routing;
using System.Xml;

namespace Brive.Models
{
    public class Metodos_escritura
    {
        #region Compra
        public static string compra(listado_compra listado_Compra)
        {
            string num_compra = (new Random().Next(0, 100)).ToString();
            DataTable tbl = new DataTable();
            SqlConnection conn = Metodos_lectura.Conexion_bd();
            SqlCommand cmd;
            SqlDataAdapter adaptadorSql;
            for (int i = 0; i < listado_Compra.Lista_compra.Count; i++)
            {
                cmd = new SqlCommand("", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "compra";
                conn.Open();
                cmd.Parameters.Add(new SqlParameter("@codigo_producto", listado_Compra.Lista_compra[i].codigo_producto));
                cmd.Parameters.Add(new SqlParameter("@id_sucursal", listado_Compra.sucursal));
                cmd.Parameters.Add(new SqlParameter("@num_venta", num_compra));
                cmd.Parameters.Add(new SqlParameter("@cantidad", 1));
                try
                {
                    adaptadorSql = new SqlDataAdapter(cmd);
                    adaptadorSql.Fill(tbl);
                }
                catch(Exception ex)
                {
                    num_compra = "0";
                }
                conn.Close();
            }
            return num_compra;
        }
        #endregion Compra
    }
}