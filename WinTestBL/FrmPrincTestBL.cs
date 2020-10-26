using AspCrudBE;
using AspCrudBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTestBL
{
    public partial class FrmPrincTestBL : Form
    {
        ProductBL productBL;
        public FrmPrincTestBL()
        {
            InitializeComponent();
            InitMyComponents();
        }

        private void InitMyComponents()
        {
            this.productBL = new ProductBL();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<ProductBE> lstProd;
            try
            {
                lstProd = this.productBL.ProductViewAll();
                var list = new BindingList<ProductBE>(lstProd);
                dgrView.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
