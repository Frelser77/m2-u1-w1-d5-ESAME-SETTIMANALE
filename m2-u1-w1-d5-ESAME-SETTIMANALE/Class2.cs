using System;

namespace m2_u1_w1_d5_ESAME_SETTIMANALE
{
    public static class Menu
    {
        public static void Start()
        {
            Contribuente contribuente = new Contribuente();
            string resp;
            //aggiunta per visualizzare correttamente i caratteri speciali come quelli dell'euro
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            do
            {
                Console.Clear();
                Console.WriteLine("Si desidera continuare con il calcolo dell'imposta? (y/n)");
                resp = Console.ReadLine().ToLower();
                if (resp == "y")
                {
                    Console.Clear();
                    contribuente.DataSet();
                    Console.WriteLine("==================================================");
                    Console.WriteLine("\n");

                    Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
                    Console.WriteLine("\n");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Contribuente: {Contribuente.PrimaLetteraMaiuscola(contribuente.Nome)} " +
                                      $"{Contribuente.PrimaLetteraMaiuscola(contribuente.Cognome)},");
                    Console.WriteLine("\n");

                    Console.WriteLine($"nato il: {contribuente.DataNascita.ToShortDateString()}({contribuente.Sesso}),");
                    Console.WriteLine("\n");

                    Console.WriteLine($"residente in: {Contribuente.PrimaLetteraMaiuscola(contribuente.ComuneResidenza)},");
                    Console.WriteLine("\n");

                    Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale.ToUpper()},");
                    Console.WriteLine("\n");

                    Console.Write($"Reddito dichiarato: {contribuente.RedditoAnnuale},");
                    Console.WriteLine("\n");

                    Console.WriteLine($"IMPOSTA DA VERSARE: € {contribuente.CalcolaImposta():N2}");
                    Console.WriteLine("\n");

                    Console.ResetColor();
                }
                else if (resp == "n")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Grazie e Arrivederci!");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Scelta non valida! Premi un tasto per continuare.");
                    Console.ResetColor();
                    Console.ReadKey();
                }

                Console.WriteLine("Premi un tasto per tornare al menú inizale.");
                Console.ReadKey();
            } while (resp != "n");
        }
    }
}
