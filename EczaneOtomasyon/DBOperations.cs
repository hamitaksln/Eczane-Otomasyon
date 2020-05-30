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
            string query = "SELECT Ilaclar.Id as [İlaç ID], Ilaclar.Barkod, Ilaclar.UrunAdi as [Ürün Adı]," +
                " Ilaclar.EtkinMadde as [Etkin Madde], Ilaclar.ReceteTuru as [Reçete Türü]," +
                " Ilaclar.KullanimYasi as [Kullanım Yaşı], Ilaclar.Fiyat FROM Ilaclar " +
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
            string query = "SELECT Ilaclar.Id as [İlaç ID], Ilaclar.Barkod, Ilaclar.UrunAdi as [Ürün Adı]," +
                " Ilaclar.EtkinMadde as [Etkin Madde], Ilaclar.ReceteTuru as [Reçete Türü], " +
                "Ilaclar.KullanimYasi as [Kullanım Yaşı], Ilaclar.Fiyat FROM Ilaclar";
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

        public BunifuDataGridView getAllOtherProducts(BunifuDataGridView dataGridView)
        {
            baglanti.Open();
            string query = "SELECT YanUrunler.Id as [Ürün ID], YanUrunler.Barkod, YanUrunler.UrunAdi as [Ürün Adı], Tedarikci.FirmaAdi as [Ruhsat Sahibi]," +
                "YanUrunler.Fiyat FROM YanUrunler INNER JOIN Tedarikci ON YanUrunler.RuhsatSahibiId = Tedarikci.Id";

            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "YanUrunler");
            dataGridView.DataSource = ds.Tables["YanUrunler"];
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
                    string query2 = "Insert Into IlacRecete(ReceteId,IlacId) Values ('" + recipeId + "','" + dataGridView.Rows[i].Cells["İlaç ID"].Value.ToString() + "')";
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
            string query = "SELECT IlacRecete.ReceteId as [Reçete ID], IlacRecete.IlacId as [İlaç ID], Ilaclar.Barkod, Ilaclar.UrunAdi as [Ürün Adı], " +
                "Ilaclar.EtkinMadde as [Etkin Madde], Ilaclar.Fiyat FROM Ilaclar " +
                "INNER JOIN (Recete INNER JOIN IlacRecete ON Recete.ReceteId = IlacRecete.ReceteId) " +
                "ON Ilaclar.Id = IlacRecete.IlacId WHERE (((IlacRecete.ReceteId)=" + receteIdOrHastaTc + ") OR ((Recete.HastaTcKimlikNo)='"+ receteIdOrHastaTc + "'))";

            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Ilaclar");
            dataGridView.DataSource = null;
            dataGridView.DataSource = ds.Tables["Ilaclar"];
            adtr.Dispose();
            baglanti.Close();

            return dataGridView;
        }

        public string[] getPatientTCandInsuranceWithRecipeID(int recipeID)
        {
            baglanti.Open();
            string query = "SELECT Recete.ReceteId, Hasta.HastaTc, Hasta.SigortaTuru" +
                " FROM Hasta INNER JOIN Recete ON Hasta.HastaTc = Recete.HastaTcKimlikNo " +
                "GROUP BY Recete.ReceteId, Hasta.HastaTc, Hasta.SigortaTuru " +
                "HAVING (((Recete.ReceteId)="+recipeID+"))";
            string[] results = new string[2];
            OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
            ds.Clear();
            adtr.Fill(ds, "Hasta");
            results[0] = Convert.ToString(ds.Tables["Hasta"].Rows[0]["HastaTc"]);
            results[1] = Convert.ToString(ds.Tables["Hasta"].Rows[0]["SigortaTuru"]);
            adtr.Dispose();
            baglanti.Close();

            return results;
        }

        public void insertSoldMedicines(BunifuDataGridView dataGridView,string paymentType)
        {

            DateTime now = DateTime.Now;
            baglanti.Open();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                try
                {
                    string ilacId = dataGridView.Rows[i].Cells["İlaç ID"].Value.ToString();
                    string recipeId = dataGridView.Rows[i].Cells["Reçete ID"].Value.ToString();
                    string query = "Insert Into SatilanIlaclar(IlacId,SatisTarihi,SatisSekli,ReceteId,SatanPersonelId) Values ('"+ilacId+"','" + now.ToString("dd/MM/yyyy") + "','"+paymentType + "','"+recipeId+"','1')";
                    komut.Connection = baglanti;
                    komut.CommandText = query;
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                }
                
            }
            
            baglanti.Close();
        }

        public bool isRecipeSold(int recipeId)
        {
            baglanti.Open();
            try
            {
                string query = "SELECT SatilanIlaclar.ReceteId FROM SatilanIlaclar WHERE (((SatilanIlaclar.ReceteId)="+recipeId+"))";
                OleDbDataAdapter adtr = new OleDbDataAdapter(query, baglanti);
                ds.Clear();
                adtr.Fill(ds, "Hasta");
                adtr.Dispose();

                if(ds.Tables["Hasta"].Rows[0]["ReceteId"].ToString() == null)
                {
                    Console.WriteLine("Reçete satılmamış");
                } else
                {
                    Console.WriteLine("Reçete satılmış");
                }
                

                baglanti.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public void insertSoldProducts(BunifuDataGridView dataGridView, string paymentType)
        {

            DateTime now = DateTime.Now;
            baglanti.Open();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                try
                {
                    string productID = dataGridView.Rows[i].Cells["Ürün ID"].Value.ToString();
                    string productBarkod = dataGridView.Rows[i].Cells["Barkod"].Value.ToString();
                    string productName = dataGridView.Rows[i].Cells["Ürün Adı"].Value.ToString();
                    string query = "Insert Into SatilanYanUrunler(Id,UrunAdi,BarkotNo,SatisTarihi,SatisSekli,SatanPersonelId) " +
                        "Values ('" + productID + "','"+productName+"','"+productBarkod+"','" + now.ToString("dd/MM/yyyy") + "','" + paymentType + "','1')";
                    komut.Connection = baglanti;
                    komut.CommandText = query;
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                }

            }

            baglanti.Close();
        }
    }
}
