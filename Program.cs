using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace programme_fichiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = "out"; // le nom du dossier

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path); // créer un dossier
            }



            string filename = "monFichier.txt";

            string pathAndFile = Path.Combine(path, filename);

            if (File.Exists(pathAndFile)) // vérifie si le fichier existe en renvoie un booléen
            {
                Console.WriteLine("Le fichier existe déjà, son contenu va être écrasé");
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas, il va être créé");
            }

            Console.WriteLine("Fichier : " + pathAndFile);

            /*var noms = new List<string>()
            {
                "Jean",
                "Paul",
                "Martin"
            };*/

            StringBuilder texte = new StringBuilder();
            int nbLignes = 50000;

            // immutable
            // texte = "toto";
            // text += "o"; // totoo

            // mutable
            // StringBuilder

            // DateTime t1 = DateTime.Now;

            /*            Console.WriteLine("Préparation des données...");
                        for (int i = 1; i <= nbLignes; i++)
                        {
                            texte.Append ("Ligne " + i + "\n"); // append sert à rajouter, vu que texte n'est plus de type string, append va remplacer la conca +=
                        }
                        Console.WriteLine("OK");

                        Console.WriteLine("Ecriture des données...");
                        File.WriteAllText(pathAndFile, texte.ToString());
                        Console.WriteLine("OK");

                        DateTime t2 = DateTime.Now;
                        var diff = (int)((t2 - t1)).TotalMilliseconds; // 1s = 1000ms
                        Console.WriteLine("Durée (ms) :" + diff);*/


            // Stream : flux

            DateTime t1 = DateTime.Now;

            using (var writeStream = File.CreateText(pathAndFile))
            {
                for (int i = 1; i <= nbLignes; i++)
                {
                    writeStream.Write("Ligne " + i + "\n");
                }
            }

            Console.WriteLine("OK");
            DateTime t2 = DateTime.Now;
            var diff = (int)((t2 - t1)).TotalMilliseconds; // 1s = 1000ms
            Console.WriteLine("Durée (ms) :" + diff);





            // File.AppendAllText(filename, "je rajoute ce texte");
            // File.WriteAllLines(pathAndFile, noms);

            /*            try
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
                        }*/

            // File.Copy(pathAndFile, pathAndFile2); -> il faut inclure dans le code les variables copies du premier fichier correspondantes
            // File.Delete(pathAndFile2); -> delete le fichier en question
            // File.Move(pathAndFile, pathAndFile); -> renomme le premier fichier avec le nom du second
        }
    }
}
