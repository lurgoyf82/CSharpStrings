using CSharpStrings.Domain.Entities;
using CSharpStrings.Domain.Services;

namespace CSharpStrings.Infrastructure.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int CalculateSum(string? input, CalculatorOptions options)
        {
            string? numbersSection = null;
            if (options.Delimiters == null||true)
            {
                string? delimiterSection = null;
                (delimiterSection, numbersSection) = SplitHeader(input);

                if(delimiterSection == null && options.Delimiters == null)
                {
                    throw new ArgumentException("No delimiters.");
                }

                if (options.Delimiters == null)
                {
                    options.Delimiters = ParseDelimeterSection(delimiterSection);
                }
                else
                {
                    if (delimiterSection != null)
                    {
                        // Aggiungi i delimitatori custom alla lista esistente
                        options.Delimiters.AddRange(ParseDelimeterSection(delimiterSection));
                    }
                }
            }
            else
            {
                numbersSection = input;
            }

            if (options.AllowMultipleDelimeters == false)
            {
                //se i delimitatori custom (esclusa la virgola) sono piu di uno, lancia un'eccezione
                if (options.Delimiters.Count > 0 && options.Delimiters.Count(d => d != ",") > 1)
                {
                    throw new ArgumentException("Multiple delimiters not allowed.");
                }
            }

            if (options.MaxDelimeterSize > 0)
            {
                //se options.Delimiters contiene un delimitatore più lungo di MaxDelimeterSize, lancia un'eccezione
                if (options.Delimiters.Any(d => d.Length > options.MaxDelimeterSize))
                {
                    throw new ArgumentException($"Delimiters cannot be longer than {options.MaxDelimeterSize} characters.");
                }
            }




            List<int> numbers = ParseNumbersSection(numbersSection, options.Delimiters);




            if (options.MaxNumbers > 0)
            {
                //Se ci sono piu numeri di quelli consentiti, lancia un'eccezione
                if (numbers.Count > options.MaxNumbers)
                {
                    throw new ArgumentException($"Too many numbers: expected at most {options.MaxNumbers}, but got {numbers.Count}.");
                }
            }

            if (options.AllowNegatives == false)
            {
                var negatives = numbers.Where(n => n < 0).ToList();
                if (negatives.Any())
                {
                    var negativesList = string.Join(", ", negatives);
                    throw new ArgumentException($"negatives not allowed: {negativesList}");
                }
            }

            if (options.IgnoreAboveOrEqual > 0)
            {
                //Se ci sono numeri maggiori o uguali di IgnoreAboveOrEqual, li ignora
                //Nota: se IgnoreAboveOrEqual è 0, non viene applicata alcuna condizione
                numbers = numbers.Where(n => n < options.IgnoreAboveOrEqual).ToList();
            }

            //finalmente se tutte le condizioni sono rispettate, calcola la somma (e ritorna 0 se la stringa è nulla o vuota)
            return numbers.Sum();
        }



        // Restituisce i delimitatori custom separati dalla sezione con i numeri
        public (string? delimiterSection, string numbersSection) SplitHeader(string? input)
        {
            // Nessun header custom: torna la stringa intera come numeri
            if (string.IsNullOrEmpty(input) || !input.StartsWith("//["))
            {
                // throw new FormatException("Header delimitatori non valido");
                return (null,input);
            }

            // Posizione della sequenza finale "]//" (parte dalla posizione 3 per saltare “//[” iniziali)
            var end = input.IndexOf("]//", 3, StringComparison.Ordinal);
            if (end < 0) throw new FormatException("Header delimitatori non valido");

            end += 3;                // include “]//” nel segmento dei delimitatori
            return (input[..end],    // substring dallo 0 escluso end (header)
                    input[end..]);   // substring da end alla fine   (numeri)
        }

        public List<int> ParseNumbersSection(string? numberSection, List<string> delimiters)
        {
            // Se non ci sono numeri, ritorna lista vuota
            if (string.IsNullOrWhiteSpace(numberSection))
            {
                return new List<int>();
            }


            var numbers = new List<int>();

            // Suddivide la stringa usando tutti i delimitatori forniti
            var tokens = numberSection.Split(delimiters.ToArray(), StringSplitOptions.None);

            foreach (var token in tokens)
            {
                // Salta eventuali stringhe vuote dovute a delimitatori consecutivi
                if (string.IsNullOrWhiteSpace(token))
                {
                    continue;
                }

                // Converte il token in intero, altrimenti lancia eccezione di formato
                if (!int.TryParse(token, out var value))
                {
                    throw new FormatException($"Valore numerico non valido: '{token}'");
                }

                numbers.Add(value);
            }

            return numbers;
        }

        public List<string> ParseDelimeterSection(string delimiterSection)
        {
            // Valida header: deve iniziare con "//[" e terminare con "]//"
            if (!delimiterSection.StartsWith("//[") || !delimiterSection.EndsWith("]//"))
            {
                throw new FormatException("Header delimitatori non valido.");
            }

            // Rimuove il prefisso "//[" (3 char) e il suffisso "]//" (3 char)
            delimiterSection = delimiterSection.Substring(3, delimiterSection.Length - 6);


            if (string.IsNullOrWhiteSpace(delimiterSection))
            {
                throw new ArgumentException("Nessun delimitatore specificato.");
            }

            // Split by '][' to get multiple delimiters
            string[]? delimetersArray = null;

            try
            {
                delimetersArray = delimiterSection.Split(new[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new FormatException("Formato delimitatori non valido.", ex);
            }


            return delimetersArray.ToList();
        }

        public List<string> GetCustomDelimiters(string? input)
        {
            //Delimeters follow this syntax //[delimiter]//

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Nessun delimitatore specificato.");
            }

            var delimiters = new List<string>();

            //first split ]// starting from the end of the string
            if (input.EndsWith("]//"))
            {
                input = input.Substring(0, input.Length - 3);
            }


            var parts = input.Split(new[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                if (part.StartsWith("[") && part.EndsWith("]"))
                {
                    // Custom delimiter
                    var delimiter = part.Trim('[', ']');
                    if (!string.IsNullOrWhiteSpace(delimiter))
                    {
                        delimiters.Add(delimiter);
                    }
                }
                else
                {
                    // Default delimiter
                    delimiters.Add(part);
                }
            }

            return delimiters;
        }
    }
}