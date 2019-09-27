using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingDekstopApps
{
    public partial class fmInputSalary : Form
    {
        public fmInputSalary()
        {
            InitializeComponent();

            //calling load employee in constructor
            LoadEmployee();

            //System.Text.RegularExpressions.Regex.IsMatch(txtTax.Text, "[ ^ 0-9]");
            //System.Text.RegularExpressions.Regex.IsMatch(txtSalary.Text, "[ ^ 0-9]");

        }

        public void LoadEmployee()
        {
            try
            {
                cbEmployee.DisplayMember = "EmployeeName";
                cbEmployee.ValueMember = "Code";
                cbEmployee.DataSource = MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void InsertData()
        {
            try
            {
                SalaryModel model = new SalaryModel()
                {
                    SalaryId = lblSalaryId.Text.Trim(),
                    Salary = txtSalary.Text.Trim(),
                    Tax = txtTax.Text.Trim(),
                    Total = txtTotal.Text.Trim(),
                    EmpCode = cbEmployee.SelectedValue.ToString()
                };
                if (SalaryProcessor.InsertDataIntoCsv(model))
                    MessageBox.Show("Insert Data Successfull!");
                else
                    MessageBox.Show("Failed Insert Data!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("failed InsertData: " + ex.Message.ToString());
            }
        }

        private void UpdateData()
        {
            try
            {
                SalaryModel model = new SalaryModel()
                {
                    Salary = txtSalary.Text.Trim(),
                    Tax = txtTax.Text.Trim(),
                    Total = txtTotal.Text.Trim(),
                    EmpCode = cbEmployee.SelectedValue.ToString()
                };
                if (SalaryProcessor.UpdateDataIntoCsv(lblSalaryId.Text.Trim(), SalaryProcessor.loadCsvFileSalary(SalaryProcessor.pathSalary), model))
                    MessageBox.Show("Update Data Successfull!");
                else
                    MessageBox.Show("Failed Update Data!");

                //var principalForm = Application.OpenForms.OfType<UserControlMaster>().FirstOrDefault();
                //principalForm.LoadDataMaster();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("failed UpdateData: " + ex.Message.ToString());
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FmInputSalary_Load(object sender, EventArgs e)
        {
            //LoadEmployee();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            switch (lblFlag.Text.Trim())
            {
                case "new":
                    InsertData();
                    break;
                case "edit":
                    UpdateData();
                    break;
            }
        }

        private int CalcTotal(int a = 0, int b = 0)
        {
            return a - b;
        }

        private void TxtTax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = CalcTotal(txtSalary.Text == string.Empty ? 0 : Convert.ToInt32(txtSalary.Text), txtTax.Text == string.Empty ? 0 : Convert.ToInt32(txtTax.Text)).ToString();
            }
            catch (Exception ex)
            {
                txtTax.Text = "0";
                if (ex.Message.ToString().Contains("Input string was not in a correct format."))
                    MessageBox.Show("Only Number is Allowed!");
                else
                    MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TxtSalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = CalcTotal(txtSalary.Text == string.Empty ? 0 : Convert.ToInt32(txtSalary.Text), txtTax.Text == string.Empty ? 0 : Convert.ToInt32(txtTax.Text)).ToString();
            }
            catch (Exception ex)
            {
                txtSalary.Text = "0";
                if (ex.Message.ToString().Contains("Input string was not in a correct format."))
                    MessageBox.Show("Only Number is Allowed!");
                else
                    MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
