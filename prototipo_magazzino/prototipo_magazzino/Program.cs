using System;

namespace prototipo_magazzino
{
    class Program
    {
        private static double cotone, lino, seta, pizzo, velluto, lana, maglia; //variabili a cui assegniamo i livelli dell'array
        static double[] stoffe = new double[7] { cotone, lino, seta, pizzo, velluto, lana, maglia }; //dichiarazione array globale tessuti

        private static int felpe, giubbotti, pantaloni;

        private static int capivenduti;

        private static int StoffeMaxMagazzino = 300, CapiMaxMagazzino = 200;
        static void Main(string[] args)
        {
            DomandeEssenziali();
            NavigazioneDichiarazioneMenù();

            Console.ReadLine();
        }

        static void DomandeEssenziali()
        {
            Console.WriteLine("Quanti metri di cotone ci sono in magazzino?");
            cotone = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quanti metri di lino ci sono in magazzino?");
            lino = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quanti metri di seta ci sono in magazzino?");
            seta = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quanti metri di pizzo ci sono in magazzino?");
            pizzo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quanti metri di velluto ci sono in magazzino?");
            velluto = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quanti metri di lana ci sono in magazzino?");
            lana = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quanti metri di maglia ci sono in magazzino?");
            maglia = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quante felpe ci sono in magazzino?");
            felpe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quante tshirt ci sono in magazzino?");
            giubbotti = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quanti pantaloni ci sono in magazzino?");
            pantaloni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quanti capi sono stati venduti?");
            capivenduti = Convert.ToInt32(Console.ReadLine());

            double SommaQuantitàStoffe = 0;
            SommaQuantitàStoffe = cotone + lino + seta + pizzo + velluto + lana + maglia;
            if (SommaQuantitàStoffe > StoffeMaxMagazzino)
            {
                Console.WriteLine("I m di stoffa presenti in magazzino sono troppi");
            }
            else
            {
                double SpazioRestanteMagazzinoStoffe;
                SpazioRestanteMagazzinoStoffe = StoffeMaxMagazzino - SommaQuantitàStoffe;
                Console.WriteLine("In magazzino si possono inserire ancora {0} metri di stoffa", SpazioRestanteMagazzinoStoffe);
            }

            int SommaQuantitàCapi = 0;
            SommaQuantitàCapi = felpe + giubbotti + pantaloni;
            if (SommaQuantitàCapi>CapiMaxMagazzino)
            {
                Console.WriteLine("La quantia di capi presenti in magazzino è troppo grande");
            }
            else
            {
                int SpazioRestanteMagazzinoCapi;
                SpazioRestanteMagazzinoCapi = CapiMaxMagazzino - SommaQuantitàCapi;
                Console.WriteLine("In magazzino si possono insererire ancora {0} capi", SpazioRestanteMagazzinoCapi);
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
                    Console.WriteLine("funzia");
                    Menù1();
                    break;
                case 2:
                    Console.WriteLine("non funzzia");
                    Menù2();
                    break;
                case 3:
                    Console.WriteLine("Default case");
                    Menù3();
                    break;
                case 4:
                    Console.WriteLine("oke");
                    Menù4();
                    break;
            }
        }
        static void Menù1()
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
