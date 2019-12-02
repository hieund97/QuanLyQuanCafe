using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class fAdmin : Form
    {

        BindingSource foodList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            TotalLoad();
        }


        #region Method       

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }

        List<Category> SearchCategoryByName(string name)
        {
            List<Category> listCategory = CategoryDAO.Instance.SearchCategoryByName(name);
            return listCategory;
        }

        List<Table> SearchTableByName(string name)
        {
            List<Table> listTable = TableDAO.Instance.SearchTableByName(name);
            return listTable;
        }



        void TotalLoad()
        {

            dtgvFood.DataSource = foodList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            dtgvAccount.DataSource = accountList;
            LoadDateTimePickerBill();            
            LoadListFood();
            AddBindingFood();
            LoadCategoryInfo(cbFoodCategory);
            LoadListCategory();
            AddBindingCateogory();
            LoadListTable();
            AddBindingTable();
            LoadStatusTable(cbTableStatus);
            AddBindingAccount();
            LoadAccount();
            LoadTypeAccount(cbTypeAccount);
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, 1);

            //LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

      
       

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void LoadListBillByDateAndPage(DateTime checkIn, DateTime checkOut, int page)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(checkIn, checkOut, page);
           
        }

        void LoadCategoryInfo(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        void LoadStatusTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.GetStatusTable();
            cb.DisplayMember = "Status";           
        } 

        void LoadTypeAccount(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.GetTypeAccount();
            cb.DisplayMember = "Type";
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
            dtgvFood.Columns[0].Width = 50;
            dtgvFood.Columns[1].Width = 200;
            dtgvFood.Columns[2].Width = 50;
            dtgvFood.Columns[3].Width = 150;
        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
            dtgvTable.Columns[0].Width = 50;
            dtgvTable.Columns[1].Width = 180;
            dtgvTable.Columns[2].Width = 200;
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        
        



        void AddBindingFood()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }

        void AddBindingCateogory()
        {
            txbCategoryId.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        void AddBindingTable()
        {
            txbTableId.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            cbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }

        void AddBindingAccount()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            cbTypeAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }


        
        #endregion


        #region event

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, 1);
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FAdmin_Load(object sender, EventArgs e)
        {

            
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (dtgvFood.SelectedCells.Count > 0)
                {

                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value; // lấy ra 1 cells bất kỳ trong dtgv 

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;

                }
            }
            catch
            {

            }

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                 if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món ăn");
            }
        }

        private void btnDelFood_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int id = Convert.ToInt32(txbFoodID.Text);

                if (FoodDAO.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa món thành công");
                    LoadListFood();
                    if (deleteFood != null)
                        deleteFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa món ăn");
                }
            }

        }

        private void btnFindFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }


        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }


        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            categoryList.DataSource = SearchCategoryByName(txbSearchCategory.Text);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategory.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadListCategory();
                LoadCategoryInfo(cbFoodCategory);
                LoadListFood();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategory.Text;
            int id = Convert.ToInt32(txbCategoryId.Text);
            if(CategoryDAO.Instance.UpdateCategory(name, id))
            {
                MessageBox.Show("Cập nhật danh mục thành công");
                LoadListCategory();
                LoadCategoryInfo(cbFoodCategory);
                LoadListFood();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật danh mục");
            }
        }

        private void btnDelCategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int id = Convert.ToInt32(txbCategoryId.Text);

                if (CategoryDAO.Instance.DeleteCategory(id))
                {
                    MessageBox.Show("Xóa danh mục thành công");
                    LoadListCategory();
                    LoadCategoryInfo(cbFoodCategory);
                    LoadListFood();
                    if (deleteCategory != null)
                        deleteCategory(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa danh mục");
                }
            }
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }


        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            tableList.DataSource = SearchTableByName(txbSearchTable.Text);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTable.Text;
            string status = cbTableStatus.Text;
            if(TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
                LoadStatusTable(cbTableStatus);
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }

        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            string name = txbTable.Text;
            int id = Convert.ToInt32(txbTableId.Text);
            string status = cbTableStatus.Text;
            if (TableDAO.Instance.UpdateTable(name, id, status))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadListTable();
                LoadStatusTable(cbTableStatus);
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int id = Convert.ToInt32(txbTableId.Text);

                if (TableDAO.Instance.DeleteTable(id))
                {
                    MessageBox.Show("Xóa bàn thành công");
                    LoadListTable();
                    LoadStatusTable(cbTableStatus);
                    LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, 1);
                    if (deleteTable != null)
                        deleteTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa bàn ăn");
                }
            }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable  -= value; }
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            string name = txbSearchAccount.Text;
            accountList.DataSource = AccountDAO.Instance.SearchAccountByName(name);
        }


        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = cbTypeAccount.Text == "Admin" ? 1 : 0;
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản");
            }

        }

        private void btnDelAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {


                    if (AccountDAO.Instance.DeleteAccount(userName))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                        LoadAccount();
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản không được sửa");
                    }
                }
            }
           
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {

            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = cbTypeAccount.Text == "Admin" ? 1 : 0;
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Cập nhật tài khoản");
            }
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đặt lại mật khẩu?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string userName = txbUserName.Text;

                if (AccountDAO.Instance.ResetPassword(userName))
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công");
                    LoadAccount();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi đặt lại mật khẩu");
                }
            }
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 25;

            if (sumRecord % 25 != 0)
                lastPage++;

            txbPageBill.Text = lastPage.ToString();
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            if (page > 1)
                page--;
            txbPageBill.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            decimal page = Convert.ToInt32(txbPageBill.Text);
            decimal sumRecord = BillDAO.Instance.GetNumBillByDate(dtpkFromDate.Value, dtpkToDate.Value);            
            decimal totalPage = Math.Ceiling(sumRecord / 25); // hàm làm tròn + 1 ( 1.38 -> 2 || 2.1 -> 3)

            if (page < totalPage)
                page++;
            txbPageBill.Text = page.ToString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpkFromDate.Value;
            DateTime toDate = dtpkToDate.Value;
            fReport f = new fReport(fromDate, toDate);            
            f.ShowDialog();
            this.Show();
        }












        #endregion


    }
}
