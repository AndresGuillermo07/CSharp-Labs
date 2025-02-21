namespace lab7
{
    public partial class Form1 : Form
    {
        private ListView listView;
        private Button btnExport;
        private Button btnImport;
        private string defaultFilePath = "data.txt";
        private string logFilePath = "errors.log";

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Gestión de Archivos";
            this.Size = new System.Drawing.Size(600, 400);

            listView = new ListView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                View = View.List
            };
            this.Controls.Add(listView);

            btnExport = new Button
            {
                Text = "Exportar",
                Location = new System.Drawing.Point(20, 250)
            };
            btnExport.Click += BtnExport_Click;
            this.Controls.Add(btnExport);

            btnImport = new Button
            {
                Text = "Importar",
                Location = new System.Drawing.Point(120, 250)
            };
            btnImport.Click += BtnImport_Click;
            this.Controls.Add(btnImport);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(defaultFilePath))
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        writer.WriteLine(item.Text);
                    }
                }
                MessageBox.Show("Datos exportados correctamente.");
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Error al exportar datos.");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listView.Items.Clear();
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        var lines = reader.ReadToEnd().Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        listView.Items.AddRange(lines.Select(line => new ListViewItem(line)).ToArray());
                    }
                    MessageBox.Show("Datos importados correctamente.");
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Error al importar datos.");
            }
        }

        private void LogError(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {ex.Message}");
            }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
