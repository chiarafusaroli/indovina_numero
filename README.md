Solution con al suo interno
- progetto Libreria di classi con interfacce per la gestione di un generatore di numeri e la gestione dell'I/O
- progetto Console con classi per I/O
- progetto WPF con definizionei dei metodi per i/o
- progetto Unit Test con output in debug console

- Versione Base: versione con una classe game che risulta essere non testabile perchè genera il numero da indovinare in modo random 
- Versione Interfacce: creazione di una interfaccia IGenerator e di una classe RandomGenerator utilizzata da Game per gestire la generazione del numero da indovinare Random e creazione di una classe nel progetto di test che implementa l'interfaccia e mi permette di definire il numero da indovinare per testare il corretto comportamento della classe Game
- Versione Architecture: Interfaccia IInputInterface e IOutputInterafce per la gestiene dell'I/O. Utilizzo di task, async ed await per poter gestire l'input da WPF (I Task servono per eseguire operazioni in modo asincrono, evitando che il programma si blocchi. Sono molto utili in WPF per la gestione dell'input essendo WPF event-driven. Un Task rappresenta un'operazione in esecuzione (o che verrà eseguita) in modo asincrono; Task.Run() esegue il codice su un thread separato, utile per operazioni pesanti. await ci permette di attendere ed ottenere un valore da un task

## NELL'INTERFACCIA
      public interface IInputInterface
      {
     
        Task<int> InputAttempt();//uso un metodo asincrono perchè con UI event driven (come WPF) devo attendere l'input dell'utente senza bloccare tutto!
     
      }
     
     
## NEL GAME
-il metodo deve essere asincrono (async) per poter usare il task per l'input ed attendere senza bloccare tutto
 
    private async void Play()
    {
     while (_status == GameStatus.IN_PROGRESS)
     {
         //ricevo il tentativo in input
         int number = await _input.InputAttempt();
    
         //controllo il tentativo
         AttemptResult result = Attempt(number);
    
         //invio gli stati per l'output
         _output.OutputAttemptResult(result);
         _output.OutputGameStatus(_status);
     } 
     
    }
## NEL WPF

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
    public **async** Task<int> InputAttempt()
    {
    //qui abbiamo un problema... il wpf è event-driven e invece questo metodo si aspetta un valore che non possiamo sapere quando sarà inserito
    //quindi divremmo rimanere in attesa che il tentativo sia isnerito ovvero che venga premuto il pulsante try
    //Per fare questo utilizziamo dei Task
    
    _inputTask = new TaskCompletionSource<int>(); //creo un task che sta in attesa di leggere il valore al click sul bottone try
    //dal quale recuperare il valore del numero inserito in input da restituire al game
    
    return await _inputTask.Task; 
    }
