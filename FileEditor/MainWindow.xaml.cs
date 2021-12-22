using System;
using System.Windows;
using Microsoft.Win32;
using System.IO;
namespace EditeurFichier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Nom du fichier à utiliser
        /// </summary>
        private string nomFichier   = String.Empty;
        private string copiedText   = String.Empty; 
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ouvrir le fichier après la sélection par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ouvrir_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Mettre à jour la méthode Ouvrir_Click 
            // Appel méthode LireNomFichier pour avoir le nom du fichier à charger           
            // Charger la zone de texte de l'éditeur avec le contenu du fichier
            try 
            {
                var openDialog = new OpenFileDialog();
                openDialog.Title = "Sélectionner un fichier texte (.txt) à importer";
                openDialog.Filter = "txt files *(*.txt)|*.txt";
                openDialog.FilterIndex = 2;
                openDialog.RestoreDirectory = true;
                openDialog.ShowDialog();
                string selectedFilePath = openDialog.FileName;
                Console.WriteLine(selectedFilePath);
                openDialog.FileName = selectedFilePath;
                string allTextInFile = File.ReadAllText(selectedFilePath);
                TexteDossier.Text = allTextInFile;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        // TODO - Implémenter une méthode pour lire le nom du fichier 
        // Ajouter une méthode LireNomFichier 


        // Enregistrer les données à nouveau dans le fichier
        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Mettre à jour la méthode  Enregistrer_Click 
            // Enregistrer le contenu de la zone de texte de l'éditeur à nouveau dans le fichier
            try
            {
                File.WriteAllText("C:\\Users\\DELL\\Desktop\\output.txt", TexteDossier.Text);
                MessageBox.Show("Fichier enregistré sous C:\\Users\\DELL\\Desktop\\output.txt");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void EnregistrerSous_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Mettre à jour la méthode  Enregistrer_Click 
            // Enregistrer le contenu de la zone de texte de l'éditeur sous un nouveau nom dans un fichier
            try
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "txt";
                saveDialog.OverwritePrompt = true;
                saveDialog.Title = "Enregistrer votre fichier";
                saveDialog.ShowDialog();
                string selectedPath = saveDialog.FileName;
                File.WriteAllText(selectedPath, TexteDossier.Text);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void CommencerLaCorrection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CommencerEvaluation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Copier_Click(object sender, RoutedEventArgs e)
        {
            this.copiedText = TexteDossier.SelectedText;
        }

        private void Couper_Click(object sender, RoutedEventArgs e)
        {
            this.copiedText = TexteDossier.SelectedText;
            TexteDossier.Text = "";
        }

        private void Coller_Click(object sender, RoutedEventArgs e)
        {
            TexteDossier.Text = TexteDossier.Text + this.copiedText;
        }

        private void RetirerDossier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TexteDossier_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

       /* private void  (object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void VraiOuFaux_Click(object sender, RoutedEventArgs e)
        {

        }*/
    }   
}
