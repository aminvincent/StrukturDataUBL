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
    public partial class fmInputMaster : Form
    {
        public fmInputMaster()
        {
            InitializeComponent();
        }

        private void InsertData()
        {
            try
            {
                EmployeeModel model = new EmployeeModel()
                {
                    Code = txtCode.Text.Trim(),
                    EmployeeName = txtName.Text.Trim(),
                    Age = txtAge.Text.Trim()
                };
                if (MasterProcessor.InsertDataIntoCsv(model))
                    MessageBox.Show("Insert Data Successfull!");
                else
                    MessageBox.Show("Failed Insert Data!");
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed InsertData: "+ ex.Message.ToString());
            }
        }

        private void UpdateData()
        {
            try
            {
                EmployeeModel model = new EmployeeModel()
                {
                    //Code = txtCode.Text.Trim(),
                    EmployeeName = txtName.Text.Trim(),
                    Age = txtAge.Text.Trim()
                };
                if (MasterProcessor.UpdateDataIntoCsv(txtCode.Text.Trim(), MasterProcessor.loadCsvFileEmployee(MasterProcessor.pathEmployee), model))
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
    }
}
