using SV18T1021351.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV18T1021351.Web.Models
{
    public class CategoryPaginationResultModel : PaginationResultModel
    {
        public List<Category> Data { get; set; }
    }
}