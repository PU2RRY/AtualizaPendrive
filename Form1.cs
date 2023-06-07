using System.ComponentModel;
using System.Diagnostics;
using System.IO;
namespace Atualiza_Pendrive
{
    public partial class Form1 : Form
    {
        private const string ORIGEM = @"\\digo\d\DCS";
        private int totalArquivos;
        public string penLetra;
        private string destino;
        public Form1()
        {
            InitializeComponent();
        }
        private void carregaDiscos()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Insert(0, "Selecione seu Pendrive");
            comboBox1.SelectedIndex = 0;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string driveLabel = $"{drive.Name} {drive.VolumeLabel}";
                comboBox1.Items.Add(driveLabel);
            }
            comboBox1.Items.RemoveAt(1);
            comboBox1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            carregaDiscos();
        }
        private void btnRecarregadiscos_Click(object sender, EventArgs e)
        {
            carregaDiscos();
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            penLetra = comboBox1.Text.Substring(0, 3);
            destino = $@"{penLetra}DCS";
        }
        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            // Define os valores mínimos e máximos para a barra de progresso
            progressBar1.Minimum = 0;
            totalArquivos = ContaArquivos(ORIGEM);
            progressBar1.Maximum = totalArquivos;
            if (progressBar1.Value != progressBar1.Minimum)
                progressBar1.Value = progressBar1.Minimum;
            //comboBox1. remover o disco C do combobox
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Porfavor selecione seu Pendrive", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!Directory.Exists(destino))
                {
                    DialogResult result = MessageBox.Show("Pasta DCS não encontrada, deseja criá-la ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        copia();
                    }
                    else
                        return;
                }
                copia();
            }
        }
        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            // Atualiza o valor da barra de progresso
            progressBar1.Value = e.ProgressPercentage;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                label2.Text = "Finalizado";
                btnAtualiza.Enabled = true;
            }
        }
        private void copia()
        {
            // Inicia a cópia do arquivo em um thread separado
            btnAtualiza.Enabled = false;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoCopy);
            worker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }
        public void DoCopy(object sender, DoWorkEventArgs e)
        {
                // string destino = $@"{penLetra}DCS";
            // Copia a pasta de origem para o pendrive
            CopyDirectory(ORIGEM, destino);
            // Atualiza o progresso para 100%
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(totalArquivos);
            MessageBox.Show("Cópia feita com sucesso");
        }
        public int ContaArquivos(string sourceDir)
        {
            DirectoryInfo diSource = new(sourceDir);
            int files = diSource.GetFiles().Length;
            foreach (DirectoryInfo di in diSource.GetDirectories())
                files += ContaArquivos(di.FullName);
            return files;
        }
        public void CopyDirectory(string sourceDir, string targetDir)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDir);
            DirectoryInfo diTarget = new DirectoryInfo(targetDir);
            // Cria a pasta de destino se ela não existir
            if (!diTarget.Exists)
                diTarget.Create();
            // Copia os arquivos da pasta de origem para a pasta de destino
            foreach (FileInfo fi in diSource.GetFiles())
            {
                Invoke(new Action(() => { progressBar1.Value += 1; label2.Text = "Copiando : " + fi.Name; }));
                if (!File.Exists(Path.Combine(diTarget.FullName, fi.Name)))
                {
                    if (File.Exists(Path.Combine(diTarget.FullName, fi.Name)))
                    {
                        var versaoOrigem = FileVersionInfo.GetVersionInfo(fi.FullName).FileVersion;
                        var versaoDestino = FileVersionInfo.GetVersionInfo(Path.Combine(diTarget.FullName, fi.Name)).FileVersion;
                        if (versaoOrigem.CompareTo(versaoDestino) > 0)
                        {
                            fi.CopyTo(Path.Combine(diTarget.FullName, fi.Name), true);
                        }
                    }
                    else
                    {
                        fi.CopyTo(Path.Combine(diTarget.FullName, fi.Name), true);
                    }
                }
            }
            // Copia as subpastas da pasta de origem para a pasta de destino
            foreach (DirectoryInfo di in diSource.GetDirectories())
            {
                CopyDirectory(di.FullName, Path.Combine(diTarget.FullName, di.Name));
            }
        }
    }
}