using SV18T1021351.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV18T1021351.Web.Models
{
    /// <summary>
    /// luu ket qua tim kiem va lay du lieu khach hang duoi dang phan trang
    /// </summary>
    public class CustomerPaginationResultModel : PaginationResultModel
    {
        public List<Customer> Data { get; set; }
    }
}