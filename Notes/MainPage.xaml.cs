using Microsoft.Maui.Controls;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        string caminho = Path.Combine(FileSystem.AppDataDirectory,"arquivo");

        public MainPage()
        {
            InitializeComponent();
            if(File.Exists(caminho))
                CaixaEditor.Text =  File.ReadAllText(caminho);
        }

        private void editor_Completed(object sender, EventArgs e)
        {
            string conteudo = CaixaEditor.Text;
            File.WriteAllText(caminho, conteudo);
            DisplayAlert("Arquivo Salvo", $"Arquivo {Path.GetFileName(caminho)} com Sucesso  na pasta {caminho}", "OK");
        }

        private void ApagarBtn_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(caminho))
            { 
                File.Delete(caminho); 
                DisplayAlert("Arquivo Apagado", "Arquivo Apagado com Sucesso", "OK"); 
            }
            else
            {
                DisplayAlert("Erro", "Não Existe Arquivo", "OK");
            }
        }

        private void ApagarTxtBtn_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(caminho) || CaixaEditor != null)
            {
                // Se o arquivo existir OU a caixa de texto não for nula, faça algo:
                // Para limpar o conteúdo da caixa de texto:
                if (CaixaEditor != null) // Verifica se a caixa de texto existe para evitar erro
                {
                    CaixaEditor.Text = ""; // Atribui uma string vazia para limpar o texto
                }
            }

        }
    }
}
