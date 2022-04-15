using SV18T1021351.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV18T1021351.DataLayer.SQLServer
{
    public class ShipperDAL : _BaseDAL, IShipperDAL
    {
        public ShipperDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Shipper data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            int count = 0;
            if (searchValue != "")
                searchValue = "%" + searchValue + "%";
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select count(*)                                  
                                    from Shippers
                                    where (@searchValue = N'')
                                    or (
                                        (ShipperName like @searchValue)
                                        or
                                        (Phone like @searchValue)
                                    )";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

            }
            return count;
        }

        public bool Delete(int shipperID)
        {
            throw new NotImplementedException();
        }

        public Shipper Get(int shipperID)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int shipperID)
        {
            throw new NotImplementedException();
        }

        public IList<Shipper> List(int page, int pageSize, string searchValue)
        {
            {
                List<Shipper> data = new List<Shipper>();

                if (searchValue != "")
                    searchValue = "%" + searchValue + "%";

                using (SqlConnection cn = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"select *
                            from
                            (
                                select    *,
                                        row_number() over(order by ShipperName) as RowNumber
                                from    Shippers
                                where    (@searchValue = N'')
                                    or (
                                            (ShipperName like @searchValue)
                                            or
                                            (Phone like @searchValue)
                                        )
                            ) as t
                        where    t.RowNumber between (@page - 1) * @pageSize + 1 and @page * @pageSize
                        order by t.RowNumber";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@page", page);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);

                    var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (dbReader.Read())
                    {
                        data.Add(new Shipper()
                        {
                            ShipperID = Convert.ToInt32(dbReader["ShipperID"]),
                            ShipperName = Convert.ToString(dbReader["ShipperName"]),
                            Phone = Convert.ToString(dbReader["Phone"]),
                        });
                    }
                    dbReader.Close();
                    cn.Close();
                }

                return data;
            }
        }

        public bool Update(Shipper data)
        {
            throw new NotImplementedException();
        }
    }
}
