using SV18T1021351.DataLayer;
using SV18T1021351.DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV18T1021351.BusinessLayer
{
    /// <summary>
    /// các chức năng nghiệp vụ liên quan đến dữ liệu chung
    /// (nha cung cap, kh,nguoi giao hang,nhan vien,loai hang)
    /// </summary>
    public static class CommonDataService
    {
        private static readonly ICategoryDAL categoryDB;
        private static readonly ICustomerDAL customerDB;
        private static readonly ISupplierDAL supplierDB;
        private static readonly IShipperDAL shipperDB;
        private static readonly IEmployeeDAL employeeDB;

        /// <summary>
        /// constuctor
        /// </summary>
        static CommonDataService()
        {
            string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            switch (provider)
            {
                case "SQLServer":
                    categoryDB = new DataLayer.SQLServer.CategoryDAL(connectionString);
                    customerDB = new DataLayer.SQLServer.CustomerDAL(connectionString);
                    supplierDB = new DataLayer.SQLServer.SupplierDAL(connectionString);
                    shipperDB = new DataLayer.SQLServer.ShipperDAL(connectionString);
                    employeeDB = new DataLayer.SQLServer.EmployeeDAL(connectionString);
                    break;
                default:
                    categoryDB = new DataLayer.FakeDB.CategoryDAL();
                    break;
            }
        }

        /// <summary>
        /// lấy danh sách các loại hàng
        /// </summary>
        /// <returns></returns>
        ///

        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
            {
                if (page <= 0)
                    page = 1;
                rowCount = categoryDB.Count(searchValue);
                return categoryDB.List(page, pageSize, searchValue).ToList();
            } 
            /// <summary>
            /// tim kiem va lay ds kh
            /// </summary>
            /// <param name="page"></param>
            /// <param name="pageSize"></param>
            /// <param name="searchValue"></param>
            /// <param name="rowCount"></param>
            /// <returns></returns>
            public static List<Customer> ListOfCustomer(int page,int pageSize,string searchValue,out int rowCount)
            {
            //chưa can den
            if (page <= 0)
                page = 1;
                rowCount = customerDB.Count(searchValue);
                return customerDB.List(page, pageSize, searchValue).ToList();
            }

            public static List<Supplier> ListOfSupplier(int page, int pageSize, string searchValue, out int rowCount)
            {
                 if (page <= 0)
                page = 1;
                rowCount = supplierDB.Count(searchValue);
                return supplierDB.List(page, pageSize, searchValue).ToList();
            }
            public static List<Shipper> ListOfShipper(int page, int pageSize, string searchValue, out int rowCount)
            {
                if (page <= 0)
                    page = 1;
                rowCount = shipperDB.Count(searchValue);
                return shipperDB.List(page, pageSize, searchValue).ToList();

            }
            public static List<Employee> ListOfEmployee(int page, int pageSize, string searchValue, out int rowCount)
            {
                if (page <= 0)
                    page = 1;
                rowCount = employeeDB.Count(searchValue);
                return employeeDB.List(page, pageSize, searchValue).ToList();

            }

    }
}
