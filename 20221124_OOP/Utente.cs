using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20221124_OOP
{
    internal static class Utente
    {
        public static string Username = "user";

        public static string Password = "pass";


        private static bool _logged = false;
        public static bool Logged
        {
            get { return _logged; }
            set { _logged = value; }
        }

        private static DateTimeOffset _dataEntrata;

        public static DateTimeOffset DataEntrata
        {
            get { return _dataEntrata; }
            set { _dataEntrata = value; }
        }

        private static DateTimeOffset _dataUscita;

        public static DateTimeOffset DataUscita
        {
            get { return _dataUscita; }
            set { _dataUscita = value; }
        }

        public static List<DateTime> ListAccessi { get; set; } = new List<DateTime>();

        public static void MenuIniziale()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("****BENVENUTO NELLA TUA AREA PRIVATA****");
            Console.WriteLine("****************************************");

            Console.WriteLine("==============OPERAZIONI===============");
            Console.WriteLine(" Scegli l’operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("=======================================");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                if (choice == 1)
                {
                    Login();
                }
                else if (choice == 2)
                {
                    Logout();
                }
                else if (choice == 3)
                {
                    VerificaTempo();
                }
                else if (choice == 4)
                {
                    ListaAccessi();
                }
                else if (choice == 5)
                {
                    Esci();
                }
                else
                {
                    Console.WriteLine("Scelta non valida");
                    MenuIniziale();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Errore: {ex.Message}"); }
        }

        private static void Login()
        {
            Console.WriteLine("Inserisci la tua username");
            string username = Console.ReadLine();
            Console.WriteLine("Inserisci la tua password");
            string password = Console.ReadLine();
            Console.WriteLine("Conferma la tua password");
            string pass = Console.ReadLine();

            if (username == Username && password == Password && pass == Password)
            {
                Console.WriteLine("Hai effettuato il login con successo");
                _logged = true;
                _dataEntrata = DateTime.Now;
                MenuIniziale();
            }
            else
            {
                Console.WriteLine("User e/o password errate ... Riprova il login");
                MenuIniziale();
            }
        }

        private static void Logout()
        {
            if (_logged == false)
            {
                Console.WriteLine("Utente non loggato. Effettua il Login");
                MenuIniziale();
            }
            Console.WriteLine("Hai effettuato il logout con successo");
            _logged = false;
            _dataUscita = DateTime.Now;
            MenuIniziale();
        }

        private static void VerificaTempo()
        {
            if (Logged)
            {
                Console.WriteLine($"Ti sei Loggato il {_dataEntrata.Day}/{_dataEntrata.Month}/{_dataEntrata.Year} alle ore {_dataEntrata.Hour}:{_dataEntrata.Minute}");
            }
            else
            {
                Console.WriteLine("Non sei loggato. Effettua il Login");
                MenuIniziale();
            };
        }

        private static void ListaAccessi()
        {
            List<string> ListAccessi = new List<string>();

        }


        private static void Esci()
        {
            Console.WriteLine("========= D I S C O N N E S S I O N E  ========");
            Thread.Sleep(2000);

            Environment.Exit(0);
        }

    }
}

