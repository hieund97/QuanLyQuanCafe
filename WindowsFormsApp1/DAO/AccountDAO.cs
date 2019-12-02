using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName, passWord });

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[]{userName, displayName, pass, newPass});
            return result > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Account where username = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public List<TypeAccount> GetTypeAccount()
        {
            List<TypeAccount> tableList = new List<TypeAccount>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT CASE WHEN Type = 0 THEN N'Nhân viên' WHEN Type = 1 THEN  N'Admin' END AS [Type] FROM dbo.Account");

            foreach (DataRow item in data.Rows)
            {
                TypeAccount table = new TypeAccount(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public DataTable GetListAccount()
        {
           return  DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, CASE WHEN Type = 0 THEN N'Nhân viên' WHEN Type = 1 THEN N'Admin' END AS Type FROM dbo.Account");
        }

        public DataTable SearchAccountByName(string name)
        {
           
            string query = string.Format("SELECT UserName, DisplayName, CASE WHEN Type = 0 THEN N'Nhân viên' WHEN Type = 1 THEN N'Admin' END AS Type FROM dbo.Account WHERE UserName like N'%{0}%' or DisplayName LIKE N'%{0}%'", name);
            return DataProvider.Instance.ExecuteQuery(query);
            
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT INTO dbo.Account( UserName ,DisplayName ,Type) VALUES  ( N'{0}' , N'{1}' , N'{2}')", userName, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount( string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET  DisplayName = N'{0}', Type = {1} WHERE username = N'{2}'",  displayName, type, userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE dbo.Account WHERE username = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string userName)
        {
            string query = string.Format("Update dbo.Account set password = N'123456' WHERE username = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
