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
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        public fmMain FMainWindow;
        public Form FFrameWindow;

        public enum MenuAplikasi
        {
            Menu1,
            Menu2,
            Menu3
        };

        private Control newctrl = null;
        private static Dictionary<MenuAplikasi, Control> controls = new Dictionary<MenuAplikasi, Control>();
        public void ShowControl(MenuAplikasi ma)
        {
            if (newctrl != null)
                newctrl.Hide();

            if (controls.ContainsKey(ma))
            {
                newctrl = controls[ma];
            }
            else
            {
                newctrl = CreateCtrl(ma);
                controls[ma] = newctrl;
            }

            newctrl.Dock = DockStyle.Fill;
            newctrl.Parent = FFrameWindow;
            newctrl.BringToFront();
            newctrl.Show();
        }

        private Control CreateCtrl(MenuAplikasi ma)
        {
            switch (ma)
            {
                case MenuAplikasi.Menu1:
                    return new UserControlEmployee();
                case MenuAplikasi.Menu2:
                    return new UserControlSalary();
                default:
                    return null;
            }
        }

        private void BtnMenuMaster_Click(object sender, EventArgs e)
        {
            //fmMaster f = new fmMaster(); 
            //f.Show();
            ShowControl(MenuAplikasi.Menu1);

        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            FFrameWindow = new Form();
            FFrameWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            FFrameWindow.MdiParent = this;
            FFrameWindow.Dock = DockStyle.Fill;
            FFrameWindow.Show();

            // default tampilkan menu 1
            ShowControl(MenuAplikasi.Menu1);
        }

        private void BtnSalary_Click(object sender, EventArgs e)
        {
            ShowControl(MenuAplikasi.Menu2);
        }
    }
}
