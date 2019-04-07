using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


//Namespaces para trabalhar com arquivos
using Microsoft.Win32; //contem OpenFileDialog e SaveFileDialog
using System.IO; //métodos para o arquivo e diretórios
using System.Diagnostics; //Contem informações do arquivo e excessões

namespace Editor_de_Texto
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Inicialização

        //Janela de dialogo para salvar o arquivo
        private SaveFileDialog DialogoSalvar = null;
        //Variavel DialogoSalvar inicializa sem valor
        //Janela de dialogo para abrir o arquivo
        private OpenFileDialog DialogoAbrir = null;
        //Variavel para colocar o endereço do arquivo
        private string caminho = "";
        // Variavel para controlar a edição dos dados
        // Se "True", houve edição nos dados, se não, "False"
        private bool flag = false;

        //Indica se o texto foi salvo ou não...
        private bool salvou = false;

        public MainWindow()
        {
            InitializeComponent();
            DialogoSalvar = new SaveFileDialog();
            DialogoSalvar.Filter = "txt|*.txt";
            DialogoSalvar.AddExtension = true;
            // Define o método a ser executado quando clicado no botão salvar da caixa de dialogo salvar
            DialogoSalvar.FileOk += SalvarArquivoOk;

            DialogoAbrir = new OpenFileDialog();
            DialogoAbrir.Filter = "txt|*.txt";
            DialogoAbrir.AddExtension = true;

            // Define o método a ser executado quando clicado no botão ok
            DialogoAbrir.FileOk += AbrirArquivoOK;
        }
        #endregion

        #region SALVAR
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarArquivo();
        }
        private void SalvarComo_Click(object sender, RoutedEventArgs e)
        {
            {
                DialogoSalvar.ShowDialog();
                SalvarArquivo();
            }
        }
        private void SalvarArquivoOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            caminho = DialogoSalvar.FileName;
            SalvarArquivo();
        }
        private void SalvarArquivo()
        {
            try
            {
                if (caminho.Trim() == "")
                {
                    DialogoSalvar.ShowDialog();
                }
                else
                {
                    // Salva o arquivo no disco
                    File.WriteAllText(caminho, Conteudo.Text, Encoding.UTF8);
                    flag = false;
                    salvou = true;
                }
            }
            catch (Exception ex)
            {
                string dir = @"C:\Users\Usuario\Downloads\Editor de Texto\";
                if (!Directory.Exists(dir))
                {
                    using (StreamWriter text = File.CreateText(dir))
                    {
                        MessageBox.Show("FALHA:" + ex.Message);
                        text.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm"));
                    }
                }
            }
        }
        #endregion

        #region NOVO ARQUIVO
        private void Novo_Click(object sender, RoutedEventArgs e)
        {
            if (SalvarAntes() == true)
            {
                Conteudo.Text = "";
                caminho = "";
                flag = false;
            }
            DialogoAbrir.ShowDialog();
        }
        private bool SalvarAntes()
        {
            if (flag == true)
            {
                MessageBoxResult resposta = MessageBox.Show("O texto foi alterado!\nDeseja salvar as alterações?", "SALVAR ARQUIVO", MessageBoxButton.YesNoCancel);
                if (resposta == MessageBoxResult.Yes)
                {
                    SalvarArquivo();
                    if (salvou == false) return false;
                }

                else if (resposta == MessageBoxResult.Cancel) return false;
            }
            return true;
        }

        #endregion

        #region ABRIR       
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            if (SalvarAntes() == true)
            {
                DialogoAbrir.ShowDialog();
            }
                
        }


        private void AbrirArquivoOK(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                TextReader reader = null;

                caminho = DialogoAbrir.FileName;
                FileInfo info = new FileInfo(caminho);
                Conteudo.Text = "";
                reader = info.OpenText();
                string line = reader.ReadLine();
                while (line != null)
                {
                    Conteudo.Text += line + "\n";
                    line = reader.ReadLine();
                }
                reader.Close();
                flag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALHA:" + ex.Message);
            }

        }
        #endregion

        #region SAIR
        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Conteudo_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            flag = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (flag == true)
            { 
                if (SalvarAntes() == false)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
