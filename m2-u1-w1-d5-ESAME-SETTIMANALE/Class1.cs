using System;
using System.Text.RegularExpressions;

namespace m2_u1_w1_d5_ESAME_SETTIMANALE
{
    public class Contribuente
    {
        // Proprietà della classe
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }

        // Costruttori della classe
        public Contribuente() { }
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale,
                                          char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        // Metodi comuni per settare le proprietà della classe Contribuente
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetCognome(string cognome)
        {
            Cognome = cognome;
        }
        public void SetDataNascita(DateTime dataNascita)
        {
            DataNascita = dataNascita;
        }
        public void SetCodiceFiscale(string codiceFiscale)
        {
            CodiceFiscale = codiceFiscale;
        }
        public void SetSesso(char sesso)
        {
            Sesso = sesso;
        }
        public void SetComuneResidenza(string comuneResidenza)
        {
            ComuneResidenza = comuneResidenza;
        }
        public void SetRedditoAnnuale(double redditoAnnuale)
        {
            RedditoAnnuale = redditoAnnuale;
        }

        // Metodo per calcolare l'imposta in base al reddito annuale
        public double CalcolaImposta()
        {
            if (RedditoAnnuale <= 15000)
            {
                return RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                return 3450 + ((RedditoAnnuale - 15000) * 0.27);
            }
            else if (RedditoAnnuale <= 55000)
            {
                return 6960 + ((RedditoAnnuale - 28000) * 0.38);
            }
            else if (RedditoAnnuale <= 75000)
            {
                return 17220 + ((RedditoAnnuale - 55000) * 0.41);
            }
            else
            {
                return 25420 + ((RedditoAnnuale - 75000) * 0.43);
            }
        }

        //metodi per la formattazione dei dati
        //metodo per rendere la prima lettera maiuscola e il resto minuscola
        public static string PrimaLetteraMaiuscola(string testo)
        {
            if (!string.IsNullOrEmpty(testo))
            {
                return char.ToUpper(testo[0]) + testo.Substring(1).ToLower();
            }
            return testo;
        }

        // metodi per raccogliere dati utente tramite imput e controlli
        //mtodo per controllare che l'input sia una stringa non vuota e con determinati caratteri
        private string RichiediStringaNonVuota(string messaggio)
        {
            string input;
            do
            {
                Console.Write(messaggio);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il campo non può essere vuoto, riprova.");
                    Console.ResetColor();
                }
                else if (!Regex.IsMatch(input, @"^[\p{L}']+$")) // tutte le lettere minuscole maiuscole con e senza accenti e l 'apostrofo
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il campo deve contenere solo lettere (anche accentate) o apostrofi, riprova.");
                    Console.ResetColor();
                }
                else
                {
                    return input;
                }
            } while (true);
        }

        //metodo per controllare che l'input sia una data nel formato gg/mm/aaaa
        private DateTime RichiediDataNascita()
        {
            DateTime dataNascita;
            DateTime dataMinima = new DateTime(1850, 1, 1);
            do
            {
                Console.Write("Inserisci la tua data di nascita (formato gg/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascita) && dataNascita < DateTime.Now && dataNascita > dataMinima)
                {
                    return dataNascita;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato data non valido, riprova.");
                    Console.ResetColor();
                }
            } while (true);
        }

        //metodo per controllare che l'input sia un carattere M o F (anche minuscolo)
        private char RichiediSesso()
        {
            char sessoInput;
            do
            {
                Console.Write("Inserisci il tuo sesso (M/F): ");
                string input = Console.ReadLine();
                sessoInput = input.ToUpper()[0];
                if (sessoInput == 'M' || sessoInput == 'F')
                {
                    return sessoInput;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato sesso non valido, inserire 'M' o 'F'.");
                    Console.ResetColor();
                }
            } while (true);
        }

        //metodo per controllare che l'input sia un numero decimale (double) e positivo 
        private double RichiediRedditoAnnuale()
        {
            double redditoAnnuale;
            do
            {
                Console.Write("Inserisci il tuo reddito annuale: ");
                if (double.TryParse(Console.ReadLine(), out redditoAnnuale) && redditoAnnuale > 0)
                {
                    return redditoAnnuale;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato del reddito non corretto, riprova.");
                    Console.ResetColor();
                }
            } while (true);
        }

        //metodo per controllare che l'input sia una stringa di 16 caratteri e non vuota
        private string RichiediCodiceFiscale()
        {
            string codiceFiscale;
            do
            {
                Console.Write("Inserisci il tuo codice fiscale: ");
                codiceFiscale = Console.ReadLine();

                if (!string.IsNullOrEmpty(codiceFiscale) && codiceFiscale.Length == 16)
                {
                    return codiceFiscale;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il codice fiscale deve essere di 16 caratteri, riprova.");
                    Console.ResetColor();
                }
            } while (true);
        }

        //metodo per raccogliere tutti i dati utente tramite i metodi sopra e settare le proprietà della classe Contribuente
        public void DataSet()
        {
            SetNome(RichiediStringaNonVuota("Inserisci il tuo nome: "));
            SetCognome(RichiediStringaNonVuota("Inserisci il tuo cognome: "));
            SetDataNascita(RichiediDataNascita());
            SetCodiceFiscale(RichiediCodiceFiscale());
            SetSesso(RichiediSesso());
            SetComuneResidenza(RichiediStringaNonVuota("Inserisci il tuo comune di residenza: "));
            SetRedditoAnnuale(RichiediRedditoAnnuale());
            Console.Clear();
        }
    }
}

