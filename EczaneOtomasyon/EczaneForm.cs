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

        int basketTotalPrice = 0;

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
            patientInfoLabel.Text = "";
            getAllMedicine();
            getAllPatient();
            getAllOtherProducts();
        }

        private void getAllPatient()
        {
            DBOperations dBOperations = new DBOperations();
            hastaDataGridView = dBOperations.getAllPatients(hastaDataGridView);
        }

        private void getAllMedicine()
        {
            DBOperations dBOperations = new DBOperations();
            medicinesDataGridView = dBOperations.getAllMedicines(medicinesDataGridView);
        }

        private void getAllOtherProducts()
        {
            DBOperations dBOperations = new DBOperations();
            otherProductsDataGridView = dBOperations.getAllOtherProducts(otherProductsDataGridView);

            for (int i = 0; i < otherProductsDataGridView.Columns.Count; i++)
            {
                basketDataGridView.Columns.Add(otherProductsDataGridView.Columns[i].Clone() as DataGridViewColumn);
            }

        }

        private void searchMedicineTextBox_TextChange(object sender, EventArgs e)
        {
            if (searchMedicineTextBox.Text.Length >= 3)
            {
                DBOperations dBOperations = new DBOperations();

                ds.Clear();
                ds = dBOperations.getSearchedMedicine(searchMedicineTextBox.Text);
                medicinesDataGridView.DataSource = ds.Tables["Ilaclar"];
            }
            else if (searchMedicineTextBox.Text.Length == 0)
            {
                medicinesDataGridView = dBOperations.getAllMedicines(medicinesDataGridView);
            }

        }

        private void recipeIdTextBox_TextChange(object sender, EventArgs e)
        {
            try
            {
                if (recipeIdTextBox.Text.Length != 0)
                {
                    totalPriceLabel.Text = "0";
                    patientInfoLabel.Text = "";
                    insuranceTypeLabel.Text = "-";
                    discountPriceLabel.Text = "0";
                    finalPriceLabel.Text = "0";
                    recipeMedicinesDataGridView.DataSource = null;

                    DBOperations db = new DBOperations();
                    recipeMedicinesDataGridView = db.getRecipeMedicines(recipeMedicinesDataGridView, recipeIdTextBox.Text);

                    int totalPrice = 0;
                    foreach (DataGridViewRow row in recipeMedicinesDataGridView.Rows)
                    {
                        totalPrice += Convert.ToInt32(row.Cells["Fiyat"].Value);
                    }
                    totalPriceLabel.Text = totalPrice.ToString();

                    patientInfoLabel.Text = "";
                    if (totalPrice > 0)
                    {
                        DBOperations db1 = new DBOperations();
                        string[] results = db1.getPatientTCandInsuranceWithRecipeID(Convert.ToInt32(recipeIdTextBox.Text));
                        string patientTC = results[0];
                        string patientInsuranceType = results[1];
                        insuranceTypeLabel.Text = patientInsuranceType;

                        ds.Clear();
                        ds = db1.getSearchedPatient(patientTC);
                        string patientName = ds.Tables["Hasta"].Rows[0]["Ad"].ToString();
                        string patientSurname = ds.Tables["Hasta"].Rows[0]["Soyad"].ToString();

                        patientInfoLabel.Text = patientName + " " + patientSurname + " " + patientTC;

                        if (patientInsuranceType == "SGK")
                        {
                            //int discountedPrice = totalPrice * 0.9;
                            discountPriceLabel.Text = Convert.ToString(totalPrice * 0.1);
                            finalPriceLabel.Text = Convert.ToString(totalPrice * 0.9);
                        }
                        else if (patientInsuranceType == "BAĞKUR")
                        {
                            discountPriceLabel.Text = Convert.ToString(totalPrice * 0.2);
                            finalPriceLabel.Text = Convert.ToString(totalPrice * 0.8);
                        }
                        else
                        {
                            discountPriceLabel.Text = "0";
                            finalPriceLabel.Text = Convert.ToString(totalPrice * 1);
                        }

                    }

                    int recipeId = Convert.ToInt32(recipeMedicinesDataGridView.Rows[0].Cells["Reçete ID"].Value.ToString());
                    if (!canRecipeSell(recipeId))
                    {
                        sellMedicinesButton.Enabled = false;
                        sellMedicinesButton.Text = "Bu reçete zaten satılmış";
                    }
                    else
                    {
                        sellMedicinesButton.Text = "Satışı Yap";
                        sellMedicinesButton.Enabled = true;
                    }

                }
                else
                {
                    totalPriceLabel.Text = "0";
                    patientInfoLabel.Text = "";
                    insuranceTypeLabel.Text = "-";
                    recipeMedicinesDataGridView.DataSource = null;
                }
            }
            catch (Exception err)
            {
                
            }

        }

        private void sellMedicinesButton_Click(object sender, EventArgs e)
        {
            if (patientInfoLabel.Text != "")
            {
                    DBOperations db = new DBOperations();
                    string paymentType = "";
                    if (cashRadioButton.Checked)
                    {
                        paymentType = "Nakit";
                    }
                    else if (cardRadioButton.Checked)
                    {
                        paymentType = "Kredi Kartı";
                    }
                    db.insertSoldMedicines(recipeMedicinesDataGridView, paymentType);

                    MessageBox.Show("Satış gerçekleşti!", "Reçete",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    sellMedicinesButton.Enabled = false;
                    sellMedicinesButton.Text = "Bu reçete zaten satılmış";
            } else
            {
                MessageBox.Show("Lütfen reçete seçiniz!", "Reçete",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool canRecipeSell(int recipeId)
        {
            DBOperations db = new DBOperations();
            if (!db.isRecipeSold(recipeId))
            {
                return true;
            }

            return false;

        }

        private void homeScreenButton_Click(object sender, EventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            this.Hide();
            homeScreen.ShowDialog();
            this.Close();
        }

        private void otherProductsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string productID = otherProductsDataGridView.Rows[e.RowIndex].Cells["Ürün ID"].Value.ToString();
            string productBarkod = otherProductsDataGridView.Rows[e.RowIndex].Cells["Barkod"].Value.ToString();
            string productName = otherProductsDataGridView.Rows[e.RowIndex].Cells["Ürün Adı"].Value.ToString();
            string productOwner = otherProductsDataGridView.Rows[e.RowIndex].Cells["Ruhsat Sahibi"].Value.ToString();
            string productPrice = otherProductsDataGridView.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            basketDataGridView.Rows.Add();
            basketDataGridView.Rows[basketDataGridView.Rows.Count - 2].Cells["Ürün ID"].Value = productID;
            basketDataGridView.Rows[basketDataGridView.Rows.Count - 2].Cells["Barkod"].Value = productBarkod;
            basketDataGridView.Rows[basketDataGridView.Rows.Count - 2].Cells["Ürün Adı"].Value = productName;
            basketDataGridView.Rows[basketDataGridView.Rows.Count - 2].Cells["Ruhsat Sahibi"].Value = productOwner;
            basketDataGridView.Rows[basketDataGridView.Rows.Count - 2].Cells["Fiyat"].Value = productPrice;

            basketTotalPrice += Convert.ToInt32(productPrice);
            totalProductsPriceLabel.Text = basketTotalPrice.ToString();
        }

        private void sellProducsButton_Click(object sender, EventArgs e)
        {
            if(basketDataGridView.Rows.Count >1)
            {
                string paymentType = "Nakit";
                if(basketCashRadioButton.Checked)
                {
                    paymentType = "Nakit";
                } else if(basketCardRadioButton.Checked)
                {
                    paymentType = "Kredi Kartı";
                }
                DBOperations db = new DBOperations();
                db.insertSoldProducts(basketDataGridView, paymentType);

                basketDataGridView.Rows.Clear();
                basketTotalPrice = 0;
                totalProductsPriceLabel.Text = basketTotalPrice.ToString();

                MessageBox.Show("Satış başarılı bir şekilde gerçekleştirildi!", "Sepet",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Sepette ürün yok!", "Sepet",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }
    }
}
