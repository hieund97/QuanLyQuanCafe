using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;

        private TableDAO() { }


        public void SwitchTable(int id1, int id2)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public List<TableStatus> GetStatusTable()
        {
            List<TableStatus> tableList = new List<TableStatus>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT status FROM dbo.TableFood GROUP BY status");

            foreach (DataRow item in data.Rows)
            {
                TableStatus table = new TableStatus(item);
                tableList.Add(table);
            }

            return tableList;
        }


        public List<Table> SearchTableByName(string name)
        {
            List<Table> list = new List<Table>();
            string query = string.Format("Select * from TableFood where name like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }

        public bool InsertTable(string name, string status)
        {
            string query = string.Format("INSERT INTO dbo.TableFood ( name, status ) VALUES  ( N'{0}', N'{1}')", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(string name, int id, string status)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}', status = N'{1}' WHERE id = {2}", name, status, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable (int idTable)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteConnectTableBill @idTable", new object[] { idTable });

            return result > 0;
        }
    }
}
