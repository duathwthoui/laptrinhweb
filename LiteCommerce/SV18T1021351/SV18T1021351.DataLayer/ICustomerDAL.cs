using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021351.DomainModel; 

namespace SV18T1021351.DataLayer
{
    /// <summary>
    /// dinh nghia cac phep xu ly du lieu lien quan den khach hang
    /// </summary>
    public interface ICustomerDAL
    {
        /// <summary>
        /// tim kiem hien thi ds khach hang duoi dang phan trang
        /// </summary>
        /// <param name="page">so trang can hien thi</param>
        /// <param name="pageSize">so dong tren moi trang</param>
        /// <param name="searchValue">ten hoac dia chi can tim(chuoi rong neu lay toan bo)</param>
        /// <returns></returns>
        IList<Customer> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// dem xem co bao nhieu kh thoa dieu kien tim kiem
        /// </summary>
        /// <param name="searchValue">ten hoac dia chi can tim(chuoi rong neu lay toan bo)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lay thong tin cua 1 kh theo ma kh
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Customer Get(int customerID);
        /// <summary>
        /// bo sung 1 kh. Ham tra ve ma kh duoc bo sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Customer data);
        /// <summary>
        /// cap nhat 1 kh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Customer data);
        /// <summary>
        /// xoa 1 kh dua vao ma kh
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        bool Delete(int customerID);
        /// <summary>
        /// kiem tra xem 1 kh hien co du lieu lien quan khong
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        bool InUsed(int customerID);
    }
}
