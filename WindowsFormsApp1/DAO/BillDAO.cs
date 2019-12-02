using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
           private set { BillDAO.instance = value; }
        }
        private BillDAO() { }


        // thành công: BillID
        // thất bại: -1
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND Status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1; // tương đương ko có kết quả
        }

        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET DateCheckOut = GETDATE(), Status = 1," + " discount =" + discount + ",totalPrice = " + totalPrice + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @checkin , @checkout", new object[]{ checkIn, checkOut });
        }

        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDateAndPage @checkin , @checkout , @page", new object[] { checkIn, checkOut, pageNum });
        }

        public int GetNumBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int) DataProvider.Instance.ExecuteScalar("EXEC USP_GetNumBillByDate @checkin , @checkout", new object[] { checkIn, checkOut });
        }

        public int GetMaxIDBill()
        {
            // trong trường hợp không có bất kỳ bill nào thì lấy ra ID bằng 1
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
