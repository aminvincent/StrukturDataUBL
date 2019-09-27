using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingDekstopApps
{
    public partial class UserControlEmployee : UserControl
    {
        public UserControlEmployee()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fmInputMaster f = new fmInputMaster();
            f.lblFlag.Text = "new";
            f.ShowDialog();
        }

        public void LoadDataMaster()
        {
            try
            {
                //dataGridMaster.AutoGenerateColumns = false;
                dataGridMaster.DataSource = MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee);

                rdSortByCode.Checked = false;
                rdSoftByName.Checked = false;
                rdSortByAge.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void EditData()
        {
            try
            {
                if (dataGridMaster.RowCount > 0)
                {
                    int index = dataGridMaster.SelectedCells[0].RowIndex;
                    string code = (string)dataGridMaster["Code", index].Value;

                    var queryData = MasterProcessor.FindDataByCode(code, MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee));
                    using (fmInputMaster f = new fmInputMaster())
                    {
                        f.txtCode.Enabled = false;
                        f.txtCode.Text = queryData.Code;
                        f.txtName.Text = queryData.EmployeeName;
                        f.txtAge.Text = queryData.Age;
                        f.lblFlag.Text = "edit";
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RemoveItem()
        {
            try
            {
                if (dataGridMaster.RowCount > 0)
                {
                    int index = dataGridMaster.SelectedCells[0].RowIndex;
                    string code = (string)dataGridMaster["Code", index].Value;

                    bool found = false;
                    var checkExist = SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary);
                    foreach (var item in checkExist)
                    {
                        if (item.EmpCode.Trim().ToLower() == code.Trim().ToLower())
                            found = true;
                    }

                    if (!found)
                    {
                        DialogResult msg = MessageBox.Show("Do you want to delete this data?", "Confirmation", MessageBoxButtons.YesNo);
                        if (msg == DialogResult.Yes)
                        {
                            if (MasterProcessor.RemoveItemOnList(code, MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee)))
                                MessageBox.Show("Delete data successfull!");
                        } 
                    }
                    else
                    {
                        MessageBox.Show("Sorry! This data cannot be Delete, It is Relate to another!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataMaster();
        }

        private void UserControlMaster_Load(object sender, EventArgs e)
        {
            LoadDataMaster();

            rdSortByCode.Checked = false;
            rdSoftByName.Checked = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void DataGridMaster_DoubleClick(object sender, EventArgs e)
        {
            EditData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {           
            RemoveItem();
        }

        private void rdSortByCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSortByCode.Checked == true)
            {
                try
                {
                    dataGridMaster.DataSource = MasterProcessor.BubleSortingEmployee(MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee), "code");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void rdSoftByName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSoftByName.Checked == true)
            {
                try
                {
                    dataGridMaster.DataSource = MasterProcessor.BubleSortingEmployee(MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee), "name");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void RdSortByAge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSortByAge.Checked == true)
            {
                try
                {
                    dataGridMaster.DataSource = MasterProcessor.BubleSortingEmployee(MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee), "age");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
