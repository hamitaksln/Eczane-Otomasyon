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
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eczane.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        DBOperations dbOperations = new DBOperations();

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void listele()
        {
            baglanti.Open();
            string query = "SELECT Ilaclar.BARKOD, Ilaclar.[ÜRÜN ADI], Ilaclar.[ETKİN MADDE],+" +
                " Ilaclar.[RUHSAT SAHİBİ], Ilaclar.[RUHSAT TARİHİ], Ilaclar.[REÇETE TÜRÜ] FROM Ilaclar";
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            adtr.Fill(ds, "Ilaclar");
            medicinesDataGridView.DataSource = ds.Tables["Ilaclar"];
            adtr.Dispose();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            medicinesDataGridView = dbOperations.getAllMedicines(medicinesDataGridView);
        }

        private void searchMedicineTextBox_TextChange(object sender, EventArgs e)
        {
            if(searchMedicineTextBox.Text.Length >=3)
            {
                ds.Clear();
                ds = dbOperations.getSearchedMedicine(searchMedicineTextBox.Text);
                medicinesDataGridView.DataSource = ds.Tables["Ilaclar"];
            } else if(searchMedicineTextBox.Text.Length == 0)
            {
                medicinesDataGridView = dbOperations.getAllMedicines(medicinesDataGridView);
            }

        }

    }
}
