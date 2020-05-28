using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Bunifu.UI;
using Bunifu.UI.WinForms;

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
            string query = "SELECT Ilaclar.Id, Ilaclar.Barkod, Ilaclar.UrunAdi, Ilaclar.EtkinMadde, Ilaclar.ReceteTuru," +
                " Ilaclar.KullanimYasi, Ilaclar.Fiyat FROM Ilaclar " +
                "WHERE (((Ilaclar.UrunAdi) Like '%" + medicineName + "%'))";

            Console.WriteLine(query);
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Ilaclar");
            adtr.Dispose();
            baglanti.Close();

            return ds;
        }
        public DataSet getSearchedPatient(string patient)
        {
            baglanti.Open();
            string query = "SELECT Hasta.Ad, Hasta.Soyad, Hasta.HastaTc as TC, Hasta.SigortaTuru as Sigorta, Hasta.DogumTarihi as [Doğum Tarihi], " +
                "Ilceler.Ilce as İlçe, Sehirler.İl as İl FROM (Ilceler INNER JOIN Hasta ON Ilceler.IlceId = Hasta.IlceId) INNER JOIN Sehirler ON " +
                "Ilceler.İl = Sehirler.[Plaka Kodu] WHERE (((Hasta.HastaTc) Like '%" + patient + "%') OR ((Hasta.Ad) Like '%" + patient + "%'))";
            Console.WriteLine(query);
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Hasta");
            adtr.Dispose();
            baglanti.Close();

            return ds;
        }

        public BunifuDataGridView getAllMedicines(BunifuDataGridView dataGridView)
        {
            baglanti.Open();
            string query = "SELECT Ilaclar.Id, Ilaclar.Barkod, Ilaclar.UrunAdi, Ilaclar.EtkinMadde, Ilaclar.ReceteTuru, Ilaclar.KullanimYasi, Ilaclar.Fiyat FROM Ilaclar";
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Ilaclar");
            dataGridView.DataSource = ds.Tables["Ilaclar"];
            adtr.Dispose();
            baglanti.Close();

            return dataGridView;
        }

        public BunifuDataGridView getAllPatients(BunifuDataGridView dataGridView)
        {
            baglanti.Open();
            string query = "SELECT Hasta.Ad, Hasta.Soyad, Hasta.HastaTc as TC, Hasta.SigortaTuru as Sigorta, Hasta.DogumTarihi as [Doğum Tarihi], " +
                "Ilceler.Ilce as İlçe, Sehirler.İl as İl FROM (Ilceler INNER JOIN Hasta ON Ilceler.IlceId = Hasta.IlceId) INNER JOIN Sehirler ON " +
                "Ilceler.İl = Sehirler.[Plaka Kodu]";
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Hasta");
            dataGridView.DataSource = ds.Tables["Hasta"];

            adtr.Dispose();
            baglanti.Close();

            return dataGridView;
        }

        public void insertRecipeToDatabase(int doctorId, string hastaTc, BunifuDataGridView dataGridView,Bunifu.UI.WinForms.BunifuLabel recipeNoLabel)
        {
            DateTime now = DateTime.Now;
            string query = "Insert Into Recete(YazanDoktorId,Tarih,HastaTCKimlikNo) Values ('1','" + now.ToString("dd/MM/yyyy") + "','" + hastaTc + "')";
            komut.Connection = baglanti;
            komut.CommandText = query;
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();

            string query1 = "SELECT Recete.ReceteId FROM Recete GROUP BY Recete.ReceteId ORDER BY Recete.ReceteId DESC";
            OleDbDataAdapter adtr = new OleDbDataAdapter(query1, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Hasta");
            int recipeId = Convert.ToInt32(ds.Tables["Hasta"].Rows[0]["ReceteId"]);
            recipeNoLabel.Text = "Reçete No: " + recipeId;
            Console.WriteLine(recipeId);
            adtr.Dispose();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                try
                {
                    string query2 = "Insert Into IlacRecete(ReceteId,IlacId) Values ('" + recipeId + "','" + dataGridView.Rows[i].Cells["Id"].Value.ToString() + "')";
                    komut.Connection = baglanti;
                    komut.CommandText = query2;
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }



            baglanti.Close();
        }

        public BunifuDataGridView getRecipeMedicines(BunifuDataGridView dataGridView, string receteIdOrHastaTc)
        {
            baglanti.Open();
            string query = "SELECT IlacRecete.ReceteId, Ilaclar.Barkod, Ilaclar.UrunAdi, " +
                "Ilaclar.EtkinMadde, Ilaclar.Fiyat FROM Ilaclar " +
                "INNER JOIN (Recete INNER JOIN IlacRecete ON Recete.ReceteId = IlacRecete.ReceteId) " +
                "ON Ilaclar.Id = IlacRecete.IlacId WHERE (((IlacRecete.ReceteId)=" + receteIdOrHastaTc + ") OR ((Recete.HastaTcKimlikNo)='"+ receteIdOrHastaTc + "'))";

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
