using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV18T1021351.Web.Models
{
    /// <summary>
    /// Lớp cơ sở cho các model chứ dữ liệu dưới dạng phân trang
    /// </summary>
    public  class PaginationResultModel
    {
        /// <summary>
        /// trang hien tai
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// so dong tren 1 trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// gia tri tim kiem
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// so dong du lieu truy van duoc
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// so trang
        /// </summary>
        public int PageCount
        {
            get
            {
                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }
    }
}