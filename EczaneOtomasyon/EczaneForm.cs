using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.Data.OleDb;

namespace EczaneOtomasyon
{
    public partial class EczaneForm : MaterialSkin.Controls.MaterialForm
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eczane.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        DBOperations dBOperations = new DBOperations();

        public EczaneForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            medicinesDataGridView = dBOperations.getAllMedicines(medicinesDataGridView);
        }

        private void searchMedicineTextBox_TextChange(object sender, EventArgs e)
        {
            if(searchMedicineTextBox.Text.Length >=3)
            {
                ds.Clear();
                ds = dBOperations.getSearchedMedicine(searchMedicineTextBox.Text);
                medicinesDataGridView.DataSource = ds.Tables["Ilaclar"];
            } else if(searchMedicineTextBox.Text.Length == 0)
            {
                medicinesDataGridView = dBOperations.getAllMedicines(medicinesDataGridView);
            }

        }

    }
}
