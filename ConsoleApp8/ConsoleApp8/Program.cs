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
        static string orario = DateTime.Now.ToString("d-MM-yyyy");
        static string fileCapi = @"Capi.txt";
        static string fileMateriali = @"Materiali.txt";
        static string fileProfitti = $@"Profitti {orario}";
        static string impostazioni = @"Impostazioni";
        static string percorsoFileImpostazioni = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/" + impostazioni;
        static string percorsoFileCapi = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/" + fileCapi;
        static string percorsoFileMateriali = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileGenerali/" + fileMateriali;
        static string percorsoFileProfitti = AppDomain.CurrentDomain.BaseDirectory + "fileGestione/fileProfitti/" + fileProfitti;
        static double sommaQuantitàStoffe = 0, colore, manodopera, tesspertagl = 0, prezzraff = 0, prezzoprod = 0, profittoGiorn, stoffeMaxMagazzino, quantitàDiAllarme;
        static int capiMaxMagazzino, sommaQuantitàCapi = 0, contatore = 0, quantità = 0;
        static string capo, taglia, materiale, raffinatezza;



        static void Main(string[] args)
        {
            CaricamentoFile();
            NavigazioneDichiarazioneMenù();
            Console.ReadKey();  
        }

        static void InserimentoStoffe()
        {
            string controllo;
            //Domande essenziali riguardanti la quantità di stoffa e i capi presenti in magazzino oltre ai capi venduti utili per lo svolgimento del codice del programma

            for(int a = 0; a < stoffe.Length; a++)
            {
                Console.WriteLine($"Quanti metri di {nomiStoffe[a]} ci sono in magazzino?");
                controllo = Console.ReadLine();
                stoffe[a] = ControlloReadLineDouble(controllo, "Il carattere inserito non è valido");
                while (stoffe[a] < 0)
                {
                    Console.WriteLine("Il valore non può essere negativo; reinserire il valore:");
                    controllo = Console.ReadLine();
                    stoffe[a] = ControlloReadLineDouble(controllo, "Il carattere inserito non è valido");
                } //assunzione valore da tastiera del cotone che sarà inserito nell'array
            }            
            SalvataggioMateriali();
        }

        static void DomandeEssenziali()
        {
            InserimentoStoffe();
            RicalcoloSommaQuantitàStoffe();

            if (sommaQuantitàStoffe > stoffeMaxMagazzino) //controllo se la quantità di stoffa presente in magazzino supera la capienza massima
            {
                Console.Write("\nCi sono troppi metri di stoffa; hai sbagliato a digitare i numeri? Rispondi con '1' se vuoi reinserire le quantità.\nRisposta: "); //se le stoffe in magazzzino sono troppe e superano la capienzamax chiedo all'utente se v
                string risposta = Console.ReadLine();
                if (risposta == "1")// se l'utente risponde "1" reinserisce le quantita di ogni stoffa
                {
                    sommaQuantitàStoffe = 0; //riazzero la somma della quantità delle stoffe
                    for (int b = 0; b < 7; b++) //creo un for 
                    {
                        stoffe[b] = 0; //assegno il valore 0 ad ogni livello dell'array stoffe, per poter reinserire le quantità
                    }

                    Console.Write("\nReinserisci le quantità delle stoffe:\n");
                    InserimentoStoffe();
                    RicalcoloSommaQuantitàStoffe();
                    
                }
                if (sommaQuantitàStoffe > stoffeMaxMagazzino) //se la quantità restasse ancora maggiore della capienza
                {
                    Console.WriteLine("I metri di stoffa presenti in magazzino sono troppi"); //lo comunico all'utente 
                    Console.Write("Se vuoi mandare dei capi in produzione digita '0', altrimenti schiaccia qualsiasi altro tasto per continuare\n");//e gli chiedo se vuole mandare dei capi in produzione in modod da diminuire la quantità di stoffa presente in magazzino
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
            Console.Clear();
            //comunico all'utente cosa c'è all'interno del menù
            Console.WriteLine($"Oggi è il {orario}");
            Console.WriteLine("\n\t\t\tMENU':\n");
            Console.WriteLine("Digita 1 se vuoi visualizzare la stoffa immagazzinata, lo spazio occupato e il profitto giornaliero;");
            Console.WriteLine("Digita 2 se vuoi mandare in produzione dei capi;");
            Console.WriteLine("Digita 3 se vuoi vendere i capi che sono stati prodotti;");
            Console.WriteLine("Digita 4 se vuoi visualizzare delle opzioni aggiuntive;");
            Console.Write("Digita * se vuoi terminare il programma.\nRisposta: ");

            string NumeroMenù; //chiamo la variabile alla quale sarà assegnato il valore corrispondente al punto del menù che l'utente vuole mandare in esecuzione
            NumeroMenù = Console.ReadLine(); //assunzione valore da tastiera
            while (NumeroMenù != "1" && NumeroMenù != "2" && NumeroMenù != "3" && NumeroMenù != "4" && NumeroMenù != "*")
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
                    System.Environment.Exit(1);
                    break;
            }
        }

        static void Menù1()
        {   //Comunico all'utente la quantità di ogni stoffa presente in magazzino

            Console.WriteLine("\nIn magazzino sono presenti:\n");
            for (int a = 0; a < stoffe.Length; a++)
            {
                Console.WriteLine($"{stoffe[a]} metri di {nomiStoffe[a]};");
            }
            Console.WriteLine($"\n{sommaQuantitàCapi} capi invenduti, c'è spazio ancora per {capiMaxMagazzino - sommaQuantitàCapi} capi nel magazzino.");

            RicalcoloSommaQuantitàStoffe();

            //comunico il magazzino occupato
            Console.WriteLine("In magazzino ci sono {0} metri di stoffa e ci possono stare ancora {1} metri", sommaQuantitàStoffe, stoffeMaxMagazzino - sommaQuantitàStoffe);
            Console.WriteLine("Il profitto giornaliero è di {0} euro.\n", profittoGiorn);

            for (int a = 0; a < stoffe.Length; a++)
            {
                if (stoffe[a] < (stoffeMaxMagazzino / 7) / 3)
                {
                    Console.WriteLine($"\aAttenzione! La stoffa '{nomiStoffe[a]}' sta terminando. Si consiglia di ordinarne di nuova.");
                }
            }

            carattereJolly();
        }

        static void Menù2()
        {
            if (sommaQuantitàCapi != capiMaxMagazzino)
            {
                Console.Write("\nQuanti capi differenti sono stati prodotti?\nRisposta: ");
                string controllo;
                controllo = Console.ReadLine();
                int capiDifferenti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido, reinserire.\nRisposta: ");
                while (capiDifferenti <= 0)
                {
                    Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                    controllo = Console.ReadLine();
                    capiDifferenti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido, reinserire.\nRisposta: ");
                }

                for (contatore = 0; contatore < capiDifferenti; contatore++)
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
                    if (materiale == "3" || materiale == "6")
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
                    Console.Write("\nQuanti ne hai prodotti?\nRisposta: ");
                    controllo = Console.ReadLine();
                    quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    while (sommaQuantitàCapi + quantità > capiMaxMagazzino)
                    {
                        Console.Write("\nNon c'è abbastanza spazio per immagazzinare la quantità di capi inserita. Reinserire il valore.  \nRisposta: ");
                        controllo = Console.ReadLine();
                        quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        while (quantità < 0)
                        {
                            Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                            controllo = Console.ReadLine();
                            quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                        }
                    }
                    while (quantità < 0)
                    {
                        Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                        controllo = Console.ReadLine();
                        quantità = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    }
                    informazioni[4] = quantità.ToString();

                    switch (capo)
                    {
                        case "1":
                            informazioni[0] = "felpa";
                            switch (taglia)
                            {
                                case "1": informazioni[1] = "S"; tesspertagl = 2; break;
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

                    switch (materiale)
                    {
                        case "1":
                            informazioni[2] = "cotone";
                            switch (raffinatezza)
                            {
                                case "1": informazioni[3] = "base"; prezzraff = 2.5; break;
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

                    prezzoprod = tesspertagl * prezzraff + colore + manodopera;
                    profittoGiorn -= colore + manodopera * quantità;
                    informazioni[5] = prezzoprod.ToString();

                    Console.WriteLine($"\nQueste sono le informazioni riguardo al capo che sta per essere prodotto: \nTipo di capo: {informazioni[0]};\nTaglia: {informazioni[1]};\nMateriale: {informazioni[2]};\nRaffinatezza: {informazioni[3]};\nQuantità: {informazioni[4]};\nPrezzo di produzione per ogni capo: {informazioni[5]} euro;\nPrezzo totale di produzione: {double.Parse(informazioni[4])*double.Parse(informazioni[5])} euro.");
                    Console.Write("\nSei sicuro di volerlo produrre? Digita '0' per annullare la produzione; digita qualsiasi altra cosa per continuare.\nRisposta: ");
                    string rispostaProduzione = Console.ReadLine();

                    if(rispostaProduzione != "0")
                    {
                        if (stoffe[int.Parse(materiale) - 1] - tesspertagl * quantità < 0)
                        {
                            Console.WriteLine("\nLa stoffa necessaria per produrre l'abito non è sufficiente, per cui l'abito non verrà prodotto.");
                        }
                        else
                        {
                            stoffe[int.Parse(materiale) - 1] -= tesspertagl * quantità;
                            string salvataggioCaratteristiche = $"{informazioni[0]};{informazioni[1]};{informazioni[2]};{informazioni[3]};{informazioni[4]};{informazioni[5]}";
                            Console.WriteLine("\nIl capo è stato prodotto con successo.");
                            StreamWriter caratteristicheCapi = new StreamWriter(percorsoFileCapi, true);
                            caratteristicheCapi.WriteLine(salvataggioCaratteristiche);
                            caratteristicheCapi.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nLa produzione dell'abito è stata annullata.");
                    }
                    SalvataggioMateriali();
                }
            }
            else
            {
                Console.WriteLine("\nE' stata raggiunta la quantità massima di capi immagazzinabili; è neccessario venderne per poterne produrre di nuovi.");
            }

            carattereJolly();
        }

        static void Menù3()
        {
            string[] righeCapi = File.ReadAllLines(percorsoFileCapi);
            if (righeCapi.Length == 0)
            {
                Console.WriteLine("\aNel magazzino non sono presenti capi.");
            }
            else
            {
                Console.WriteLine("\nQuesti sono i capi attualmente in magazzino:\n");
                for (int m = 0; m < righeCapi.Length; m++)
                {
                    Console.WriteLine($"Capo numero {m + 1}: {righeCapi[m]}");
                }

                Console.Write("\nQuale capo è stato venduto?\nRisposta: ");
                string controllo = Console.ReadLine();
                int numeroCapoVenduto = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                while (numeroCapoVenduto < 1 || numeroCapoVenduto > righeCapi.Length)
                {
                    Console.Write("\nLa quantità inserita non è valida; reinserire.\nRisposta: ");
                    controllo = Console.ReadLine();
                    numeroCapoVenduto = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                }
                string[] capoVenduto = righeCapi[numeroCapoVenduto - 1].Split(";");

                Console.Write("\nQuanti ne sono stati venduti?\nRisposta: ");
                controllo = Console.ReadLine();
                int quantitàCapiVenduti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                while (Int32.Parse(capoVenduto[4]) - quantitàCapiVenduti < 0)
                {
                    Console.Write("\nLa quantità inserita non è valida; reinserire il numero: ");
                    controllo = Console.ReadLine();
                    quantitàCapiVenduti = ControlloReadLineInt32(controllo, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                }

                int quantitàCapiRimanente = Int32.Parse(capoVenduto[4]) - quantitàCapiVenduti;
                capoVenduto[4] = Convert.ToString(quantitàCapiRimanente);

                double guadagnoCapo = double.Parse(capoVenduto[5]) * quantitàCapiVenduti * 7;
                profittoGiorn += guadagnoCapo;
                Console.WriteLine($"I capi sono stati venduti a {guadagnoCapo} euro.");

                righeCapi[numeroCapoVenduto - 1] = $"{capoVenduto[0]};{capoVenduto[1]};{capoVenduto[2]};{capoVenduto[3]};{capoVenduto[4]};{capoVenduto[5]};";
                if (quantitàCapiRimanente == 0)
                {
                    for (int a = numeroCapoVenduto - 1; a < righeCapi.Length - 1; a++)
                    {
                        righeCapi[a] = righeCapi[a + 1];
                    }
                    righeCapi[righeCapi.Length - 1] = "";
                    Array.Resize(ref righeCapi, righeCapi.Length - 1);
                }
                File.WriteAllLines(percorsoFileCapi, righeCapi);
                SalvataggioMateriali();
            }
            carattereJolly();
        }

        static void Menù4()
        {
            Console.WriteLine("\n\t\t\tOPZIONI AGGIUNTIVE:\n");
            Console.WriteLine("Digita 1 se vuoi ordinare della stoffa;");
            Console.WriteLine("Digita 2 se vuoi rispondere di nuovo alle domande essenziali;");
            Console.Write("Digita 3 se vuoi modificare i valori fissi di alcune variabili.\nRisposta: ");
            string numOpzioni; //chiamo la variabile alla quale sarà assegnato il valore corrispondente al punto del menù che l'utente vuole mandare in esecuzione
            numOpzioni = Console.ReadLine(); //assunzione valore da tastiera
            while (numOpzioni != "1" && numOpzioni != "2" && numOpzioni != "3")
            {
                Console.Write("\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                numOpzioni = Console.ReadLine();
            }
            switch (numOpzioni)
            {
                case "1":     //nel caso in cui l'utente cliccasse 1 chiamo la funzione Menù1
                    OrdinaStoffe();
                    break;
                case "2":     //nel caso in cui l'utente cliccasse 2 chiamo la funzione Menù2
                    DomandeEssenziali();
                    break;
                case "3":
                    InserimentoQuantitàMassime();
                    break;
            }
            carattereJolly();
        }

        static void OrdinaStoffe()
        {
            RicalcoloSommaQuantitàStoffe();
            if (stoffeMaxMagazzino != sommaQuantitàStoffe)
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
                string richiestaQuantitàStoffa = Console.ReadLine();
                double quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                while (sommaQuantitàStoffe + quantitàStoffa > stoffeMaxMagazzino)
                {
                    Console.Write("\nNon c'è abbastanza spazio per immagazzinare la quantità di stoffe inserita. Reinserire il valore.  \nRisposta: ");
                    richiestaQuantitàStoffa = Console.ReadLine();
                    quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    while (quantità < 0)
                    {
                        Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                        richiestaQuantitàStoffa = Console.ReadLine();
                        quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                    }
                }
                while (quantità < 0)
                {
                    Console.Write("\nLa quantità non può essere minore di zero; reinserire.\nRisposta: ");
                    richiestaQuantitàStoffa = Console.ReadLine();
                    quantitàStoffa = ControlloReadLineDouble(richiestaQuantitàStoffa, "\nCiò che hai inserito non è valido; reinserire.\nRisposta: ");
                }


                switch (materiale)
                {
                    case "1":
                        informazioni[2] = "cotone";
                        switch (raffinatezza)
                        {
                            case "1": informazioni[3] = "base"; prezzraff = 2.5; break;
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

                Console.WriteLine($"\nSono stati ordinati {quantitàStoffa} metri di {informazioni[2]} a {prezzraff * quantitàStoffa} euro.");
                stoffe[Int32.Parse(materiale) - 1] += quantitàStoffa;
            }
            else
            {
                Console.WriteLine("\nE' stata raggiunta la quantità massima di stoffa immagazzinabile; è neccessario usarne per poterne comprare di nuova.");
            }

        }

        static void InserimentoQuantitàMassime()
        {
            RicalcoloSommaQuantitàStoffe();

            Console.WriteLine($"\nQueste sono le quantità fisse impostate al momento:\nCapienza massima di stoffa in magazzino: {stoffeMaxMagazzino} metri;\nCapienza massima di abiti in magazzino: {capiMaxMagazzino} capi;\nCosto del colorante per abito: {colore} euro;\nAggiunta per la manodopera: {manodopera} euro.");
            string controllo = "";

            
            Console.Write("\nPer modificare le quantità digita '0', altrimenti premi qualsiasi altro tasto per tornare al menù principale.\nRisposta: ");
            string rispostaQuantitàFisse = Console.ReadLine();
            while(controllo == "")
            {
                switch (rispostaQuantitàFisse)
                {
                    case "0":
                        Console.Write("\nQuale quantità vuoi modificare?\n1 -> Capienza massima di stoffa in magazzino\n2 -> Capienza massima di abiti in magazzino\n3 -> Costo del colorante per abito\n4 -> Aggiunta per la manodopera\nRisposta: ");
                        string risposta = Console.ReadLine();
                        switch (risposta)
                        {
                            case "1":
                                Console.Write("Inserire la capienza massima di stoffa in magazzino espressa in metri:\nRisposta: ");
                                string controlloConversione1 = Console.ReadLine();
                                stoffeMaxMagazzino = ControlloReadLineDouble(controlloConversione1, "Il carattere inserito non è valido; reinserire.");
                                while (stoffeMaxMagazzino < 0 || stoffeMaxMagazzino < sommaQuantitàStoffe)
                                {
                                    Console.WriteLine("La quantità di stoffe massime non può essere minore di zero o della quantità di stoffe immagazzinate al momento; reinserire.");
                                    controlloConversione1 = Console.ReadLine();
                                    stoffeMaxMagazzino = ControlloReadLineDouble(controlloConversione1, "Il carattere inserito non è valido; reinserire.");
                                }
                                break;
                            case "2":
                                Console.Write("Inserire la capienza massima di abiti in magazzino:\nRisposta: ");
                                string controlloConversione2 = Console.ReadLine();
                                capiMaxMagazzino = ControlloReadLineInt32(controlloConversione2, "Il carattere inserito non è valido; reinserire.");
                                while (capiMaxMagazzino < 0 || capiMaxMagazzino < sommaQuantitàCapi)
                                {
                                    Console.WriteLine("La quantità di capi massimi non può essere minore di zero o della quantità di capi immagazzinati al momento; reinserire.");
                                    controlloConversione2 = Console.ReadLine();
                                    capiMaxMagazzino = ControlloReadLineInt32(controlloConversione2, "Il carattere inserito non è valido; reinserire.");
                                }
                                break;
                            case "3":
                                Console.Write("Inserire il costo del colorante per abito espresso in euro:\nRisposta: ");
                                string controlloConversione3 = Console.ReadLine();
                                colore = ControlloReadLineDouble(controlloConversione3, "Il carattere inserito non è valido; reinserire.");
                                while (colore < 0)
                                {
                                    Console.WriteLine("Il costo del colorante non può essere minore di 0; reinserire.");
                                    controlloConversione3 = Console.ReadLine();
                                    colore = ControlloReadLineDouble(controlloConversione3, "Il carattere inserito non è valido; reinserire.");
                                }
                                break;
                            case "4":
                                Console.Write("Inserire il costo della manodopera per abito espresso in euro:\nRisposta: ");
                                string controlloConversione4 = Console.ReadLine();
                                manodopera = ControlloReadLineDouble(controlloConversione4, "Il carattere inserito non è valido; reinserire.");
                                while (manodopera < 0)
                                {
                                    Console.WriteLine("Il costo della manodopera non può essere minore di 0; reinserire.");
                                    controlloConversione4 = Console.ReadLine();
                                    manodopera = ControlloReadLineDouble(controlloConversione4, "Il carattere inserito non è valido; reinserire.");
                                }
                                break;
                        }
                        Console.Write("\nInserisci '0' per modificare altro; premi qualsiasi altro tasto per tornare al menù principale.\nRisposta: ");
                        string modificaAncora = Console.ReadLine();
                        if (modificaAncora != "0")
                        {
                            NavigazioneDichiarazioneMenù();
                        }
                        break;
                    default: NavigazioneDichiarazioneMenù(); break;
                }
            }
            
            
            
        }
        
        static void carattereJolly()
        {
            Console.Write("\nDigitare '*' per uscire dal programma; digitare altro per navigare di nuovo il menù.\nRisposta: ");
            string jolly = Convert.ToString(Console.ReadLine());
            switch (jolly)
            {
                case "*":
                    System.Environment.Exit(1);
                    break;
                default:
                    NavigazioneDichiarazioneMenù();
                    break;
            }

        }

        static double ControlloReadLineDouble(string daConvertire, string contenutoWriteLine)
        {
            bool success = double.TryParse(daConvertire, out double convertito);
            while (!success)
            {
                Console.Write(contenutoWriteLine);
                daConvertire = Console.ReadLine();
                success = double.TryParse(daConvertire, out convertito);
            }

            return convertito;
        }

        static int ControlloReadLineInt32(string daConvertire, string contenutoWriteLine)
        {
            bool success = int.TryParse(daConvertire, out int convertito);
            while (!success)
            {
                Console.Write(contenutoWriteLine);
                daConvertire = Console.ReadLine();
                success = int.TryParse(daConvertire, out convertito);
            }

            return convertito;
        }

        static void CaricamentoFile()
        {
            if (!File.Exists(percorsoFileCapi))
            {
                using (StreamWriter sw = File.CreateText(percorsoFileCapi))
                {

                }

            }
            if (!File.Exists(percorsoFileMateriali))
            {
                using (StreamWriter sw = File.CreateText(percorsoFileMateriali))
                {

                }
                DomandeEssenziali();

            }
            if (!File.Exists(percorsoFileProfitti))
            {
                using (StreamWriter sw = File.CreateText(percorsoFileProfitti))
                {

                }

                StreamWriter profittoBase = new StreamWriter(percorsoFileProfitti, true);
                profittoBase.WriteLine("0");
                profittoBase.Close();
            }
            if (!File.Exists(percorsoFileImpostazioni))
            {
                using (StreamWriter sw = File.CreateText(percorsoFileCapi))
                {

                }
                StreamWriter impostazioni = new StreamWriter(percorsoFileImpostazioni, true);
                impostazioni.WriteLine("300");
                impostazioni.WriteLine("200");
                impostazioni.WriteLine("1");
                impostazioni.WriteLine("3");
                impostazioni.Close();
            }

            string[] righeMateriali = File.ReadAllLines(percorsoFileMateriali);
            for (int i = 0; i < stoffe.Length; i++)
            {
                stoffe[i] = double.Parse(righeMateriali[i]);
            }

            string[] righeCapi = File.ReadAllLines(percorsoFileCapi);
            for (int a = 0; a < righeCapi.Length; a++)
            {
                string[] capo = righeCapi[a].Split(";");
                sommaQuantitàCapi += Int32.Parse(capo[4]);
            }

            string[] righeFileProfitti = File.ReadAllLines(percorsoFileProfitti);
            profittoGiorn = double.Parse(righeFileProfitti[0]);

            string[] righeFileImpostazioni = File.ReadAllLines(percorsoFileImpostazioni);
            stoffeMaxMagazzino = double.Parse(righeFileImpostazioni[0]);
            capiMaxMagazzino = Int32.Parse(righeFileImpostazioni[1]);
            colore = double.Parse(righeFileImpostazioni[2]);
            manodopera = double.Parse(righeFileImpostazioni[3]);

            RicalcoloSommaQuantitàStoffe();

        }

        static void SalvataggioMateriali()
        {
            StreamWriter streamwriter = new StreamWriter(percorsoFileMateriali, false);
            for (int a = 0; a < stoffe.Length; a++)
            {
                streamwriter.WriteLine(stoffe[a]);
            }
            streamwriter.Close();
            StreamWriter profitti = new StreamWriter(percorsoFileProfitti, false);
            profitti.WriteLine(profittoGiorn);
            profitti.Close();
        }

        static void RicalcoloSommaQuantitàStoffe()
        {
            sommaQuantitàStoffe = 0;
            for (int a = 0; a < stoffe.Length; a++)
            {
                sommaQuantitàStoffe += stoffe[a];
            }
        }
    }
}
