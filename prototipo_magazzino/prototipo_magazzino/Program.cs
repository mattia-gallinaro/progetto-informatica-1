using System;
using System.IO;

namespace prototipo_magazzino
{
    class Program
    {
        static double[] stoffe = new double[7];  //{ cotone, lino, seta, pizzo, velluto, lana, maglia }  dichiarazione array globale tessuti

        static string[] taglie = new string[4] { "S", "M", "L", "XL" };

        private static int felpe, giubbotti, pantaloni;

        private static int capivenduti;

        private static int StoffeMaxMagazzino = 300, CapiMaxMagazzino = 200, SommaQuantitàCapi = 0;
        private static double SommaQuantitàStoffe = 0, SpazioRestanteMagazzinoStoffe;
        private static int SpazioRestanteMagazzinoCapi;

        static string data;

        static void Main(string[] args)
        {

            DomandeEssenziali(); 
            NavigazioneDichiarazioneMenù();

            Console.ReadLine();
        }

        static void DomandeEssenziali()
        {
            //Domande essenziali riguardanti la quantità di stoffa e i capi presenti in magazzino oltre ai capi venduti utili per lo svolgimento del codice del programma
            Console.WriteLine("Scrivi la data di oggi (gg/mm/aaaa)");
            data = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Quanti metri di cotone ci sono in magazzino?");
            stoffe[0] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera del cotone che sarà inserito nell'array
            Console.WriteLine("Quanti metri di lino ci sono in magazzino?");
            stoffe[1] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera del lino che sarà inserito nell'array
            Console.WriteLine("Quanti metri di seta ci sono in magazzino?");
            stoffe[2] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera deella seta che sarà inserito nell'array
            Console.WriteLine("Quanti metri di pizzo ci sono in magazzino?");
            stoffe[3] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera di pizzo che sarà inserito nell'array
            Console.WriteLine("Quanti metri di velluto ci sono in magazzino?");
            stoffe[4] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera del velluto che sarà inserito nell'array
            Console.WriteLine("Quanti metri di lana ci sono in magazzino?");
            stoffe[5] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera dela lana che sarà inserito nell'array
            Console.WriteLine("Quanti metri di maglia ci sono in magazzino?");
            stoffe[6] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera della maglia che sarà inserito nell'array
            Console.WriteLine("Quante felpe ci sono in magazzino?");
            felpe = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera delle felpe presenti in magazzino
            Console.WriteLine("Quante tshirt ci sono in magazzino?");
            giubbotti = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei giubbotti presenti in magazzino
            Console.WriteLine("Quanti pantaloni ci sono in magazzino?");
            pantaloni = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei pantaloni presenti in magazzino
            Console.WriteLine("Quanti capi sono stati venduti?");
            capivenduti = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei capi venduti

            int a; //variabile utile per il for
            for (a = 0; a < 7; a++) 
            {
                SommaQuantitàStoffe = stoffe[a] + SommaQuantitàStoffe; //calcolo della quantità di stoffa presente in magazzino
            }

            if (SommaQuantitàStoffe > StoffeMaxMagazzino) //controllo se la quantità di stoffa presente in magazzino supera la capienza massima
            {
                Console.WriteLine("Ci sono troppi metri di stoffa; hai sbagliato a digitare i numeri?"); //se le stoffe in magazzzino sono troppe e superano la capienzamax chiedo all'utente se v
                string Risposta;
                Risposta = Convert.ToString(Console.ReadLine());
                if (Risposta == "Si")// se l'utente risponde si reinserisce le quantita di ogni stoffa
                {
                    SommaQuantitàStoffe = 0; //riazzero la somma della quantità delle stoffe
                    int b;//creo variabile b
                    for (b = 0; b<7; b++) //creo un for 
                    {
                        stoffe[b] = 0; //assegno il valore 0 ad ogni livello dell'array stoffe, per poter reinserire le quantità
                    }
                    Console.WriteLine("Reinserisci le quantità delle stoffe");
                    Console.WriteLine("Quanti metri di cotone ci sono in magazzino?");
                    stoffe[0] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera del cotone che sarà inserito nell'array
                    Console.WriteLine("Quanti metri di lino ci sono in magazzino?");
                    stoffe[1] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera del lino che sarà inserito nell'array
                    Console.WriteLine("Quanti metri di seta ci sono in magazzino?");
                    stoffe[2] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera deella seta che sarà inserito nell'array
                    Console.WriteLine("Quanti metri di pizzo ci sono in magazzino?");
                    stoffe[3] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera di pizzo che sarà inserito nell'array
                    Console.WriteLine("Quanti metri di velluto ci sono in magazzino?");
                    stoffe[4] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera del velluto che sarà inserito nell'array
                    Console.WriteLine("Quanti metri di lana ci sono in magazzino?");
                    stoffe[5] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera dela lana che sarà inserito nell'array
                    Console.WriteLine("Quanti metri di maglia ci sono in magazzino?");
                    stoffe[6] = Convert.ToDouble(Console.ReadLine()); //assunzione valore da tastiera della maglia che sarà inserito nell'array
                    int c; //variabile utile per il for
                    for (c = 0; c < 7; c++)
                    {
                        SommaQuantitàStoffe = stoffe[c] + SommaQuantitàStoffe; //calcolo della quantità di stoffa presente in magazzino
                    }
                }
                if (SommaQuantitàStoffe > StoffeMaxMagazzino) //se la quantità restasse ancora maggiore della capienza
                {
                    Console.WriteLine("I m di stoffa presenti in magazzino sono troppi"); //lo comunico all'utente 
                    Console.WriteLine("Se vuoi mandare dei capi in produzione digita 2, altrimenti schiaccia qualsiasi altro tasto per continuare");//e gli chiedo se vuole mandare dei capi in produzione in modod da diminuire la quantità di stoffa presente in magazzino
                    int TroppiCapiAccessoMenù2;
                    TroppiCapiAccessoMenù2 = Convert.ToInt32(Console.ReadLine());
                    if (TroppiCapiAccessoMenù2 == 2 & SommaQuantitàCapi < CapiMaxMagazzino) //vado al menù2
                    {
                        Menù2();
                    }
                    if (TroppiCapiAccessoMenù2 == 2 & SommaQuantitàCapi > CapiMaxMagazzino)
                    {
                        Console.WriteLine("attenzione!! In magazzino sono presenti troppi capi; reinserisci le quantità");
                        SommaQuantitàCapi = 0; // riazzera la quantità totale di capi
                        Console.WriteLine("Quante felpe ci sono in magazzino?");
                        felpe = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera delle felpe presenti in magazzino
                        Console.WriteLine("Quante tshirt ci sono in magazzino?");
                        giubbotti = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei giubbotti presenti in magazzino
                        Console.WriteLine("Quanti pantaloni ci sono in magazzino?");
                        pantaloni = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei pantaloni presenti in magazzino
                        SommaQuantitàCapi = felpe + giubbotti + pantaloni; //calcolo la quantità di capi in magazzino
                        if (SommaQuantitàCapi > CapiMaxMagazzino)//se la quantita di capi in magazzino restasse comq maggiore lo comunico all'utente e poi vado al menù 2
                        {
                            Console.WriteLine("In magazzino ci sono troppi capi devi venderne {0} per restare dentro la capienza massima", SommaQuantitàCapi - CapiMaxMagazzino);
                        }
                        Menù2();
                    }
                }
            }

            SommaQuantitàCapi = felpe + giubbotti + pantaloni; //calcolo la quantità di capi in magazzino
            if (SommaQuantitàCapi > CapiMaxMagazzino) //controllo se la quantità di capi presente in magazzino supera la capienza massima 
            {
                Console.WriteLine("La quantia di capi presenti in magazzino è troppo grande"); //se fosse così comunico all'utente che nel magazzino ci sono troppi capi
                Console.WriteLine("Vuoi reinserire le quantità di capi?");
                string risposta;
                risposta = Convert.ToString(Console.ReadLine());
                if (risposta == "Si")
                {
                    SommaQuantitàCapi = 0; // riazzera la quantità totale di capi
                    Console.WriteLine("Quante felpe ci sono in magazzino?");
                    felpe = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera delle felpe presenti in magazzino
                    Console.WriteLine("Quante tshirt ci sono in magazzino?");
                    giubbotti = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei giubbotti presenti in magazzino
                    Console.WriteLine("Quanti pantaloni ci sono in magazzino?");
                    pantaloni = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera dei pantaloni presenti in magazzino
                    SommaQuantitàCapi = felpe + giubbotti + pantaloni; //calcolo la quantità di capi in magazzino
                }
                if (SommaQuantitàCapi > CapiMaxMagazzino)
                {
                    Console.WriteLine("In magazzino ci sono troppi capi devi venderne {0} per restare dentro la capienza massima", SommaQuantitàCapi - CapiMaxMagazzino);
                }
                
            }
        }
        static void NavigazioneDichiarazioneMenù()
        {
            //comunico all'utente cosa c'è all'interno del menù
            Console.WriteLine("Menù");
            Console.WriteLine("Digita 1 se vuoi visualizzare la merce totale, in produzione e il magazzino occupato");
            Console.WriteLine("Digita 2 se vuoi sapere quanta stoffa occorre per fare un capo");
            Console.WriteLine("Digita 3 se vuoi sapere il prezzo dei capi che saranno venduti");
            Console.WriteLine("Digita 4 se vuoi visualizzare il profitto giornaliero");
            int NumeroMenù; //chiamo la variabile alla quale sarà assegnato il valore corrispondente al punto del menù che l'utente vuole mandare in esecuzione
            NumeroMenù = Convert.ToInt32(Console.ReadLine()); //assunzione valore da tastiera
            switch (NumeroMenù) 
            {
                case 1:     //nel caso in cui l'utente cliccasse 1 chiamo la funzione Menù1
                    Menù1();
                    break;
                case 2:     //nel caso in cui l'utente cliccasse 2 chiamo la funzione Menù2
                    Menù2();
                    break;
                case 3:     //nel caso in cui l'utente cliccasse 3 chiamo la funzione Menù3
                    Menù3();
                    break;
                case 4:     //nel caso in cui l'utente cliccasse 4 chiamo la funzione Menù4
                    Menù4();
                    break;
            }
        }
        static void Menù1()
        {   //Comunico all'utente la quantità di ogni stoffa presente in magazzino
            Console.WriteLine("In magazzino sono presenti:");
            Console.WriteLine("{0} metri di cotone;", stoffe[0]);
            Console.WriteLine("{0} metri di lino;", stoffe[1]);
            Console.WriteLine("{0} metri di seta;", stoffe[2]);
            Console.WriteLine("{0} metri di pizzo;", stoffe[3]);
            Console.WriteLine("{0} metri di velluto;", stoffe[4]);
            Console.WriteLine("{0} metri di lana;", stoffe[5]);
            Console.WriteLine("{0} metri di maglia;", stoffe[6]);

            if (SommaQuantitàStoffe > StoffeMaxMagazzino) //effettuo dei controlli sulla quantità di stoffa presente in magazzino
            {
                Console.WriteLine("I m di stoffa presenti in magazzino sono troppi, si deve mandare in produzione dei capi"); //se la quantità superasse la capienza massima lo comunico all'utente
            }
            else
            {
                //se la quantità rispetta la capienza massima comunico all'utente quanti altri metri di stoffa possono stare in magazzino               
                SpazioRestanteMagazzinoStoffe = StoffeMaxMagazzino - SommaQuantitàStoffe;
                Console.WriteLine("In magazzino ci sono {0} metri di stoffa", SommaQuantitàStoffe);
                Console.WriteLine("In magazzino si possono inserire ancora {0} metri di stoffa", SpazioRestanteMagazzinoStoffe);
            }

            if (SommaQuantitàCapi > CapiMaxMagazzino) //effettuo dei controlli sulla quantità di capi presente in magazzino
            {
                Console.WriteLine("La quantia di capi presenti in magazzino è troppo grande"); //se la quantità superasse la capienza massima lo comunico all'utente
            }
            else
            {   //se la quantità rispetta la capienza massima comunico all'utente quanti altri capi possono stare in magazzino
                SpazioRestanteMagazzinoCapi = CapiMaxMagazzino - SommaQuantitàCapi;
                Console.WriteLine("In magazzino ci sono {0} capi, di cui:", SommaQuantitàCapi);
                Console.WriteLine("{0} felpe", felpe);
                Console.WriteLine("{0} pantaloni", pantaloni);
                Console.WriteLine("{0} giubbotti", giubbotti);
                Console.WriteLine("In magazzino si possono insererire ancora {0} capi", SpazioRestanteMagazzinoCapi);
            }

            //chiedo all'utente se ci sono dei capi in produzione
            string Capiproduzione; //creo la stringa a cui verrà assegnata la risposta
            Console.WriteLine("Ci sono dei capi in produzione? (rispondere sempre con le lettere iniziali maiuscole)");
            Capiproduzione = Convert.ToString(Console.ReadLine()); //viene acquisita la risposta da tastiera
            if (Capiproduzione == "Si")
            {   //se la risposta sarà Si allora chiedo all'utente quanti capi sono in produzione
                int numero;
                Console.WriteLine("quanti capi sono in produzione?");
                numero = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("se vorrai uscire dal programma digita *, altrimenti digita un'altro numero del menù"); //chiedo all'utente se vuole proseguire a navigare il menù o se vuole chiudere il programma
            string jolly; //creo la stringa a cui verrà assegnata la risposta
            jolly = Convert.ToString(Console.ReadLine());
            if (jolly == "*") // se l'utente inserirà *
            {
                SalvataggioSuFile();
                System.Environment.Exit(1); //allora il programma verrà chiuso

            }
            else 
            {   //altrimenti potrà continuare a trascorrere il menù
                switch (jolly)
                {
                    case "2":
                        Menù2();
                        break;
                    case "3":
                        Menù3();
                        break;
                    case "4":
                        Menù4();
                        break;

                }
            }
        }

        static void Menù2()
        {
            string Capiproduzione;//stringa che userò per memorizzare la risposta della domanda "Vuoi produrre dei capi?"
            Console.WriteLine("Rispondere alle seguenti domande con le iniziali delle risposte sempre maiuscole, altrimenti il programma non andrà");
            Console.WriteLine("Vuoi produrre dei capi?");
            Capiproduzione = Convert.ToString(Console.ReadLine());//ricevo la risposta da tastiera
            if (Capiproduzione == "Si") //se la risposta sarà si allora faccio i calcoli e l'esecuzione della produzione
            {
                int numero; // variabile corrispondente al numero dei capi
                Console.WriteLine("Quanti capi vuoi produrre?");
                numero = Convert.ToInt32(Console.ReadLine());// ricevo il valore scritto da tastiera
                string tipo; //creo una stringa per sapere quale capo si vuole produrre
                Console.WriteLine("Che tipo di capo è? (Felpa, Pantaloni, Giubbotti)");
                tipo = Convert.ToString(Console.ReadLine());//ricevo la risposta

                if (tipo == "Felpa") //creo 3 (felpa, pantaloni e giubbotti) if dentro ognuno dei quali svolgo i calcoli per le stoffe e le taglie
                {
                    string tagliafelpe;//creo una stringa corrispondente alla taglia
                    Console.WriteLine("di che taglia? (scrivi la taglia in maiuscolo; le taglie sono: S, M; L; XL)");
                    tagliafelpe = Convert.ToString(Console.ReadLine());
                    if (tagliafelpe == "S") //creo 4 if per ogni tipo di taglia dentro ai quali...
                    {
                        double StoffaNeccessariaFelpe;
                        StoffaNeccessariaFelpe = numero * 2; //calcolo la stoffa neccessaria per produrre il capo
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaFelpe);//Comunico all'utente quanta stoffa serve
                        string StoffaFelpe;//creo la stringa a cui verrà assegnata la stoffa con cui sarà composto l'abito
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (Cotone, Lino, Seta, Pizzo, Velluto, Lana, Maglia)");// Chiedo all'utente di che stoffa dovrà essere prodotto il capo
                        StoffaFelpe = Convert.ToString(Console.ReadLine());
                        switch (StoffaFelpe)
                        {
                            case "Cotone": //nel caso in cui rispondesse cotone
                                string Raffinatezza;
                                if (StoffaNeccessariaFelpe <= stoffe[0])//controllo che ci sia abbastanza stoffa per produrre l'abito
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base") //creo 3 if corrispondenti alle varie raffinatezze (base, media alta)
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 2) + 3 + 1; //calcolo il Prezzodiproduzione
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;//calcolo il prezzo di vendità
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaFelpe;//tolgo alla quantità di cotone la quantità di stoffa usata.
                                }
                                else //se non ci fosse abbastanza stoffa lo comunico all'utente e dico quanta ne manca e quanta da ordinare.
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaFelpe - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaFelpe <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaFelpe <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaFelpe <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaFelpe <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaFelpe <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaFelpe <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliafelpe == "M")
                    {
                        double StoffaNeccessariaFelpe;
                        StoffaNeccessariaFelpe = numero * 2.20;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaFelpe);
                        string StoffaFelpe;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaFelpe = Convert.ToString(Console.ReadLine());
                        switch (StoffaFelpe)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaFelpe <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaFelpe - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaFelpe <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaFelpe <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaFelpe <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaFelpe <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaFelpe <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaFelpe <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 2.20) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliafelpe == "L")
                    {
                        double StoffaNeccessariaFelpe;
                        StoffaNeccessariaFelpe = numero * 2.50;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaFelpe);
                        string StoffaFelpe;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaFelpe = Convert.ToString(Console.ReadLine());
                        switch (StoffaFelpe)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaFelpe <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaFelpe - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaFelpe <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaFelpe <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaFelpe <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaFelpe <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaFelpe <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaFelpe <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 2.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliafelpe == "XL")
                    {
                        double StoffaNeccessariaFelpe;
                        StoffaNeccessariaFelpe = numero * 2.70;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaFelpe);
                        string StoffaFelpe;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaFelpe = Convert.ToString(Console.ReadLine());
                        switch (StoffaFelpe)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaFelpe <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaFelpe - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaFelpe <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaFelpe <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaFelpe <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaFelpe <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaFelpe <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 2.7) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaFelpe <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 2.70) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaFelpe;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaFelpe - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaFelpe - stoffe[6]);
                                }
                                break;
                        }

                    }
                }

                if (tipo == "Pantaloni")
                {
                    string tagliaPantaloni;
                    Console.WriteLine("di che taglia? (scrivi la taglia in maiuscolo; le taglie sono: S, M; L; XL)");
                    tagliaPantaloni = Convert.ToString(Console.ReadLine());
                    if (tagliaPantaloni == "S")
                    {
                        double StoffaNeccessariaPantaloni;
                        StoffaNeccessariaPantaloni = numero * 1.20;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaPantaloni);
                        string StoffaPantaloni;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaPantaloni = Convert.ToString(Console.ReadLine());
                        switch (StoffaPantaloni)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaPantaloni <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaPantaloni - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaPantaloni <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaPantaloni <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre tutti i pantaloni e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaPantaloni <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantalonie' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaPantaloni <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantalonie' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaPantaloni <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaPantaloni <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantalonie e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 1.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliaPantaloni == "M")
                    {
                        double StoffaNeccessariaPantaloni;
                        StoffaNeccessariaPantaloni = numero * 1.5;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaPantaloni);
                        string StoffaPantaloni;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaPantaloni = Convert.ToString(Console.ReadLine());
                        switch (StoffaPantaloni)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaPantaloni <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 1.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaPantaloni - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaPantaloni <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaPantaloni <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 1.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaPantaloni <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 1.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaPantaloni <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaPantaloni <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaPantaloni <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 1.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 1.50) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliaPantaloni == "L")
                    {
                        double StoffaNeccessariaPantaloni;
                        StoffaNeccessariaPantaloni = numero * 1.60;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaPantaloni);
                        string StoffaPantaloni;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaPantaloni = Convert.ToString(Console.ReadLine());
                        switch (StoffaPantaloni)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaPantaloni <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaPantaloni - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaPantaloni <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantalonie' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaPantaloni <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 1.60) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaPantaloni <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 1.60) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 1.60) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaPantaloni <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaPantaloni <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaPantaloni <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 1.6) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliaPantaloni == "XL")
                    {
                        double StoffaNeccessariaPantaloni;
                        StoffaNeccessariaPantaloni = numero * 1.8;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaPantaloni);
                        string StoffaPantaloni;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaPantaloni = Convert.ToString(Console.ReadLine());
                        switch (StoffaPantaloni)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaPantaloni <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaPantaloni - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaPantaloni <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaPantaloni <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaPantaloni <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaPantaloni <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaPantaloni <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 1.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaPantaloni <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 1.80) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita  di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 1.80) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 1.80) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un pantalone e' di {0} euro; mentre di tutti i pantaloni e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un pantalone e' di {0} euro, mentre di tutti i pantaloni e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaPantaloni;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaPantaloni - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaPantaloni - stoffe[6]);
                                }
                                break;
                        }

                    }
                }
                if (tipo == "Giubbotti")
                {
                    string tagliaGiubbotti;
                    Console.WriteLine("di che taglia? (scrivi la taglia in maiuscolo; le taglie sono: S, M; L; XL)");
                    tagliaGiubbotti = Convert.ToString(Console.ReadLine());
                    if (tagliaGiubbotti == "S")
                    {
                        double StoffaNeccessariaGiubbotti;
                        StoffaNeccessariaGiubbotti = numero * 2.5;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaGiubbotti);
                        string StoffaGiubbotti;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaGiubbotti = Convert.ToString(Console.ReadLine());
                        switch (StoffaGiubbotti)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaGiubbotti <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaGiubbotti - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaGiubbotti <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaGiubbotti <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaGiubbotti <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaGiubbotti <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaGiubbotti <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaGiubbotti <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 2.5) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di una felpa e' di {0} euro; mentre di tutte le felpe e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di una felpa e' di {0} euro, mentre di tutte le felpe e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[6]);
                                }
                                break;
                        }

                    }

                    if (tagliaGiubbotti == "M")
                    {
                        double StoffaNeccessariaGiubbotti;
                        StoffaNeccessariaGiubbotti = numero * 2.8;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaGiubbotti);
                        string StoffaGiubbotti;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaGiubbotti = Convert.ToString(Console.ReadLine());
                        switch (StoffaGiubbotti)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaGiubbotti <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaGiubbotti - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaGiubbotti <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaGiubbotti <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaGiubbotti <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  tutti i giubbotti e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaGiubbotti <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaGiubbotti <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaGiubbotti <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 2.8) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[6]);
                                }
                                break;
                        }

                    }
                    if (tagliaGiubbotti == "L")
                    {
                        double StoffaNeccessariaGiubbotti;
                        StoffaNeccessariaGiubbotti = numero * 3;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaGiubbotti);
                        string StoffaGiubbotti;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaGiubbotti = Convert.ToString(Console.ReadLine());
                        switch (StoffaGiubbotti)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaGiubbotti <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaGiubbotti - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaGiubbotti <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaGiubbotti <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaGiubbotti <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  tutti i giubbotti e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaGiubbotti <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaGiubbotti <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaGiubbotti <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }

                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 3) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[6]);
                                }
                                break;
                        }

                    }
                    if (tagliaGiubbotti == "XL")
                    {
                        double StoffaNeccessariaGiubbotti;
                        StoffaNeccessariaGiubbotti = numero * 3.2;
                        Console.WriteLine("occorrono {0} metri di stoffa", StoffaNeccessariaGiubbotti);
                        string StoffaGiubbotti;
                        Console.WriteLine("Di che stoffa dovrà essere prodotto il capo? (scrivere il nome del tessuto con la lettera iniziale maiuscola)");
                        StoffaGiubbotti = Convert.ToString(Console.ReadLine());
                        switch (StoffaGiubbotti)
                        {
                            case "Cotone":
                                string Raffinatezza;
                                if (StoffaNeccessariaGiubbotti <= stoffe[0])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneCotoneBase;
                                        PrezzoProduzioneCotoneBase = (2.5 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneBase, PrezzoProduzioneCotoneBase * numero);
                                        double PrezzoVenditaCotoneBase;
                                        PrezzoVenditaCotoneBase = PrezzoProduzioneCotoneBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneBase * 7, PrezzoVenditaCotoneBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneCotoneMedia;
                                        PrezzoProduzioneCotoneMedia = (5 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneMedia, PrezzoProduzioneCotoneMedia * numero);
                                        double PrezzoVenditaCotoneMedia;
                                        PrezzoVenditaCotoneMedia = PrezzoProduzioneCotoneMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneMedia * 7, PrezzoVenditaCotoneMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneCotoneAlta;
                                        PrezzoProduzioneCotoneAlta = (7 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneCotoneAlta, PrezzoProduzioneCotoneAlta * numero);
                                        double PrezzoVenditaCotoneAlta;
                                        PrezzoVenditaCotoneAlta = PrezzoProduzioneCotoneAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneCotoneAlta * 7, PrezzoVenditaCotoneAlta);
                                    }
                                    stoffe[0] = stoffe[0] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di cotone", StoffaNeccessariaGiubbotti - stoffe[0]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[0]);
                                }
                                break;

                            case "Lino":
                                if (StoffaNeccessariaGiubbotti <= stoffe[1])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLinoBase;
                                        PrezzoProduzioneLinoBase = (3 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoBase, PrezzoProduzioneLinoBase * numero);
                                        double PrezzoVenditaLinoBase;
                                        PrezzoVenditaLinoBase = PrezzoProduzioneLinoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoBase * 7, PrezzoVenditaLinoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneLinoMedia;
                                        PrezzoProduzioneLinoMedia = (6 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoMedia, PrezzoProduzioneLinoMedia * numero);
                                        double PrezzoVenditaLinoMedia;
                                        PrezzoVenditaLinoMedia = PrezzoProduzioneLinoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoMedia * 7, PrezzoVenditaLinoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLinoAlta;
                                        PrezzoProduzioneLinoAlta = (10 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLinoAlta, PrezzoProduzioneLinoAlta * numero);
                                        double PrezzoVenditaLinoAlta;
                                        PrezzoVenditaLinoAlta = PrezzoProduzioneLinoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLinoAlta * 7, PrezzoVenditaLinoAlta);
                                    }
                                    stoffe[1] = stoffe[1] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[1]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[1]);
                                }
                                break;

                            case "Seta":
                                if (StoffaNeccessariaGiubbotti <= stoffe[2])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneSetaBase;
                                        PrezzoProduzioneSetaBase = (11 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneSetaBase, PrezzoProduzioneSetaBase * numero);
                                        double PrezzoVenditaSetaBase;
                                        PrezzoVenditaSetaBase = PrezzoProduzioneSetaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneSetaBase * 7, PrezzoVenditaSetaBase);
                                    }

                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneSetaAlta;
                                        PrezzoProduzioneSetaAlta = (22 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneSetaAlta, PrezzoProduzioneSetaAlta * numero);
                                        double PrezzoVenditaSetaAlta;
                                        PrezzoVenditaSetaAlta = PrezzoProduzioneSetaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneSetaAlta * 7, PrezzoVenditaSetaAlta);
                                    }
                                    stoffe[2] = stoffe[2] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[2]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[2]);
                                }
                                break;

                            case "Pizzo":
                                if (StoffaNeccessariaGiubbotti <= stoffe[3])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzionePizzoBase;
                                        PrezzoProduzionePizzoBase = (1.5 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoBase, PrezzoProduzionePizzoBase * numero);
                                        double PrezzoVenditaPizzoBase;
                                        PrezzoVenditaPizzoBase = PrezzoProduzionePizzoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  tutti i giubbotti e' di {1}", PrezzoProduzionePizzoBase * 7, PrezzoVenditaPizzoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzionePizzoMedia;
                                        PrezzoProduzionePizzoMedia = (4 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoMedia, PrezzoProduzionePizzoMedia * numero);
                                        double PrezzoVenditaPizzoMedia;
                                        PrezzoVenditaPizzoMedia = PrezzoProduzionePizzoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzionePizzoMedia * 7, PrezzoVenditaPizzoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzionePizzoAlta;
                                        PrezzoProduzionePizzoAlta = (5.5 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzionePizzoAlta, PrezzoProduzionePizzoAlta * numero);
                                        double PrezzoVenditaPizzoAlta;
                                        PrezzoVenditaPizzoAlta = PrezzoProduzionePizzoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzionePizzoAlta * 7, PrezzoVenditaPizzoAlta);
                                    }
                                    stoffe[3] = stoffe[3] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[3]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[3]);
                                }
                                break;

                            case "Velluto":
                                if (StoffaNeccessariaGiubbotti <= stoffe[4])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneVellutoBase;
                                        PrezzoProduzioneVellutoBase = (4 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoBase, PrezzoProduzioneVellutoBase * numero);
                                        double PrezzoVenditaVellutoBase;
                                        PrezzoVenditaVellutoBase = PrezzoProduzioneVellutoBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoBase * 7, PrezzoVenditaVellutoBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneVellutoMedia;
                                        PrezzoProduzioneVellutoMedia = (8 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoMedia, PrezzoProduzioneVellutoMedia * numero);
                                        double PrezzoVenditaVellutoMedia;
                                        PrezzoVenditaVellutoMedia = PrezzoProduzioneVellutoMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di  tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoMedia * 7, PrezzoVenditaVellutoMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneVellutoAlta;
                                        PrezzoProduzioneVellutoAlta = (13 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneVellutoAlta, PrezzoProduzioneVellutoAlta * numero);
                                        double PrezzoVenditaVellutoAlta;
                                        PrezzoVenditaVellutoAlta = PrezzoProduzioneVellutoAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneVellutoAlta * 7, PrezzoVenditaVellutoAlta);
                                    }
                                    stoffe[4] = stoffe[4] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[4]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[4]);
                                }
                                break;

                            case "Lana":
                                if (StoffaNeccessariaGiubbotti <= stoffe[5])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneLanaBase;
                                        PrezzoProduzioneLanaBase = (3 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLanaBase, PrezzoProduzioneLanaBase * numero);
                                        double PrezzoVenditaLanaBase;
                                        PrezzoVenditaLanaBase = PrezzoProduzioneLanaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLanaBase * 7, PrezzoVenditaLanaBase);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneLanaAlta;
                                        PrezzoProduzioneLanaAlta = (7 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneLanaAlta, PrezzoProduzioneLanaAlta * numero);
                                        double PrezzoVenditaLanaAlta;
                                        PrezzoVenditaLanaAlta = PrezzoProduzioneLanaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneLanaAlta * 7, PrezzoVenditaLanaAlta);
                                    }
                                    stoffe[5] = stoffe[5] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[5]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[5]);
                                }
                                break;

                            case "Maglia":
                                if (StoffaNeccessariaGiubbotti <= stoffe[6])
                                {
                                    Console.WriteLine("Di che raffinatezza? (Base, Media, Alta)");
                                    Raffinatezza = Convert.ToString(Console.ReadLine());
                                    if (Raffinatezza == "Base")
                                    {
                                        double PrezzoProduzioneMagliaBase;
                                        PrezzoProduzioneMagliaBase = (3.5 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaBase, PrezzoProduzioneMagliaBase * numero);
                                        double PrezzoVenditaMagliaBase;
                                        PrezzoVenditaMagliaBase = PrezzoProduzioneMagliaBase * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaBase * 7, PrezzoVenditaMagliaBase);
                                    }
                                    if (Raffinatezza == "Media")
                                    {
                                        double PrezzoProduzioneMagliaMedia;
                                        PrezzoProduzioneMagliaMedia = (7 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaMedia, PrezzoProduzioneMagliaMedia * numero);
                                        double PrezzoVenditaMagliaMedia;
                                        PrezzoVenditaMagliaMedia = PrezzoProduzioneMagliaMedia * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaMedia * 7, PrezzoVenditaMagliaMedia);
                                    }
                                    if (Raffinatezza == "Alta")
                                    {
                                        double PrezzoProduzioneMagliaAlta;
                                        PrezzoProduzioneMagliaAlta = (10 * 3.2) + 3 + 1;
                                        Console.WriteLine("Il prezzo di produzione di un giubbotto e' di {0} euro; mentre di tutti i giubbotti e' di {1} euro", PrezzoProduzioneMagliaAlta, PrezzoProduzioneMagliaAlta * numero);
                                        double PrezzoVenditaMagliaAlta;
                                        PrezzoVenditaMagliaAlta = PrezzoProduzioneMagliaAlta * 7 * numero;
                                        Console.WriteLine("Il prezzo di vendita di un giubbotto e' di {0} euro, mentre di tutti i giubbotti e' di {1}", PrezzoProduzioneMagliaAlta * 7, PrezzoVenditaMagliaAlta);
                                    }
                                    stoffe[6] = stoffe[6] - StoffaNeccessariaGiubbotti;
                                }
                                else
                                {
                                    Console.WriteLine("Non c'è abbastanza stoffa: ti mancano {0} metri di lino", StoffaNeccessariaGiubbotti - stoffe[6]);
                                    Console.WriteLine("Ordina {0} metri di cotone.", StoffaNeccessariaGiubbotti - stoffe[6]);
                                }
                                break;
                        }

                    }
                    Console.ReadKey();
                }
            }
            Console.WriteLine("se vorrai uscire dal programma digita *, altrimenti digita un'altro numero del menù");
            string jolly;
            jolly = Convert.ToString(Console.ReadLine());
            if (jolly == "*")
            {
                SalvataggioSuFile();
                System.Environment.Exit(1);

            }
            else
            {
                switch (jolly)
                {
                    case "1":
                        Menù1();
                        break;
                    case "3":
                        Menù3();
                        break;
                    case "4":
                        Menù4();
                        break;

                }
            }
        }

        static void Menù3()
        {
            //{ cotone, lino, seta, pizzo, velluto, lana, maglia }
            Console.WriteLine("\nChe tipo di capo vuoi vendere?\n1 -> Felpa \n2 -> Giubbotto\n3 -> Pantaloni");
            string capo = Convert.ToString(Console.ReadLine());
            while (capo != "1" && capo != "2" && capo != "3")
            {
                Console.WriteLine("\nIl numero inserito non è valido; reinserire il numero.");
                capo = Convert.ToString(Console.ReadLine());
            }

            Console.WriteLine("\nDi che taglia è il capo vuoi vendere?\n1 -> S \n2 -> M\n3 -> L\n4 -> XL");
            string taglia = Convert.ToString(Console.ReadLine());
            while (taglia != "1" && taglia != "2" && taglia != "3" && taglia != "4")
            {
                Console.WriteLine("\nIl numero inserito non è valido; reinserire il numero.");
                taglia = Convert.ToString(Console.ReadLine());
            }

            Console.WriteLine("\nDi che materiale è il capo vuoi vendere?\n1 -> Cotone \n2 -> Lino\n3 -> Seta\n4 -> Pizzo\n5 -> Velluto\n6 -> Lana\n7 -> Maglia");
            string materiale = Convert.ToString(Console.ReadLine());
            while (materiale != "1" && materiale != "2" && materiale != "3" && materiale != "4" && materiale != "5" && materiale != "6" && materiale != "7")
            {
                Console.WriteLine("\nIl numero inserito non è valido; reinserire il numero.");
                materiale = Convert.ToString(Console.ReadLine());
            }

            string raffinatezza = " ";
            if(materiale == "3" || materiale == "6")
            {
                Console.WriteLine("\nDi che raffinatezza è il capo vuoi vendere?\n1 -> Base \n2 -> Alta");
                raffinatezza = Convert.ToString(Console.ReadLine());
                while (raffinatezza != "1" && raffinatezza != "2")
                {
                    Console.WriteLine("\nIl numero inserito non è valido; reinserire il numero.");
                    raffinatezza = Convert.ToString(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("\nDi che raffinatezza è il capo vuoi vendere?\n1 -> Base \n2 -> Media \n3 -> Alta");
                raffinatezza = Convert.ToString(Console.ReadLine());
                while (raffinatezza != "1" && raffinatezza != "2" && raffinatezza != "3")
                {
                    Console.WriteLine("\nIl numero inserito non è valido; reinserire il numero.");
                    raffinatezza = Convert.ToString(Console.ReadLine());
                }
            }

            double colore = 1;
            double manodop = 3;
            double prezzo = 0;
            double tesspertagl = 0;
            double prezzraff = 0;

            switch (capo)
            {
                case "1":
                    switch (taglia)
                    {
                        case "1":
                            tesspertagl = 2;
                            break;
                        case "2":
                            tesspertagl = 2.2;
                            break;
                        case "3":
                            tesspertagl = 2.5;
                            break;
                        case "4":
                            tesspertagl = 2.7;
                            break;
                    }
                    break;
                case "2":
                    switch (taglia)
                    {
                        case "1":
                            tesspertagl = 2.5;
                            break;
                        case "2":
                            tesspertagl = 2.8;
                            break;
                        case "3":
                            tesspertagl = 3;
                            break;
                        case "4":
                            tesspertagl = 3.2;
                            break;
                    }
                    break;
                case "3":
                    switch (taglia)
                    {
                        case "1":
                            tesspertagl = 1.2;
                            break;
                        case "2":
                            tesspertagl = 1.5;
                            break;
                        case "3":
                            tesspertagl = 1.6;
                            break;
                        case "4":
                            tesspertagl = 1.8;
                            break;
                    }
                    break;

            }

            switch (materiale)
            {
                case "1":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 2.5;
                            break;
                        case "2":
                            prezzraff = 5;
                            break;
                        case "3":
                            prezzraff = 7;
                            break;
                    }
                    break;
                case "2":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 3;
                            break;
                        case "2":
                            prezzraff = 6;
                            break;
                        case "3":
                            prezzraff = 10;
                            break;
                    }
                    break;
                case "3":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 11;
                            break;
                        case "2":
                            prezzraff = 22;
                            break;
                    }
                    break;
                case "4":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 1.5;
                            break;
                        case "2":
                            prezzraff = 4;
                            break;
                        case "3":
                            prezzraff = 5.5;
                            break;

                    }
                    break;
                case "5":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 4;
                            break;
                        case "2":
                            prezzraff = 8;
                            break;
                        case "3":
                            prezzraff = 13;
                            break;
                    }
                    break;
                case "6":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 3;
                            break;
                        case "2":
                            prezzraff = 7;
                            break;
                    }
                    break;
                case "7":
                    switch (raffinatezza)
                    {
                        case "1":
                            prezzraff = 3.5;
                            break;
                        case "2":
                            prezzraff = 7;
                            break;
                        case "3":
                            prezzraff = 10;
                            break;
                    }
                    break;
            }

            prezzo = manodop + colore + (tesspertagl*prezzraff);
            Console.WriteLine(prezzo);


            Console.WriteLine("se vorrai uscire dal programma digita *, altrimenti digita un'altro numero del menù");
            string jolly;
            jolly = Convert.ToString(Console.ReadLine());
            if (jolly == "*")
            {
                SalvataggioSuFile();
                System.Environment.Exit(1);

            }
            else
            {
                switch (jolly)
                {
                    case "1":
                        Menù1();
                        break;
                    case "2":
                        Menù2();
                        break;
                    case "4":
                        Menù4();
                        break;

                }
            }
        }

        static void Menù4()
        {
            
            Console.WriteLine("se vorrai uscire dal programma digita *, altrimenti digita un'altro numero del menù");
            string jolly;
            jolly = Convert.ToString(Console.ReadLine());
            if (jolly == "*")
            {
                SalvataggioSuFile();
                System.Environment.Exit(1);

            }
            else
            {
                switch (jolly)
                {
                    case "1":
                        Menù1();
                        break;
                    case "2":
                        Menù2();
                        break;
                    case "3":
                        Menù3();
                        break;

                }
            }
        }

        static void SalvataggioSuFile()
        {
            string filename = @"FileSalvataggio.txt";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + filename;
            StreamWriter streamwriter = new StreamWriter(filePath, true);//creo file e metto true in modo che non sovrascriva le stringhe nel file.
            streamwriter.WriteLine(data);//scrivo la data
            streamwriter.WriteLine("\nIn magazzino sono presenti:");
            streamwriter.WriteLine("{0} metri di cotone;", stoffe[0]);
            streamwriter.WriteLine("{0} metri di lino;", stoffe[1]);
            streamwriter.WriteLine("{0} metri di seta;", stoffe[2]);
            streamwriter.WriteLine("{0} metri di pizzo;", stoffe[3]);
            streamwriter.WriteLine("{0} metri di velluto;", stoffe[4]);
            streamwriter.WriteLine("{0} metri di lana;", stoffe[5]);
            streamwriter.WriteLine("{0} metri di maglia;", stoffe[6]);
            streamwriter.WriteLine("In magazzino ci sono {0} metri di stoffa e ci possono ancora stare {1} metri", SommaQuantitàStoffe, SpazioRestanteMagazzinoStoffe);
            streamwriter.WriteLine("In magazzino ci sono {0} capi, di cui:", SommaQuantitàCapi);
            streamwriter.WriteLine("{0} felpe", felpe);
            streamwriter.WriteLine("{0} pantaloni", pantaloni);
            streamwriter.WriteLine("{0} giubbotti", giubbotti);
            streamwriter.WriteLine("In magazzino ci possono ancora stare {0} capi", SpazioRestanteMagazzinoCapi);
            streamwriter.Close();
        }
    }
}

