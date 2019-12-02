using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class Table
    {
        public Table(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }        

        public Table(DataRow Row)
        {
            this.ID = (int)Row["id"];
            this.Name = Row["name"].ToString();
            this.Status = Row["status"].ToString();
        }       

        private string status;
        private string name;

        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }

    public class TableStatus
    {
        public TableStatus(DataRow Row)
        {            
            this.Status = Row["status"].ToString();
        }

        private string status;

        public string Status { get => status; set => status = value; }
    }
}
