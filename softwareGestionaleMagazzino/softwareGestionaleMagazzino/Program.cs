using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace prototipo_magazzino
{
    class Program
    {
        static double[] stoffe = new double[7];  //{ cotone, lino, seta, pizzo, velluto, lana, maglia }  dichiarazione array globale tessuti
        static string[] taglie = new string[4] { "S", "M", "L", "XL" };
        static string[] nomiStoffe = new string[7] { "cotone", "lino", "seta", "pizzo", "velluto", "lana", "maglia" };
        static string[] informazioni = new string[6]; //capo,taglia,tessuto,raffinatezza,quantità,prezzoproduzione
        static string orario = DateTime.Now.ToString("d-MM-yyyy");//viene acquisita la data odierna
        static string fileCapi = @"Capi.txt";//variabile contenente il nome del file dei capi
        static string fileMateriali = @"Materiali.txt";//variabile contenente il nome del file dei materiali
        static string fileProfitti = $@"Profitti {orario}.txt";//variabile contenente il nome del file dei profitti, che cambia al variare della data
        static string impostazioni = @"Impostazioni.txt";//variabile contenente il nome del file delle impostazioni
        static string percorsoFileImpostazioni = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/" + impostazioni;//variabile contenente la directory del file delle impostazioni
        static string percorsoFileCapi = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/" + fileCapi;//variabile contenente la directory del file dei capi
        static string percorsoFileMateriali = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/" + fileMateriali;//variabile contenente la directory del file dei materiali
        static string percorsoFileProfitti = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileProfitti/" + fileProfitti;//variabile contenente la directory del file dei profitti
        static double sommaQuantitàStoffe = 0, colore, manodopera, tesspertagl = 0, prezzraff = 0, prezzoprod = 0, profittoGiorn, stoffeMaxMagazzino;
        static int capiMaxMagazzino, sommaQuantitàCapi = 0, contatore = 0, quantità = 0;
        static string capo, taglia, materiale, raffinatezza;

        static void Main(string[] args)
        {
            //all'avvio del programma vengono caricati i file
            CaricamentoFile();
            //in seguito viene mostrato il menù principale
            NavigazioneDichiarazioneMenù();
            Console.ReadKey();
        }

        static void InserimentoStoffe()
        {
            //domande essenziali riguardanti la quantità di stoffa presente in magazzino
            string controllo, iteratore = "0";
            while (iteratore == "0")
            {
                for (int a = 0; a < stoffe.Length; a++)//per ogni stoffa viene chiesta la quantità, il nome della stoffa è mostrato in base al valore di a e della posizione occupata nell'array "nomiStoffe[]"
                {
                    Console.Write($"\nQuanti metri di {nomiStoffe[a]} ci sono in magazzino?\nRisposta: ");
                    controllo = Console.ReadLine();//tramite una funzione viene controllato cioò che viene inserito dall'utente e si impedisce l'avanzamento finchè non si inserisce un valore valido
                    stoffe[a] = ControlloReadLineDouble(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    while (stoffe[a] < 0)//controllo che impedisce l'inserimento di valori negativi
                    {
                        Console.Write("Il valore non può essere minore di zero; reinserire.\nRisposta: ");
                        controllo = Console.ReadLine();
                        stoffe[a] = ControlloReadLineDouble(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    } //assunzione valore da tastiera del cotone che sarà inserito nell'array
                }
                Console.WriteLine("\nQueste sono le tue stoffe:\n");//vengono mostrate le stoffe inserite dall'utente
                for(int a = 0; a < stoffe.Length; a++)
                {
                    Console.WriteLine($"Metri di {nomiStoffe[a]} = {stoffe[a]}");
                }
                Console.Write("\nInserisci '0' se vuoi reinserire le stoffe; inserisci altro per confermare:\nRisposta: ");//viene chiesta una conferma sulle stoffe inserite
                iteratore = Console.ReadLine();
            }
            RicalcoloSommaQuantitàStoffe();//la somma totale delle stoffe in magazzino viene ricalcolata
            SalvataggioMateriali();//le quantità vengono salvate tramite una funzione
        }

        static void DomandeEssenziali()
        {
            InserimentoStoffe();//richiesta delle stoffe

            if (sommaQuantitàStoffe > stoffeMaxMagazzino) //controllo se la quantità di stoffa presente in magazzino supera la capienza massima
            {
                Console.Write("\nCi sono troppi metri di stoffa; hai sbagliato a digitare i numeri? Rispondi con '1' se vuoi reinserire le quantità.\nRisposta: "); //se le stoffe in magazzzino sono troppe e superano la capienzamax chiedo all'utente se v
                string risposta = Console.ReadLine();
                if (risposta == "1")// se l'utente risponde "1" reinserisce le quantita di ogni stoffa
                {
                    Console.Write("\nReinserisci le quantità delle stoffe:\n");
                    InserimentoStoffe();//richiesta delle stoffe
                }
                if (sommaQuantitàStoffe > stoffeMaxMagazzino) //se la quantità restasse ancora maggiore della capienza
                {
                    Console.WriteLine("I metri di stoffa presenti in magazzino sono troppi"); //lo comunico all'utente 
                    Console.Write("Se vuoi mandare dei capi in produzione digita '0', altrimenti schiaccia qualsiasi altro tasto per continuare\nRisposta: ");//e gli chiedo se vuole mandare dei capi in produzione in modod da diminuire la quantità di stoffa presente in magazzino
                    string rispostaStoffa = Console.ReadLine();
                    switch (rispostaStoffa)
                    {
                        case "0": Menù2(); break;
                        default: carattereJolly(); break;
                    }
                }
            }

        }

        static void NavigazioneDichiarazioneMenù()
        {
            Console.Clear();//viene pulita la console
            //vengono mostrate all'utente le possibili azioni che si possono compiere
            Console.WriteLine($"Oggi è il {orario}");
            Console.WriteLine("\n------------------------------------MENU' DI SCELTA------------------------------------");
            Console.WriteLine("1. Visualizza la stoffa immagazzinata, lo spazio occupato e il profitto giornaliero;");
            Console.WriteLine("2. Manda in produzione dei capi;");
            Console.WriteLine("3. Vendi i capi che sono stati prodotti;");
            Console.WriteLine("4. Visualizza opzioni aggiuntive;");
            Console.Write("*. Termina il programma.\n---------------------------------------------------------------------------------------\nRisposta: ");

            string NumeroMenù; //chiamo la variabile alla quale sarà assegnato il valore corrispondente al punto del menù che l'utente vuole mandare in esecuzione
            NumeroMenù = Console.ReadLine(); //assunzione valore da tastiera
            while (NumeroMenù != "1" && NumeroMenù != "2" && NumeroMenù != "3" && NumeroMenù != "4" && NumeroMenù != "*")//se la risposta non rientra nei valori comunicati il programma non permetterà di proseguire
            {
                Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                NumeroMenù = Console.ReadLine();
            }
            switch (NumeroMenù)
            {
                case "1":     //nel caso in cui l'utente cliccasse 1 chiamo la funzione Menù1
                    Menù1();
                    break;
                case "2":     //nel caso in cui l'utente cliccasse 2 chiamo la funzione Menù2
                    Menù2();
                    break;
                case "3":     //nel caso in cui l'utente cliccasse 3 chiamo la funzione Menù3
                    Menù3();
                    break;
                case "4":     //nel caso in cui l'utente cliccasse 4 chiamo la funzione Menù4
                    Menù4();
                    break;
                case "*":
                    System.Environment.Exit(1);     //nel caso l'utente cliccasse '*' il programma viene chiuso
                    break;
            }
        }

        static void Menù1()
        {
            RicalcoloSommaQuantitàStoffe();
            Console.WriteLine("\nIn magazzino sono presenti:\n"); //Comunico all'utente la quantità di ogni stoffa presente in magazzino tramite un for
            for (int a = 0; a < stoffe.Length; a++)
            {
                Console.WriteLine($"{stoffe[a]} metri di {nomiStoffe[a]};");
            }
            Console.WriteLine($"\n{sommaQuantitàCapi} capi invenduti, c'è spazio ancora per {capiMaxMagazzino - sommaQuantitàCapi} capi nel magazzino.");//viene comunicato lo spazio occupato dai capi 
            Console.WriteLine("In magazzino ci sono {0} metri di stoffa e ci possono stare ancora {1} metri", sommaQuantitàStoffe, stoffeMaxMagazzino - sommaQuantitàStoffe);//viene comunicato lo spazio occupato dalle stoffe
            Console.WriteLine("Il profitto giornaliero è di {0} euro.\n", profittoGiorn);//viene comunicato il profitto giornaliero

            for (int a = 0; a < stoffe.Length; a++)//viene comunicato all'utente quali stoffe stanno per esaurirsi
            {
                if (stoffe[a] < (stoffeMaxMagazzino / 7) / 3)//la quantità di allarme è 1/3 della stoffa massima media
                {
                    Console.WriteLine($"\aAttenzione! La stoffa '{nomiStoffe[a]}' sta terminando. Si consiglia di ordinarne di nuova.");//la sequenza di escape "\a" produce un segnale acustico 
                }
            }

            carattereJolly();
        }

        static void Menù2()
        {
            if (sommaQuantitàCapi >= capiMaxMagazzino)//controllo che il magazzino non sia pieno di capi
            {
                Console.WriteLine("\nE' stata raggiunta la quantità massima di capi immagazzinabili; è neccessario venderne per poterne produrre di nuovi.");
            }
            else
            {
                Console.Write("\nQuanti capi differenti sono stati prodotti?\nRisposta: ");//chiedo all'utente i capi differenti che ha prodotto
                string controllo;//controllo inserito affinchè l'utente non inserisce valori minori di zero oppure un carattere
                controllo = Console.ReadLine();
                int capiDifferenti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido, reinserire.\nRisposta: ");
                while (capiDifferenti <= 0)
                {
                    Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                    controllo = Console.ReadLine();
                    capiDifferenti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido, reinserire.\nRisposta: ");
                }

                for (contatore = 0; contatore < capiDifferenti; contatore++)//il programma ripeterà le domande tante volte quanti i capi diversi che l'utente ha prodotto
                {
                    Console.Write("\nChe tipo di capo vuoi produrre?\n1 -> Felpa \n2 -> Giubbotto\n3 -> Pantaloni\nRisposta: ");
                    capo = Console.ReadLine();
                    while (capo != "1" && capo != "2" && capo != "3") //controlla che il numero inserito faccia parte dei numeri proposti
                    {
                        Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        capo = Console.ReadLine();
                    }

                    Console.Write("\nDi che taglia è il capo che vuoi produrre?\n1 -> S \n2 -> M\n3 -> L\n4 -> XL\nRisposta: ");
                    taglia = Console.ReadLine();
                    while (taglia != "1" && taglia != "2" && taglia != "3" && taglia != "4") //controlla che il numero inserito faccia parte dei numeri proposti
                    {
                        Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        taglia = Console.ReadLine();
                    }
                    Console.Write("\nDi che materiale è il capo che vuoi produrre\n1 -> Cotone \n2 -> Lino\n3 -> Seta\n4 -> Pizzo\n5 -> Velluto\n6 -> Lana\n7 -> Maglia\nRisposta: ");
                    materiale = Console.ReadLine();
                    while (materiale != "1" && materiale != "2" && materiale != "3" && materiale != "4" && materiale != "5" && materiale != "6" && materiale != "7") //controlla che il numero inserito faccia parte dei numeri proposti
                    {
                        Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        materiale = Console.ReadLine();
                    }
                    if (materiale == "3" || materiale == "6")//dato che due dei materiali possiedono solo due raffinatezze è stato creato un if per richiedere la raffinatezza in base a quale materiale è stato scelto
                    {
                        Console.Write("\nDi che raffinatezza è il capo che vuoi produrre?\n1 -> Base \n2 -> Alta\nRisposta: ");
                        raffinatezza = Console.ReadLine();
                        while (raffinatezza != "1" && raffinatezza != "2") //controlla che il numero inserito faccia parte dei numeri proposti
                        {
                            Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                            raffinatezza = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.Write("\nDi che raffinatezza è il capo che vuoi produrre?\n1 -> Base \n2 -> Media \n3 -> Alta\nRisposta: ");
                        raffinatezza = Console.ReadLine();
                        while (raffinatezza != "1" && raffinatezza != "2" && raffinatezza != "3") //controlla che il numero inserito faccia parte dei numeri proposti
                        {
                            Console.Write("\nIl numero inserito non è valido; reinserire il numero.\nRisposta: ");
                            raffinatezza = Console.ReadLine();
                        }
                    }
                    Console.Write("\nQuanti ne hai prodotti?\nRisposta: ");//quantità prodotta di ogni tipo di capo
                    controllo = Console.ReadLine();//viene controllato tramite una funzione se si può convertire in intero ciò che è stato inserito
                    quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    while (sommaQuantitàCapi + quantità > capiMaxMagazzino)//se la quantità dei capi che sta per essere prodotta sforerebbe lo spazio massimo in magazzino i capi non vengono prodotti
                    {
                        Console.Write("\nNon c'è abbastanza spazio per immagazzinare la quantità di capi inserita. Reinserire il valore.  \nRisposta: ");
                        controllo = Console.ReadLine();//viene controllato tramite una funzione se si può convertire in intero ciò che è stato inserito
                        quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        while (quantità < 0)//viene controllato che la quantità inserita non sia minore di zero
                        {
                            Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                            controllo = Console.ReadLine();
                            quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        }
                    }
                    while (quantità < 0)//viene controllato che la quantità inserita non sia minore di zero
                    {
                        Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                        controllo = Console.ReadLine();//viene controllato tramite una funzione se si può convertire in intero ciò che è stato inserito
                        quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    }
                    informazioni[4] = quantità.ToString();//viene assegnata alla quinta posizione dell'array contenente le caratteristiche del capo la sua quantità 

                    switch (capo)//in base a quale valore si è inserito lo switch dà alla prima posizione dell'array contenente le caratteristiche del capo il tipo di abito corrispondente
                    {
                        case "1":
                            informazioni[0] = "felpa";
                            switch (taglia)//in base a quale valore si è inserito lo switch dà alla seconda posizione dell'array contenente le caratteristiche del capo la taglia corrispondente
                            {
                                case "1": informazioni[1] = "S"; tesspertagl = 2; break;//la variabile tesspetagl corrisponde alla metratura di stoffa necessaria per produrre l'abito e assume il suo valore in base al tipo di capo e alla sua taglia
                                case "2": informazioni[1] = "M"; tesspertagl = 2.2; break;
                                case "3": informazioni[1] = "L"; tesspertagl = 2.5; break;
                                case "4": informazioni[1] = "XL"; tesspertagl = 2.7; break;
                            }
                            break;
                        case "2":
                            informazioni[0] = "giubbotto";
                            switch (taglia)
                            {
                                case "1": informazioni[1] = "S"; tesspertagl = 2.5; break;
                                case "2": informazioni[1] = "M"; tesspertagl = 2.8; break;
                                case "3": informazioni[1] = "L"; tesspertagl = 3; break;
                                case "4": informazioni[1] = "XL"; tesspertagl = 3.2; break;
                            }
                            break;
                        case "3":
                            informazioni[0] = "pantaloni";
                            switch (taglia)
                            {
                                case "1": informazioni[1] = "S"; tesspertagl = 1.2; break;
                                case "2": informazioni[1] = "M"; tesspertagl = 1.5; break;
                                case "3": informazioni[1] = "L"; tesspertagl = 1.6; break;
                                case "4": informazioni[1] = "XL"; tesspertagl = 1.8; break;
                            }
                            break;
                    }

                    switch (materiale)//in base a quale valore si è inserito lo switch dà alla terza posizione dell'array contenente le caratteristiche del capo il materiale corrispondente
                    {
                        case "1":
                            informazioni[2] = "cotone";
                            switch (raffinatezza)//in base a quale valore si è inserito lo switch dà allaquarta posizione dell'array contenente le caratteristiche del capo la raffinatezza corrispondente
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 2.5; break;//la variabile "prezzraff" corrisponde al costo del tessuto al metro in base alla sua raffinatezza
                                case "2": informazioni[3] = "media"; prezzraff = 5; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 7; break;
                            }
                            break;
                        case "2":
                            informazioni[2] = "lino";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 3; break;
                                case "2": informazioni[3] = "media"; prezzraff = 6; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 10; break;
                            }
                            break;
                        case "3":
                            informazioni[2] = "seta";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 11; break;
                                case "2": informazioni[3] = "alta"; prezzraff = 22; break;
                            }
                            break;
                        case "4":
                            informazioni[2] = "pizzo";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 1.5; break;
                                case "2": informazioni[3] = "media"; prezzraff = 4; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 5.5; break;
                            }
                            break;
                        case "5":
                            informazioni[2] = "velluto";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 4; break;
                                case "2": informazioni[3] = "media"; prezzraff = 8; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 13; break;
                            }
                            break;
                        case "6":
                            informazioni[2] = "lana";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 3; break;
                                case "2": informazioni[3] = "alta"; prezzraff = 7; break;
                            }
                            break;
                        case "7":
                            informazioni[2] = "maglia";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 3.5; break;
                                case "2": informazioni[3] = "media"; prezzraff = 7; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 10; break;
                            }
                            break;
                    }

                    prezzoprod = tesspertagl * prezzraff + colore + manodopera; //il prezzo di produzione corrisponde alla metratura di tessuto utilzzata per il costo della stoffa al metro, a cui si aggiunge il costo del colore e della manodopera
                    profittoGiorn -= colore + manodopera * quantità; //si toglie dal profitto giornaliero i soldi utilizzati per il colore e la manodopera
                    informazioni[5] = prezzoprod.ToString();//si dà alla sesta posizione dell'array il valore del costo di produzione dell'abito

                    //vengono mostrate all'utente le caratteristiche dell'abito prodotto
                    Console.WriteLine($"\nQueste sono le informazioni riguardo al capo che sta per essere prodotto: \nTipo di capo: {informazioni[0]};\nTaglia: {informazioni[1]};\nMateriale: {informazioni[2]};\nRaffinatezza: {informazioni[3]};\nQuantità: {informazioni[4]};\nPrezzo di produzione per ogni capo: {informazioni[5]} euro;\nPrezzo totale di produzione: {double.Parse(informazioni[4]) * double.Parse(informazioni[5])} euro.");
                    Console.Write("\nSei sicuro di volerlo produrre? Digita '0' per annullare la produzione; digita qualsiasi altra cosa per continuare.\nRisposta: ");//viene richiesto di confermare la produzione
                    string rispostaProduzione = Console.ReadLine();
                    if (rispostaProduzione != "0")
                    {
                        if (stoffe[int.Parse(materiale) - 1] - tesspertagl * quantità < 0)//viene controllato che la stoffa che sta per essere utilizzata non sia maggiore della stoffa presente in magazzino
                        {
                            Console.WriteLine("\nLa stoffa necessaria per produrre l'abito non è sufficiente, per cui l'abito non verrà prodotto.");
                        }
                        else
                        {
                            stoffe[int.Parse(materiale) - 1] -= tesspertagl * quantità;//viene sottratta la stoffa utilizzata da quella in magazino
                            string salvataggioCaratteristiche = $"{informazioni[0]};{informazioni[1]};{informazioni[2]};{informazioni[3]};{informazioni[4]};{informazioni[5]}";//viene creata la stringa contenente le caratteristiche dell'abito divise dal carattere ";"
                            Console.WriteLine("\nIl capo è stato prodotto con successo.");//viene dato all'utente un feedback riguardo alla produzione dell'abito
                            StreamWriter caratteristicheCapi = new StreamWriter(percorsoFileCapi, true);//l'abito viene salvato in un file esterno
                            caratteristicheCapi.WriteLine(salvataggioCaratteristiche);
                            caratteristicheCapi.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nLa produzione dell'abito è stata annullata.");//viene dato all'utente un feedback riguardo al cancellamento della produzione dell'abito
                    }
                    SalvataggioMateriali();//vengono salvati i materiali presenti attualmente in magazzino in un file esterno
                    RicalcoloSommaQuantitàCapi();//si ricalcola la quantità di capi che si posseggono
                    
                }              
            }
            carattereJolly();
        }

        static void Menù3()//vendita dei capi
        {
            string[] righeCapi = File.ReadAllLines(percorsoFileCapi);//viene creata una stringa-array in cui si inserisce il contenuto del file dei capi
            if (righeCapi.Length == 0)//se il file dei capi risulta vuoto significa che in magazzino non sono presenti dei capi
            {
                Console.WriteLine("\aNel magazzino non sono presenti capi.");
            }
            else
            {
                Console.WriteLine("\nQuesti sono i capi attualmente in magazzino:\n");
                for (int m = 0; m < righeCapi.Length; m++)//ogni capo viene visualizzato a schermo
                {
                    Console.WriteLine($"Capo numero {m + 1}: {righeCapi[m]}");
                }

                Console.Write("\nQuale capo è stato venduto?\nRisposta: ");//viene richiesto quale capo è stato venduto tra quelli nella lista fornita
                string controllo = Console.ReadLine();//viene verificato che ciò che è stato inserito dall'utente sia un valore convertibile in intero
                int numeroCapoVenduto = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                while (numeroCapoVenduto < 1 || numeroCapoVenduto > righeCapi.Length)//se il numero inserito è minore di 1 o maggiore del numero di capi presenti il programma impedisce all'utente di continuare
                {
                    Console.Write("\nLa quantità inserita non è valida; reinserire.\nRisposta: ");
                    controllo = Console.ReadLine();//viene verificato che ciò che è stato inserito dall'utente sia un valore convertibile in intero
                    numeroCapoVenduto = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                }
                string[] capoVenduto = righeCapi[numeroCapoVenduto - 1].Split(";");//tramite la funzione split viene divisa la riga delle caratteristiche del capo scelto

                Console.Write("\nQuanti ne sono stati venduti?\nRisposta: ");//viene richiesta la quantità di capi venduti
                controllo = Console.ReadLine();//viene verificato che ciò che è stato inserito dall'utente sia un valore convertibile in intero
                int quantitàCapiVenduti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                while (Int32.Parse(capoVenduto[4]) - quantitàCapiVenduti < 0)//viene verificato che il valore non sia negativo
                {
                    Console.Write("\nLa quantità inserita non è valida; reinserire il numero: ");
                    controllo = Console.ReadLine();//viene verificato che ciò che è stato inserito dall'utente sia un valore convertibile in intero
                    quantitàCapiVenduti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                }

                int quantitàCapiRimanente = Int32.Parse(capoVenduto[4]) - quantitàCapiVenduti;//viene calcolata la quantità di capi di un certo tipo rimane in magazzino
                capoVenduto[4] = Convert.ToString(quantitàCapiRimanente);//viene assegnata alla quinta posizione delle caratteristiche del capo il numero di capi rimanenti di quel tipo

                double guadagnoCapo = double.Parse(capoVenduto[5]) * quantitàCapiVenduti * 7;//si calcola il prezzo di vendita dei capi venduti, che equivale al prezzo di produzione per 7
                profittoGiorn += guadagnoCapo;//viene aggiunto il guadagno al profitto giornaliero
                Console.WriteLine($"I capi sono stati venduti a {guadagnoCapo} euro.");//viene dato un feedback riguardo la vendita del capo

                righeCapi[numeroCapoVenduto - 1] = $"{capoVenduto[0]};{capoVenduto[1]};{capoVenduto[2]};{capoVenduto[3]};{capoVenduto[4]};{capoVenduto[5]};";//si salvano nel file le caratteristiche del capo con la quantità modificata
                if (quantitàCapiRimanente == 0)//viene controllato se un capo di un certo tipo esaurisce e viene tolto dalla lista
                {
                    for (int a = numeroCapoVenduto - 1; a < righeCapi.Length - 1; a++)//questo algoritmo prende il capo successivo a quello venduto e lo mette nella posizione precedentemente occupata da quest'ultimo
                    {
                        righeCapi[a] = righeCapi[a + 1];
                    }
                    righeCapi[righeCapi.Length - 1] = "";
                    Array.Resize(ref righeCapi, righeCapi.Length - 1);//viene ridimensionata la dimensione della stringa-array in modo da non lasciare spazi vuoti
                }
                File.WriteAllLines(percorsoFileCapi, righeCapi);//viene tutto salvato sul file esterno dedicato ai capi
                SalvataggioMateriali();//si richiama questa funzione per salvare il profitto giornaliero
                RicalcoloSommaQuantitàCapi();//si ricalcola la quantità di capi che si posseggono
            }
            carattereJolly();
        }

        static void Menù4()//opzioni aggiuntive
        {
            Console.WriteLine("\n------------------------------------OPZIONI AGGIUNTIVE------------------------------------");//viene mostrato a schermo il menù delle opzioni aggiuntive
            Console.WriteLine("1. Ordina delle stoffe;");
            Console.WriteLine("2. Rispondi nuovamente alle domande essenziali;");
            Console.Write("3. Modifica i valori fissi di alcune variabili.\n------------------------------------------------------------------------------------------\nRisposta: ");
            string numOpzioni; //chiamo la variabile alla quale sarà assegnato il valore corrispondente al punto del menù che l'utente vuole mandare in esecuzione
            numOpzioni = Console.ReadLine(); //assunzione valore da tastiera
            while (numOpzioni != "1" && numOpzioni != "2" && numOpzioni != "3")//viene controllato che il valore inserito faccia parte di quelli proposti
            {
                Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                numOpzioni = Console.ReadLine();
            }
            switch (numOpzioni)
            {
                case "1":     //nel caso in cui l'utente cliccasse 1 gli verrà permesso di ordinare delle stoffe
                    OrdinaStoffe();
                    break;
                case "2":     //nel caso in cui l'utente cliccasse 2 potrà rispondere di nuovo alle domande iniziali
                    DomandeEssenziali();
                    break;
                case "3":
                    InserimentoQuantitàMassime();       //nel caso in cui l'utente cliccasse 3 potrà modificare i valori fissi di alcune variabili
                    break;
            }
            carattereJolly();
        }

        static void OrdinaStoffe()//permette di ordinare delle stoffe
        {
            RicalcoloSommaQuantitàStoffe();//viene ricalcolato quante stoffe sono presenti in magazzino
            string iteratore = "0";//l'iteratore permetterà di ordinare più di un tipo di stoffa nel caso in cui lo voglia
            while (iteratore == "0")
            {
                if (stoffeMaxMagazzino <= sommaQuantitàStoffe)//si controlla che il magazzino non sia già pieno di stoffe
                {
                    Console.WriteLine("\nE' stata raggiunta la quantità massima di stoffa immagazzinabile; è neccessario usarne per poterne comprare di nuova.");
                    iteratore = "";
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("\nDi che materiale è la stoffa che vuoi comprare?\n1 -> Cotone \n2 -> Lino\n3 -> Seta\n4 -> Pizzo\n5 -> Velluto\n6 -> Lana\n7 -> Maglia\nRisposta: ");
                    materiale = Console.ReadLine();
                    while (materiale != "1" && materiale != "2" && materiale != "3" && materiale != "4" && materiale != "5" && materiale != "6" && materiale != "7") //controlla che il numero inserito faccia parte dei numeri proposti
                    {
                        Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        materiale = Console.ReadLine();
                    }
                    if (materiale == "3" || materiale == "6")
                    {
                        Console.Write("\nDi che raffinatezza è la stoffa che vuoi comprare?\n1 -> Base \n2 -> Alta\nRisposta: ");
                        raffinatezza = Console.ReadLine();
                        while (raffinatezza != "1" && raffinatezza != "2") //controlla che il numero inserito faccia parte dei numeri proposti
                        {
                            Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                            raffinatezza = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.Write("\nDi che raffinatezza è la stoffa che vuoi comprare?\n1 -> Base \n2 -> Media \n3 -> Alta\nRisposta: ");
                        raffinatezza = Console.ReadLine();
                        while (raffinatezza != "1" && raffinatezza != "2" && raffinatezza != "3") //controlla che il numero inserito faccia parte dei numeri proposti
                        {
                            Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                            raffinatezza = Console.ReadLine();
                        }
                    }

                    Console.Write("\nQuanti metri di stoffa vuoi ordinare?\nRisposta: ");
                    string richiestaQuantitàStoffa = Console.ReadLine();//viene controllato che ciò che l'utente inserisce sia un valore convertibile in double
                    double quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    while (sommaQuantitàStoffe + quantitàStoffa > stoffeMaxMagazzino)//viene controllato che l'utente inserisca una quantità di stoffa immagazzinabile
                    {
                        Console.Write("\nNon c'è abbastanza spazio per immagazzinare la quantità di stoffe inserita. Reinserire il valore.  \nRisposta: ");
                        richiestaQuantitàStoffa = Console.ReadLine();//viene controllato che ciò che l'utente inserisce sia un valore convertibile in double
                        quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        while (quantità < 0)//viene controllato che l'utente non inserica un valore negativo
                        {
                            Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                            richiestaQuantitàStoffa = Console.ReadLine();//viene controllato che ciò che l'utente inserisce sia un valore convertibile in double
                            quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        }
                    }
                    while (quantità < 0)//viene controllato che l'utente non inserica un valore negativo
                    {
                        Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                        richiestaQuantitàStoffa = Console.ReadLine();//viene controllato che ciò che l'utente inserisce sia un valore convertibile in double
                        quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    }


                    switch (materiale)//in base al valore inserito lo switch assegnerà alla terza posizione dell'array informazioni il tipo di stoffa che si vuole comprare
                    {
                        case "1":
                            informazioni[2] = "cotone";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 2.5; break;
                                case "2": informazioni[3] = "media"; prezzraff = 5; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 7; break;
                            }
                            break;
                        case "2":
                            informazioni[2] = "lino";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 3; break;
                                case "2": informazioni[3] = "media"; prezzraff = 6; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 10; break;
                            }
                            break;
                        case "3":
                            informazioni[2] = "seta";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 11; break;
                                case "2": informazioni[3] = "alta"; prezzraff = 22; break;
                            }
                            break;
                        case "4":
                            informazioni[2] = "pizzo";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 1.5; break;
                                case "2": informazioni[3] = "media"; prezzraff = 4; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 5.5; break;
                            }
                            break;
                        case "5":
                            informazioni[2] = "velluto";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 4; break;
                                case "2": informazioni[3] = "media"; prezzraff = 8; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 13; break;
                            }
                            break;
                        case "6":
                            informazioni[2] = "lana";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 3; break;
                                case "2": informazioni[3] = "alta"; prezzraff = 7; break;
                            }
                            break;
                        case "7":
                            informazioni[2] = "maglia";
                            switch (raffinatezza)//in base al valore inserito lo switch assegnerà alla quarta posizione dell'array informazioni la raffinatezza della stoffa e il suo prezzo
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 3.5; break;
                                case "2": informazioni[3] = "media"; prezzraff = 7; break;
                                case "3": informazioni[3] = "alta"; prezzraff = 10; break;
                            }
                            break;
                    }
                    //viene comunicato all'utente ciò che sta per ordinare e viene chiesta una conferma
                    Console.WriteLine($"\nStai per ordinare {quantitàStoffa} metri di {informazioni[2]} di raffinatezza {informazioni[3]} a {prezzraff * quantitàStoffa} euro.");
                    Console.Write("Digita '0' per annullare l'ordinazione; digita altro per continuare;\nRisposta: ");
                    string conferma = Console.ReadLine();
                    if (conferma == "0")
                    {
                        Console.WriteLine("\nL'ordinazione della stoffa è stata annullata.");
                    }
                    else
                    {
                        Console.WriteLine($"\nSono stati ordinati {quantitàStoffa} metri di {informazioni[2]} di raffinatezza {informazioni[3]} a {prezzraff * quantitàStoffa} euro.");//viene dato un feedback riguardo la stoffa comprata
                        stoffe[Int32.Parse(materiale) - 1] += quantitàStoffa;//viene aggiunta la stoffa comprata alla stoffa in magazzino
                        profittoGiorn -= prezzraff * quantitàStoffa;//viene sottratto il prezzo della stoffa comprata al profitto giornaliero
                        SalvataggioMateriali();//vengono salvati i materiali che si posseggono e il profitto giornaliero
                        RicalcoloSommaQuantitàStoffe();//viene ricalcolata la quantità totale di stoffe che si posseggono
                    }                    
                    Console.Write("\nDigita '0' per ordinare altra stoffa; premi altro per tornare al menù principale\nRisposta: ");//viene chiesto se si vuole ordinare altra stoffa
                    iteratore = Console.ReadLine();//se l'iteratore è diverso da '0' il while si interrompe e fa tornare l'utente al menù principale
                }
            }
            NavigazioneDichiarazioneMenù();
        }

        static void InserimentoQuantitàMassime()//permette all'utente di modificare i valori di alcune variabili
        {
            RicalcoloSommaQuantitàStoffe();//viene ricalcolata la quantità totale di stoffe che si posseggono

            //vengono mostrati gli attuali valori delle variabili modificabili
            Console.WriteLine($"\nQueste sono le quantità fisse impostate al momento:\nCapienza massima di stoffa in magazzino: {stoffeMaxMagazzino} metri;\nCapienza massima di abiti in magazzino: {capiMaxMagazzino} capi;\nCosto del colorante per abito: {colore} euro;\nAggiunta per la manodopera: {manodopera} euro.");
            string controllo = "";//variabile per la ripetizione del while
            Console.Write("\nPer modificare le quantità digita '0', altrimenti premi qualsiasi altro tasto per tornare al menù principale.\nRisposta: ");
            string rispostaQuantitàFisse = Console.ReadLine();
            while (controllo == "")
            {
                switch (rispostaQuantitàFisse)
                {
                    case "0"://se si inserisce '0' il programma chiede quale variabile si vuole modificare
                        Console.Write("\nQuale quantità vuoi modificare?\n1 -> Capienza massima di stoffa in magazzino\n2 -> Capienza massima di abiti in magazzino\n3 -> Costo del colorante per abito\n4 -> Aggiunta per la manodopera\nRisposta: ");
                        string risposta = Console.ReadLine();
                        switch (risposta)
                        {
                            case "1"://se si inserisce 1 si può modificare la capienza massima di stoffa
                                Console.Write("\nInserire la capienza massima di stoffa in magazzino espressa in metri:\nRisposta: ");
                                string controlloConversione1 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in double
                                stoffeMaxMagazzino = ControlloReadLineDouble(controlloConversione1, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");//si assegna alla variabile il valore inserito dall'utente
                                while (stoffeMaxMagazzino < 0 || stoffeMaxMagazzino < sommaQuantitàStoffe)//se il valore assegnato è negativo o minore della quantità attuale di stoffe in magazzino il programma impedisce all'utente di continuare
                                {
                                    Console.Write("\nLa quantità di stoffe massime non può essere minore di zero o della quantità di stoffe immagazzinate al momento; reinserire.\nRisposta: ");
                                    controlloConversione1 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in double
                                    stoffeMaxMagazzino = ControlloReadLineDouble(controlloConversione1, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");
                                }
                                Console.WriteLine("\nLa quantità delle stoffe massime è stata modificata.");
                                break;
                            case "2"://se si inserisce 2 si può modificare la capienza massima di capi
                                Console.Write("\nInserire la capienza massima di abiti in magazzino:\nRisposta: ");
                                string controlloConversione2 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in intero
                                capiMaxMagazzino = ControlloReadLineInt32(controlloConversione2, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");
                                while (capiMaxMagazzino < 0 || capiMaxMagazzino < sommaQuantitàCapi)//se il valore assegnato è negativo o minore della quantità attuale di capi in magazzino il programma impedisce all'utente di continuare
                                {
                                    Console.Write("\nLa quantità di capi massimi non può essere minore di zero o della quantità di capi immagazzinati al momento; reinserire.\nRisposta: ");
                                    controlloConversione2 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in intero
                                    capiMaxMagazzino = ControlloReadLineInt32(controlloConversione2, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");
                                }
                                Console.WriteLine("\nLa capienza massima di abiti è stata modificata.");
                                break;
                            case "3"://se si inserisce 3 si può modificare il costo del colorante
                                Console.Write("\nInserire il costo del colorante per abito espresso in euro:\nRisposta: ");
                                string controlloConversione3 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in double
                                colore = ControlloReadLineDouble(controlloConversione3, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");
                                while (colore < 0)//viene controlalto che il valore inserito dall'utente non sia negativo
                                {
                                    Console.Write("\nIl costo del colorante non può essere minore di 0; reinserire.\nRisposta: ");
                                    controlloConversione3 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in double
                                    colore = ControlloReadLineDouble(controlloConversione3, "Il carattere inserito non è valido; reinserire.");
                                }
                                Console.WriteLine("\nIl costo del colorante è stato modificato.");
                                break;
                            case "4"://se si inserisce 4 si può modificare il costo della manodopera
                                Console.Write("\nInserire il costo della manodopera per abito espresso in euro:\nRisposta: ");
                                string controlloConversione4 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in double
                                manodopera = ControlloReadLineDouble(controlloConversione4, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");
                                while (manodopera < 0)//viene controllato che il valore inserito non sia negativo
                                {
                                    Console.Write("\nIl costo della manodopera non può essere minore di 0; reinserire.\nRisposta: ");
                                    controlloConversione4 = Console.ReadLine();//viene controllato che ciò che l'utente inserisce si possa convertire in double
                                    manodopera = ControlloReadLineDouble(controlloConversione4, "\nIl carattere inserito non è valido; reinserire.\nRisposta: ");
                                }
                                Console.WriteLine("\nIl costo della manodopera è stato modificato.");
                                break;
                        }

                        StreamWriter riscritturaImpostazioni = new StreamWriter(percorsoFileImpostazioni, false);//vengono sovrascritte le vecchie impostazioni con le nuove
                        riscritturaImpostazioni.WriteLine(stoffeMaxMagazzino);
                        riscritturaImpostazioni.WriteLine(capiMaxMagazzino);
                        riscritturaImpostazioni.WriteLine(colore);
                        riscritturaImpostazioni.WriteLine(manodopera);
                        riscritturaImpostazioni.Close();

                        Console.Write("\nInserisci '0' per modificare altro; premi qualsiasi altro tasto per tornare al menù principale.\nRisposta: ");//viene richiesto se si vogliono modificare ancora le impostazioni
                        string modificaAncora = Console.ReadLine();
                        if (modificaAncora != "0")//se non si inserisce 0 il programma riconduce al menù principale
                        {
                            NavigazioneDichiarazioneMenù();
                        }
                        break;
                    default: NavigazioneDichiarazioneMenù(); break;//se non si inserisce uno dei valori proposti il programma riconduce al menù principale
                }
            }



        }

        static void carattereJolly()//permette all'utente di uscire dal programma
        {
            Console.Write("\nDigitare '*' per uscire dal programma; digitare altro per navigare di nuovo il menù.\nRisposta: ");
            string jolly = Convert.ToString(Console.ReadLine());
            switch (jolly)
            {
                case "*"://se si inserisce '*' il programma viene chiuso
                    System.Environment.Exit(1);
                    break;
                default://se si inserisce altro il programma riconduce al menù principale
                    NavigazioneDichiarazioneMenù();
                    break;
            }

        }

        static double ControlloReadLineDouble(string daConvertire, string contenutoWriteLine)//controlla che ciò che viene inserito dall'utente sia convertibile nel tipo double
        {
            bool success = double.TryParse(daConvertire, out double convertito);//TryParse() tenta la conversione di ciò che è stato inserito dall'utente; la prima variabile nelle parentesi della funzione è una stringa contenente ciò che deve essere convertito, la seconda variabile è quella che conterrà il valore convertito nel caso si possa convertire
            while (!success)//se non è possibile convertire viene chiesto nuovamente di inserire un valore in seguito alla visualizzazione di un messaggio di errore
            {
                Console.Write(contenutoWriteLine);//visualizzazione di un messaggio, che corrisponde al contenuto della seconda variabile della funzione
                daConvertire = Console.ReadLine();//viene chiesto nuovamente ciò che deve essere convertito
                success = double.TryParse(daConvertire, out convertito);//viene nuovamente tentata la conversione
            }

            return convertito;//la funzione assume il valore del numero convertito
        }

        static int ControlloReadLineInt32(string daConvertire, string contenutoWriteLine)//controlla che ciò che viene inserito dall'utente sia convertibile nel tipo int
        {
            bool success = int.TryParse(daConvertire, out int convertito);//TryParse() tenta la conversione di ciò che è stato inserito dall'utente; la prima variabile nelle parentesi della funzione è una stringa contenente ciò che deve essere convertito, la seconda variabile è quella che conterrà il valore convertito nel caso si possa convertire
            while (!success)//se non è possibile convertire viene chiesto nuovamente di inserire un valore in seguito alla visualizzazione di un messaggio di errore
            {
                Console.Write(contenutoWriteLine);//visualizzazione di un messaggio, che corrisponde al contenuto della seconda variabile della funzione
                daConvertire = Console.ReadLine();//viene chiesto nuovamente ciò che deve essere convertito
                success = int.TryParse(daConvertire, out convertito);//viene nuovamente tentata la conversione
            }

            return convertito;//la funzione assume il valore del numero convertito
        }

        static void CaricamentoFile()//permette il caricamento dei file nel programma
        {
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "fileGestione/"))//viene controllato se esiste la cartella in cui sono contenute le cartelle contenenti i file di salvataggio
            {
                Console.WriteLine("Creazione cartelle essenziali in corso...");
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "fileGestione/");//se la cartella non esiste viene creata
                Console.WriteLine("Creata cartella principale.");
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/"))//viene controllato se esiste la cartella in cui sono contenuti i file di capi, materiali e impostazioni
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/");//se la cartella non esiste viene creata
                    Console.WriteLine("Creata cartella dei file generali.");
                }

                if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileProfitti/"))//viene controllato se esiste la cartella in cui sono contenuti i file dei profitti giornalieri
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileProfitti/");//se la cartella non esiste viene creata
                    Console.WriteLine("Creata cartella dei file dei profitti.\n\n");
                }
            }
            if (!File.Exists(percorsoFileCapi))//viene controllato se esiste il file dei capi
            {
                using (StreamWriter sw = File.CreateText(percorsoFileCapi))//se non esiste viene generato
                {

                }

            }
            
            if (!File.Exists(percorsoFileProfitti))//viene controllato se esiste il file dei profitti giornalieri
            {
                using (StreamWriter sw = File.CreateText(percorsoFileProfitti))//se non esiste viene generato
                {

                }

                StreamWriter profittoBase = new StreamWriter(percorsoFileProfitti, true);//si inserisce nel file appena creato il valore iniziale '0'
                profittoBase.WriteLine("0");
                profittoBase.Close();
            }
            if (!File.Exists(percorsoFileImpostazioni))//viene controllato se esiste il file delle impostazioni
            {
                using (StreamWriter sw = File.CreateText(percorsoFileImpostazioni))//se non esiste viene generato
                {

                }
                StreamWriter impostazioni = new StreamWriter(percorsoFileImpostazioni, true);//e vengono scritte nel file le impostazioni standard
                impostazioni.WriteLine("300");
                impostazioni.WriteLine("200");
                impostazioni.WriteLine("1");
                impostazioni.WriteLine("3");
                impostazioni.Close();
          
            }

            if (File.Exists(percorsoFileMateriali))//viene controllato se esiste il file dei materiali
            {
                string[] righeMateriali = File.ReadAllLines(percorsoFileMateriali);//se esiste, vengono subito lette le quantità di materiali salvate
                for (int i = 0; i < stoffe.Length; i++)//e si assegna ogni valore alla posizione corrispondente nell'array stoffe[]
                {
                    stoffe[i] = double.Parse(righeMateriali[i]);
                }
            }
                   
            string[] righeFileImpostazioni = File.ReadAllLines(percorsoFileImpostazioni);//si assegnano alle variabili fisse i valori salvati nel file delle impostazioni
            stoffeMaxMagazzino = double.Parse(righeFileImpostazioni[0]);
            capiMaxMagazzino = Int32.Parse(righeFileImpostazioni[1]);
            colore = double.Parse(righeFileImpostazioni[2]);
            manodopera = double.Parse(righeFileImpostazioni[3]);

            string[] righeFileProfitti = File.ReadAllLines(percorsoFileProfitti);//si assegna alla variabile del profitto giornaliero il valore che è stato salvato nel file odierno
            profittoGiorn = double.Parse(righeFileProfitti[0]);
            RicalcoloSommaQuantitàStoffe();//viene ricalcolata la quantità di stoffe che si posseggono
            RicalcoloSommaQuantitàCapi();//viene ricalcolata la quantità di capi che si posseggono

            if (!File.Exists(percorsoFileMateriali))//viene controllato se esiste il file dei materiali in possesso
            {
                using (StreamWriter sw = File.CreateText(percorsoFileMateriali))//se non esiste viene generato
                {

                }
                Console.WriteLine("Sembra che questo sia il primo avvio del programma, quindi verranno richieste delle informazioni essenziali.\n");
                DomandeEssenziali();//e l'utente risponde a delle domande riguardo i materiali posseduti

            }
        }

        static void SalvataggioMateriali()//salva i materiali e l profitto giornaliero in due file esterni
        {
            StreamWriter streamwriter = new StreamWriter(percorsoFileMateriali, false);//vengono salvate le stoffe in possesso sovrascrivendo i dati precedenti
            for (int a = 0; a < stoffe.Length; a++)//per ogni stoffa viene scritta la sua quantità nel file
            {
                streamwriter.WriteLine(stoffe[a]);
            }
            streamwriter.Close();
            StreamWriter profitti = new StreamWriter(percorsoFileProfitti, false);//viene salvato il profitto giornaliero in un file avente come nome la data odierna
            profitti.WriteLine(profittoGiorn);
            profitti.Close();
        }

        static void RicalcoloSommaQuantitàStoffe()//ricalcola la quantità di stoffe attualmente immagazzinate
        {
            sommaQuantitàStoffe = 0;//viene resettato il valore del totale
            for (int a = 0; a < stoffe.Length; a++)//e si aggiunge alla variabile la quantità attualmente in possesso di ogni stoffa
            {
                sommaQuantitàStoffe += stoffe[a];
            }
        }

        static void RicalcoloSommaQuantitàCapi()//ricalcola la quantità di capi attualmente immagazzinati
        {
            sommaQuantitàCapi = 0;
            string[] righeCapi = File.ReadAllLines(percorsoFileCapi);//viene letto il file dei capi
            for (int a = 0; a < righeCapi.Length; a++)//si somma la quantità di ogni capo immagazzinato
            {
                string[] capo = righeCapi[a].Split(";");
                sommaQuantitàCapi += Int32.Parse(capo[4]);
            }
        }
    }
}
