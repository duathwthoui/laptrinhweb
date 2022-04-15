using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV18T1021351.DataLayer.SQLServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class _BaseDAL
    {
        /// <summary>
        /// chuoi tham so ket noi csdl sqlsever
        /// </summary>
        protected string _connectionString;

        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
            
        }
        /// <summary>
        /// tao va mo 1 ket noi den csdl
        /// </summary>
        /// <returns></returns>
        protected SqlConnection OpenConnection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = _connectionString;
            cn.Open();
            return cn;
        }
    }
}
