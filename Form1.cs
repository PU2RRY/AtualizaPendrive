using System.ComponentModel;
using System.Diagnostics;
using System.IO;
namespace Atualiza_Pendrive
{
    public partial class Form1 : Form
    {
        //private const string ORIGEM = @"C:\Users\Micro\Documents\DCS";
        private const string ORIGEM = @"\\digo\d\DCS";
        private int totalArquivos;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dirDialog = new FolderBrowserDialog())
            {
                // Mostra a janela de escolha do directorio
                DialogResult res = dirDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    // Como o utilizador carregou no OK, o directorio escolhido pode ser acedido da seguinte forma:
                    string directorio = dirDialog.SelectedPath;
                    textBox1.Text = directorio;
                }
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {


            // Define os valores mínimos e máximos para a barra de progresso
            progressBar1.Minimum = 0;
            totalArquivos = ContaArquivos(ORIGEM);
            progressBar1.Maximum = totalArquivos;

            // Inicia a cópia do arquivo em um thread separado
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoCopy);
            worker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }
        public void DoCopy(object sender, DoWorkEventArgs e)
        {

            string destino = textBox1.Text;

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
            {
                diTarget.Create();
            }

            // Copia os arquivos da pasta de origem para a pasta de destino
            foreach (FileInfo fi in diSource.GetFiles())
            {

                Invoke(new Action(() =>
                {
                    progressBar1.Value += 1;
                    label2.Text = "Copiando : " + fi.Name;
                }));
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

        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            // Atualiza o valor da barra de progresso
            progressBar1.Value = e.ProgressPercentage;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

