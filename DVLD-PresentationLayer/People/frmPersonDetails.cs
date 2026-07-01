using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmPersonDetails : Form
    {
        int _PersonID;
        string _NationalNo;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.LoadPersonInfo(sender,_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
