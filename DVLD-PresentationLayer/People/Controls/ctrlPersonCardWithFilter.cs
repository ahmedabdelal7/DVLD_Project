using DVLD.Common_Classes;
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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        DataTable _dtPeople;
        int _PersonID = -1;
        string _NationalNo = ""; 
        enum enFilterBy
        {
            NationalNo=0, PersonID =1
        }

        enFilterBy _SelectedFilter = enFilterBy.PersonID;

        public int PersonID { get { return _PersonID; } }
        public string NationalNo { get { return _NationalNo; } }
        public short SelectedFilter { get { return (short)_SelectedFilter; } }

        //public bool DisableFilter { get; set; }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = _dtPeople;
            
            string searchText = txtSearch.Text.Trim().ToString(); ;

            _PersonID = -1;
            _NationalNo = "";

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please choose person first!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlPersonDetails1.ResetPersonCard();
                return;
            }


            if (_SelectedFilter == enFilterBy.NationalNo)
            {
                string NationalNo = searchText;

                if (!clsPerson.IsExist(NationalNo))
                {
                    MessageBox.Show("This person does not exist!","Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    ctrlPersonDetails1.ResetPersonCard();
                    return;
                }

                _NationalNo = NationalNo;
                _PersonID = clsPerson.Find(_NationalNo).PersonID;
                ctrlPersonDetails1.LoadPersonInfo( _NationalNo);
                return;
            }

            if(_SelectedFilter == enFilterBy.PersonID)
            {
                int PersonID = int.Parse(searchText);

                if (!clsPerson.IsExist(PersonID))
                {
                    MessageBox.Show("This person does not exist!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonDetails1.ResetPersonCard();
                    return;
                }

                _PersonID = PersonID;
                _NationalNo = clsPerson.Find(_PersonID).NationalNo;
                ctrlPersonDetails1.LoadPersonInfo(_PersonID);
                return;

            }
                //ctrlPersonDetails1.LoadPersonInfo(sender,personID)
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            _dtPeople  = clsPerson.ListAllPeople();
            cbFindBy.SelectedIndex = 1;

        }

        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFindBy.SelectedIndex == (short)enFilterBy.PersonID)
                e.Handled = !clsValidate.IsValidInteger(sender, e);

        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFindBy.SelectedItem.ToString() == "PersonID")
            {
                _SelectedFilter = enFilterBy.PersonID;
            }else
                _SelectedFilter = enFilterBy.NationalNo;

        }

        public void LoadPersonInfo(int PersonID)
        {
            if (PersonID == -1) {
                return;
            }
            _PersonID=PersonID;
            _NationalNo = "";

            txtSearch.Text = PersonID.ToString();
            cbFindBy.SelectedIndex = (short)enFilterBy.PersonID;

            ctrlPersonDetails1.LoadPersonInfo(PersonID);

        }

        public void DisableFilter()
        {
            gbFilter.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.DataBack += LoadPersonInfo;
            frmAddEditPerson.ShowDialog();
        }
    }
}
