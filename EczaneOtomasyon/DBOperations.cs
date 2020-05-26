using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Bunifu.UI;

namespace EczaneOtomasyon
{
    class DBOperations
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eczane.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public DataSet getSearchedMedicine(string medicineName)
        {
            baglanti.Open();
            string query = "SELECT Ilaclar.BARKOD, Ilaclar.[ÜRÜN ADI], Ilaclar.[ETKİN MADDE]," +
                " Ilaclar.[RUHSAT SAHİBİ], Ilaclar.[RUHSAT TARİHİ], Ilaclar.[REÇETE TÜRÜ] " +
                "FROM Ilaclar WHERE [ÜRÜN ADI] LIKE '%" + medicineName + "%'";
            Console.WriteLine(query);
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Ilaclar");
            adtr.Dispose();
            baglanti.Close();

            return ds;
        }

        public Bunifu.UI.WinForms.BunifuDataGridView getAllMedicines(Bunifu.UI.WinForms.BunifuDataGridView dataGridView)
        {
            baglanti.Open();
            string query = "SELECT Ilaclar.BARKOD, Ilaclar.[ÜRÜN ADI], Ilaclar.[ETKİN MADDE],+" +
                " Ilaclar.[RUHSAT SAHİBİ], Ilaclar.[RUHSAT TARİHİ], Ilaclar.[REÇETE TÜRÜ] FROM Ilaclar";
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Ilaclar");
            dataGridView.DataSource = ds.Tables["Ilaclar"];
            adtr.Dispose();
            baglanti.Close();

            return dataGridView;
        }

    }
}
