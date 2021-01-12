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
                Console.WriteLine("I m di stoffa presenti in magazzino sono troppi"); //se fosse così comunico all'utente che in magazzino ci sono troppi vestiti
            }

            SommaQuantitàCapi = felpe + giubbotti + pantaloni; //calcolo la quantità di capi in magazzino
            if (SommaQuantitàCapi > CapiMaxMagazzino) //controllo se la quantità di capi presente in magazzino supera la capienza massima 
            {
                Console.WriteLine("La quantia di capi presenti in magazzino è troppo grande"); //se fosse così comunico all'utente che nel magazzino ci sono troppi capi
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
                Console.WriteLine("In magazzino ci sono {0} capi", SommaQuantitàCapi);
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
            string FileSalvataggio = @"C:\Users\Michele Gabrieli\OneDrive\Documenti\GitHub\progetto-informatica-1\FileSalvataggio";//dove salvo il file
            StreamWriter streamwriter = new StreamWriter(FileSalvataggio, true);//creo file e metto true in modo che non sovrascriva le stringhe nel file.
            streamwriter.WriteLine(data);//scrivo la data
            streamwriter.WriteLine("In magazzino sono presenti:");
            streamwriter.WriteLine("{0} metri di cotone;", stoffe[0]);
            streamwriter.WriteLine("{0} metri di lino;", stoffe[1]);
            streamwriter.WriteLine("{0} metri di seta;", stoffe[2]);
            streamwriter.WriteLine("{0} metri di pizzo;", stoffe[3]);
            streamwriter.WriteLine("{0} metri di velluto;", stoffe[4]);
            streamwriter.WriteLine("{0} metri di lana;", stoffe[5]);
            streamwriter.WriteLine("{0} metri di maglia;", stoffe[6]);
            streamwriter.WriteLine("In magazzino ci sono {0} metri di stoffa e ci possono ancora stare {1} metri", SommaQuantitàStoffe, SpazioRestanteMagazzinoStoffe);
            streamwriter.WriteLine("In magazzino ci sono {0} abiti e si possono ancora inserire {1} capi", SommaQuantitàCapi, SpazioRestanteMagazzinoCapi);
            streamwriter.Close();
        }
    }
}

