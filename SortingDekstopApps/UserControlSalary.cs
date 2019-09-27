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
    public partial class UserControlSalary : UserControl
    {
        public UserControlSalary()
        {
            InitializeComponent();
        }

        
        public void LoadDataSalary()
        {
            try
            {
                List<SalaryModel> salary = SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary);
                List<EmployeeModel> employee = MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee);

                dataGridSalary.DataSource = SalaryProcessor.MergeSalary(salary, employee);

                rdSortByCode.Checked = false;
                rdSortByName.Checked = false;
                rdSortBySalary.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void EditData()
        {
            try
            {
                if (dataGridSalary.RowCount > 0)
                {
                    int index = dataGridSalary.SelectedCells[0].RowIndex;
                    string SalaryId = (string)dataGridSalary["SalaryId", index].Value;

                    var result = SalaryProcessor.FindDataBySalaryId(SalaryId, SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary));

                    using (fmInputSalary f = new fmInputSalary())
                    {
                        f.lblSalaryId.Text = result.SalaryId;
                        f.cbEmployee.SelectedValue = result.EmpCode;//still in problem
                        f.txtSalary.Text = result.Salary;
                        f.txtTax.Text = result.Tax;
                        f.txtTotal.Text = result.Total;
                        f.lblFlag.Text = "edit";
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveItem()
        {
            try
            {
                if (dataGridSalary.RowCount > 0)
                {
                    int index = dataGridSalary.SelectedCells[0].RowIndex;
                    string SalaryId = (string)dataGridSalary["SalaryId", index].Value;

                    DialogResult msg = MessageBox.Show("Do you want to delete this data?", "Confirmation", MessageBoxButtons.YesNo);
                    if (msg == DialogResult.Yes)
                    {
                        if (SalaryProcessor.RemoveItemOnList(SalaryId, SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary)))
                            MessageBox.Show("Delete data successfull!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                fmInputSalary f = new fmInputSalary();
                f.lblFlag.Text = "new";
                f.lblSalaryId.Text = SalaryProcessor.LastSalaryId().ToString();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataSalary();
        }

        private void UserControlSalary_Load(object sender, EventArgs e)
        {
            LoadDataSalary();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void DataGridSalary_DoubleClick(object sender, EventArgs e)
        {
            EditData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void RdSortByCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSortByCode.Checked == true)
            {
                try
                {
                    List<SalaryModel> salary = SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary);
                    List<EmployeeModel> employee = MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee);

                    dataGridSalary.DataSource = SalaryProcessor.BubleSortingSalary(SalaryProcessor.MergeSalary(salary, employee), "code");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void RdSortBySalary_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSortBySalary.Checked == true)
            {
                try
                {
                    List<SalaryModel> salary = SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary);
                    List<EmployeeModel> employee = MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee);

                    dataGridSalary.DataSource = SalaryProcessor.BubleSortingSalary(SalaryProcessor.MergeSalary(salary, employee), "salary");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void RdSortByName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSortByName.Checked == true)
            {
                try
                {
                    List<SalaryModel> salary = SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary);
                    List<EmployeeModel> employee = MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee);

                    dataGridSalary.DataSource = SalaryProcessor.BubleSortingSalary(SalaryProcessor.MergeSalary(salary, employee), "name");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
