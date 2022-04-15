using SV18T1021351.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV18T1021351.DataLayer.SQLServer
{
    /// <summary>
    /// kế thừa interface
    /// </summary>
    public class CategoryDAL : _BaseDAL, ICategoryDAL
    {
        public CategoryDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Category data)
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
                                    from Categories
                                    where (@searchValue = N'')
                                    or (
                                        (CategoryName like @searchValue)
                                        or
                                        (Description like @searchValue)                                        
                                    )";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

            }
            return count;
        }

        public bool Delete(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int categoryID)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int categoryID)
        {
            throw new NotImplementedException();
        }

        public IList<Category> List(int page, int pageSize, string searchValue)
        {
            List<Category> data = new List<Category>();

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                            from
                            (
                                select    *,
                                        row_number() over(order by CategoryName) as RowNumber
                                from    Categories
                                where    (@searchValue = N'')
                                    or (
                                            (CategoryName like @searchValue)
                                            or
                                            (Description like @searchValue)
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
                    data.Add(new Category()
                    {
                        CategoryID = Convert.ToInt32(dbReader["CategoryID"]),
                        CategoryName = Convert.ToString(dbReader["CategoryName"]),
                        Description = Convert.ToString(dbReader["Description"]),
                        ParentCategoryID = Convert.ToString(dbReader["ParentCategoryID"])
                    });
                }
                dbReader.Close();
                cn.Close();
            }

            return data;
        }

        public bool Update(Category data)
        {
            throw new NotImplementedException();
        }
    }
}
