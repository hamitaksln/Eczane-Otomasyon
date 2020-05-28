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
    public partial class DoktorForm : MaterialSkin.Controls.MaterialForm
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eczane.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        DBOperations dBOperations = new DBOperations();

        int writtenMedicine = 0;

        string patientName;
        string patientSurname;
        string patientTC;
        int patientAge;

        bool isPatientSelected = false;

        public DoktorForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void DoktorForm_Load(object sender, EventArgs e)
        {
            getAllPatient();
            getAllMedicine();

        }
        private void getAllPatient()
        {
            DBOperations dBOperations = new DBOperations();
            hastaDataGridView = dBOperations.getAllPatients(hastaDataGridView);
        }

        private void getAllMedicine()
        {
            DBOperations dBOperations = new DBOperations();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "";
            btn.Name = "button";
            btn.Text = "EKLE";
            btn.UseColumnTextForButtonValue = true;
            medicinesDataGridView.Columns.Add(btn);
            medicinesDataGridView.Columns[0].Width = 10;
            medicinesDataGridView = dBOperations.getAllMedicines(medicinesDataGridView);

            //foreach(DataGridViewColumn dgvc in medicinesDataGridView.Columns)
            //{
            //    writtenMedicineDataGridView.Columns.Add(dgvc.Clone() as DataGridViewColumn);
            //}
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "";
            btn1.Name = "button";
            btn1.Text = "ÇIKAR";
            btn1.UseColumnTextForButtonValue = true;
            writtenMedicineDataGridView.Columns.Add(btn1);

            for (int i = 1; i < medicinesDataGridView.Columns.Count; i++)
            {
                writtenMedicineDataGridView.Columns.Add(medicinesDataGridView.Columns[i].Clone() as DataGridViewColumn);
            }
        }


        private void hastaDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            patientName = hastaDataGridView.Rows[e.RowIndex].Cells["Ad"].Value.ToString();
            patientSurname = hastaDataGridView.Rows[e.RowIndex].Cells["Soyad"].Value.ToString();
            patientTC = hastaDataGridView.Rows[e.RowIndex].Cells["TC"].Value.ToString();
            DateTime dateNow = DateTime.Now;
            string birthDate = hastaDataGridView.Rows[e.RowIndex].Cells["Doğum Tarihi"].Value.ToString();
            string[] age = birthDate.Split(' ');
            DateTime patientBirthDate = DateTime.Parse(age[0]);
            patientAge = (int)dateNow.Year - patientBirthDate.Year;
            patientInfoLabel.Text = patientTC + " " + patientName + " " + patientSurname + " " + patientAge + " yaşında.";

            materialTabControl1.SelectedIndex = 1;
            warningLabel.Text = null;
            isPatientSelected = true;

        }

        private void patientSearchTextBox_TextChange(object sender, EventArgs e)
        {
            if (patientSearchTextBox.Text.Length >= 2)
            {
                ds = dBOperations.getSearchedPatient(patientSearchTextBox.Text);
                hastaDataGridView.DataSource = ds.Tables["Hasta"];
            }
            else if (patientSearchTextBox.Text.Length == 0)
            {
                hastaDataGridView = dBOperations.getAllPatients(hastaDataGridView);
            }
        }

        private void searchMedicineTextBox_TextChange(object sender, EventArgs e)
        {
            if (searchMedicineTextBox.Text.Length >= 3)
            {
                ds.Clear();
                ds = dBOperations.getSearchedMedicine(searchMedicineTextBox.Text);
                medicinesDataGridView.DataSource = ds.Tables["Ilaclar"];
            }
            else if (searchMedicineTextBox.Text.Length == 0)
            {
                medicinesDataGridView = dBOperations.getAllMedicines(medicinesDataGridView);
            }

        }

        private void medicinesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != medicinesDataGridView.Rows.Count - 1)
            {
                int medicineAgeLimit = Convert.ToInt32(medicinesDataGridView.Rows[e.RowIndex].Cells["KullanimYasi"].Value.ToString());
                if (isPatientSelected)
                {
                    if (canTakeMedicine(patientAge, medicineAgeLimit))
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row = (DataGridViewRow)medicinesDataGridView.Rows[e.RowIndex].Clone();
                        for (int i = 1; i < medicinesDataGridView.Rows[e.RowIndex].Cells.Count; i++)
                        {
                            row.Cells[i].Value = medicinesDataGridView.Rows[e.RowIndex].Cells[i].Value;
                        }
                        writtenMedicineDataGridView.Rows.Add(row);
                        writtenMedicine++;
                        writtenMedicineButton.Text = "" + writtenMedicine;
                    }
                    else
                    {
                        MessageBox.Show("Hastaya yaşından dolayı bu ilaç verilemez!", "Hasta Yaşı",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Hasta Seçiniz", "Hasta",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void writtenMedicineDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != writtenMedicineDataGridView.Rows.Count - 1)
            {
                writtenMedicineDataGridView.Rows.RemoveAt(e.RowIndex);
                writtenMedicine--;
                writtenMedicineButton.Text = "" + writtenMedicine;
            }
        }

        private void writtenMedicineButton_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 2;
        }

        private void addMedicineToRecipe(int age)
        {

        }

        private bool canTakeMedicine(int age, int medicineAgeLimit)
        {
            if (age >= medicineAgeLimit)
            {
                return true;
            }
            return false;
        }

        private void recipePrintButton_Click(object sender, EventArgs e)
        {
            if (!isPatientSelected)
            {
                MessageBox.Show("Lütfen Hasta Seçiniz", "Hasta",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (writtenMedicine <= 0)
            {
                MessageBox.Show("En az 1 İlaç Seçiniz", "İla.",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                dBOperations.insertRecipeToDatabase(1, patientTC, writtenMedicineDataGridView, recipeNoLabel);
            }

        }

        private void recipeIdTextBox_TextChange(object sender, EventArgs e)
        {
            if(recipeIdTextBox.Text.Length != 0)
            {
                recipeMedicinesDataGridView = dBOperations.getRecipeMedicines(recipeMedicinesDataGridView, recipeIdTextBox.Text);
            }
        }
    }
}
