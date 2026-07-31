using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        clsApplication application;
        private void button1_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;

            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(30);
            //MessageBox.Show(application.ApplicationID.ToString()+" / "+application.ApplicantPersonID.ToString()+" / "+application.ApplicationDate.ToString()+" / "+
            //    application.ApplicationStatus.ToString()+" / "+ clsApplicationType.Find(application.ApplicationTypeID).ApplicationTypeTitle+" / "+
            //    "User: "+application.CreatedByUserID.ToString());

            //MessageBox.Show(LocalDrivingLicenseApplication.CreatedByUserID.ToString());


        }

        private void Test_Load(object sender, EventArgs e)
        {
            



            
        }
    }
}
