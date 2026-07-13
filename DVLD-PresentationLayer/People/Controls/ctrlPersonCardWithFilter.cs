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

        public int PersonID { get { return _PersonID; } }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = _dtPeople;
            DataView dv = _dtPeople.DefaultView;

            string searchText = txtSearch.Text.Trim().ToString(); ;

            _PersonID = -1;
            _NationalNo = "";

            if (cbFindBy.SelectedIndex == (short)enFilterBy.NationalNo)
            {
                dv.RowFilter = $"NationalNo = '{searchText}'";
                //ctrlPersonDetails1.LoadPersonInfo()
                if (dv.Count == 0)
                {
                    ctrlPersonDetails1.ResetPersonCard();
                    
                    return;
                }

                _NationalNo = searchText.ToString();
                ctrlPersonDetails1.LoadPersonInfo(sender, _NationalNo);
                return;
            }

            if(cbFindBy.SelectedIndex == (short)enFilterBy.PersonID)
            {
                if (string.IsNullOrEmpty(searchText))
                    dv.RowFilter = $"PersonID = {-1}";
                else    
                    dv.RowFilter = $"PersonID = {searchText}";

                if(dv.Count  == 0)
                {
                    ctrlPersonDetails1.ResetPersonCard();
                    
                    return;
                }
 
                _PersonID = int.Parse(searchText);
                ctrlPersonDetails1.LoadPersonInfo(sender, _PersonID);
                return;

            }
                //ctrlPersonDetails1.LoadPersonInfo(sender,personID)
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
    }
}
