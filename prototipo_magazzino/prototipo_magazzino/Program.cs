using System;

namespace prototipo_magazzino
{
    class Program
    {
        //private static double cotone, lino, seta, pizzo, velluto, lana, maglia; //variabili a cui assegniamo i livelli dell'array
        static double[] stoffe = new double[7];  //{ cotone, lino, seta, pizzo, velluto, lana, maglia }  dichiarazione array globale tessuti

        static string[] taglie = new string[4] { "S", "M", "L", "XL" };

        private static int felpe, giubbotti, pantaloni;

        private static int capivenduti;

        private static int StoffeMaxMagazzino = 300, CapiMaxMagazzino = 200, SommaQuantitàCapi = 0;;
        private static double SommaQuantitàStoffe = 0;
        static void Main(string[] args)
        {

            DomandeEssenziali();
            NavigazioneDichiarazioneMenù();


            Console.ReadLine();
        }

        static void DomandeEssenziali()
        {
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
            felpe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quante tshirt ci sono in magazzino?");
            giubbotti = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quanti pantaloni ci sono in magazzino?");
            pantaloni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quanti capi sono stati venduti?");
            capivenduti = Convert.ToInt32(Console.ReadLine());

            int a;
            for (a = 0; a < 7; a++)
            {
                SommaQuantitàStoffe = stoffe[a] + SommaQuantitàStoffe;
            }

            if (SommaQuantitàStoffe > StoffeMaxMagazzino)
            {
                Console.WriteLine("I m di stoffa presenti in magazzino sono troppi");
            }

            SommaQuantitàCapi = felpe + giubbotti + pantaloni;
            if (SommaQuantitàCapi > CapiMaxMagazzino)
            {
                Console.WriteLine("La quantia di capi presenti in magazzino è troppo grande");
            }
        }
        static void NavigazioneDichiarazioneMenù()
        {
            Console.WriteLine("Menù");
            Console.WriteLine("Digita 1 se vuoi visualizzare la merce totale, in produzione e il magazzino occupato");
            Console.WriteLine("Digita 2 se vuoi sapere quanta stoffa occorre per fare un capo");
            Console.WriteLine("Digita 3 se vuoi sapere il prezzo dei capi che saranno venduti");
            Console.WriteLine("Digita 4 se vuoi visualizzare il profitto giornaliero");
            int NumeroMenù;
            NumeroMenù = Convert.ToInt32(Console.ReadLine());
            switch (NumeroMenù)
            {
                case 1:
                    Menù1();
                    break;
                case 2:
                    Menù2();
                    break;
                case 3:
                    Menù3();
                    break;
                case 4:
                    Menù4();
                    break;
            }
        }
        static void Menù1()
        {
            Console.WriteLine("In magazzino sono presenti:");
            Console.WriteLine("{0} metri di cotone;", stoffe[0]);
            Console.WriteLine("{0} metri di lino;", stoffe[1]);
            Console.WriteLine("{0} metri di seta;", stoffe[2]);
            Console.WriteLine("{0} metri di pizzo;", stoffe[3]);
            Console.WriteLine("{0} metri di velluto;", stoffe[4]);
            Console.WriteLine("{0} metri di lana;", stoffe[5]);
            Console.WriteLine("{0} metri di maglia;", stoffe[6]);

            if (SommaQuantitàStoffe > StoffeMaxMagazzino)
            {
                Console.WriteLine("I m di stoffa presenti in magazzino sono troppi, si deve mandare in produzione dei capi");
            }
            else
            {
                double SpazioRestanteMagazzinoStoffe;
                SpazioRestanteMagazzinoStoffe = StoffeMaxMagazzino - SommaQuantitàStoffe;
                Console.WriteLine("In magazzino ci sono {0} metri di stoffa", SommaQuantitàStoffe);
                Console.WriteLine("In magazzino si possono inserire ancora {0} metri di stoffa", SpazioRestanteMagazzinoStoffe);
            }

            SommaQuantitàCapi = felpe + giubbotti + pantaloni;
            if (SommaQuantitàCapi > CapiMaxMagazzino)
            {
                Console.WriteLine("La quantia di capi presenti in magazzino è troppo grande");
            }
            else
            {
                int SpazioRestanteMagazzinoCapi;
                SpazioRestanteMagazzinoCapi = CapiMaxMagazzino - SommaQuantitàCapi;
                Console.WriteLine("In magazzino ci sono {0} capi", SommaQuantitàCapi);
                Console.WriteLine("In magazzino si possono insererire ancora {0} capi", SpazioRestanteMagazzinoCapi);
            }

            string Capiproduzione;
            Console.WriteLine("Ci sono dei capi in produzione?");
            Capiproduzione = Convert.ToString(Console.ReadLine());
            if (Capiproduzione == "si")
            {
                int numero;
                Console.WriteLine("quanti capi sono in produzione?");
                numero = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("se vorrai uscire dal programma digita *, altrimenti digita un'altro numero del menù");
            string jolly;
            jolly = Convert.ToString(Console.ReadLine());
            if (jolly == "*")
            {
                System.Environment.Exit(1);

            }
            else
            {
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
    }
}

