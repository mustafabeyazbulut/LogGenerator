using System.Data;

namespace Veriket.Winform
{
    public partial class VeriketLogList : Form
    {
        public VeriketLogList()
        {
            InitializeComponent();
        }
        private void LoadLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "VeriketApp");
            string filePath = Path.Combine(path, "VeriketAppTest.txt");
            if (File.Exists(filePath))
            {
                DataTable dataTable = LoadCsvFile(filePath);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Belirtilen dosya bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable LoadCsvFile(string filePath)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // ilk satırı başlık olarak ekliyorum.
                    string[] headers = reader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }
                    // Geriye kalan satırları ekliyorum.
                    while (!reader.EndOfStream)
                    {
                        string[] rows = reader.ReadLine().Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
    }
}