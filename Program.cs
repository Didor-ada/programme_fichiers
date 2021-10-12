using System;
using System.Collections.Generic;
using System.IO;

namespace programme_fichiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = "out";

            Directory.CreateDirectory(path); // créer un dossier

            string filename = "monFichier.txt";

            string pathAndFile = Path.Combine(path, filename);

            Console.WriteLine("Fichier : " + pathAndFile);

            var noms = new List<string>()
            {
                "Jean",
                "Paul",
                "Martin"
            };

            // File.WriteAllText("monFichier.txt", "Voici le contenu que j'écris dans le fichier texte");
            // File.AppendAllText(filename, "je rajoute ce texte");
            File.WriteAllLines(pathAndFile, noms);

            try
            {
                // string resultat = File.ReadAllText(filename);
                var lignes = File.ReadAllLines(pathAndFile);

                foreach (var ligne in lignes)
                {
                    Console.WriteLine(ligne);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Erreur ce fichier n'existe pas (" + ex.Message + ")");
            }
            catch
            {
                Console.WriteLine("Une erreur inconnue est arrivée");
            }
        }
    }
}
