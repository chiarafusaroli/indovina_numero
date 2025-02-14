using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryProject;

namespace ProgettoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IInputInterface, IOutputInterface
    {
        GuessTheNamberGame game;
        int tentativi = 10;
        int maxNumero = 100;

        public MainWindow()
        {
            InitializeComponent();

            lstBoxAttempts.Visibility = Visibility.Hidden;
            btnTry.Visibility = Visibility.Hidden;
            txtAttempts.Visibility = Visibility.Hidden;
        }

     
        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            txtAttempts.Text = string.Empty;
            lblMessage.Content = string.Empty;
        }

        private void ManageLose()
        {
            lblMessage.Foreground = Brushes.IndianRed;
            lblMessage.FontSize = 22;
            lblMessage.Content = "HAI PERSO! mi spiace non hai indovinato la tua partita finisce qui!";
            btnTry.IsEnabled = false;
        }
        private void ManageWin()
        {
            lblMessage.Foreground = Brushes.GreenYellow;
            lblMessage.FontSize = 22;
            lblMessage.Content = "HAI VINTO! Complimenti!";
            btnTry.IsEnabled = false;
        }

        private void TryAttempt(object sender, RoutedEventArgs e)
        {
            //si preoccupa di leggere il valore e completare il task di lettura dell'input
            if (_inputTask != null)
            {
                if (!int.TryParse(txtAttempts.Text, out int attempt))
                {
                    lblMessage.Content = "Errore: Inserisci un numero valido!";
                    lblMessage.Foreground = Brushes.Orange;
                    return; //esco perchè il task non è completato
                }

                lstBoxAttempts.Items.Add(attempt); // Aggiunge alla lista
                txtAttempts.Text = string.Empty; // Pulisce la TextBox

                _inputTask.SetResult(attempt); // Completa il task con il valore inserito                
            }

        }

        private TaskCompletionSource<int> _inputTask;
        public async Task<int> InputAttempt()
        {
            //qui abbiamo un problema... il wpf è event-driven e invece questo metodo si aspetta un valore che non possiamo sapere quando sarà inserito
            //quindi divremmo rimanere in attesa che il tentativo sia isnerito ovvero che venga premuto il pulsante try
            //Per fare questo utilizziamo dei Task
           
            _inputTask = new TaskCompletionSource<int>(); //creo un task che sta in attesa di leggere il valore al click sul bottone try
           //dal quale recuperare il valore del numero inserito in input da restituire al game

            return await _inputTask.Task; ;
        }

        public void OutputGameStatus(GameStatus status)
        {
            if (status == GameStatus.WIN)
            {
                ManageWin();
            }
            else if (status == GameStatus.LOSE)
            {
                ManageLose();
            }
        }
        public void OutputAttemptResult(AttemptResult result)
        {
            switch (result)
            {
                case AttemptResult.GUESSED:
                    lblMessage.Content = "Bravo! Hai indovinato!";
                    lblMessage.Foreground = Brushes.Green;
                    break;
                case AttemptResult.TOO_BIG:
                    lblMessage.Content = "Troppo grande! Riprova.";
                    lblMessage.Foreground = Brushes.Red;
                    break;
                case AttemptResult.TOO_LITTLE:
                    lblMessage.Content = "Troppo piccolo! Riprova.";
                    lblMessage.Foreground = Brushes.Blue;
                    break;
            }
            lstBoxAttempts.Items.Add(txtAttempts.Text);
            txtAttempts.Text = string.Empty;
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            lstBoxAttempts.Visibility = Visibility.Visible;
            btnTry.Visibility = Visibility.Visible;
            txtAttempts.Visibility = Visibility.Visible;
            btnPlay.Visibility = Visibility.Hidden;

            game = new GuessTheNamberGame(tentativi, maxNumero, this, this);
        }
    }
}