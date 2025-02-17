using System;
using System.IO;

namespace EdifactReader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pfad zur EDIFACT-Datei (anpassen, falls nötig)
            string filePath = "C:\\Users\\thomas.scharf\\EDIFACT_Encoder\\EDIFACT_Encoder\\EDIFACT_Encoder\\text2.txt";
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Datei '{filePath}' nicht gefunden.");
                Console.WriteLine("Drücke Enter zum Beenden...");
                Console.ReadLine(); // statt ReadKey
                return;
            }

            try
            {
                // Lese den kompletten Inhalt der Datei als String ein.
                string fileContent = File.ReadAllText(filePath);

                // Standardmäßig ist der Segmentterminator ein Apostroph (').
                char segmentTerminator = '\'';

                // Zerlege den Inhalt in Segmente.
                string[] segments = fileContent.Split(segmentTerminator, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("=== EDIFACT Datei Inhalt ===");
                Console.WriteLine();

                foreach (string segment in segments)
                {
                    string trimmedSegment = segment.Trim();
                    if (string.IsNullOrEmpty(trimmedSegment))
                        continue;

                    // Zerlege das Segment in Datenelemente.
                    string[] elements = trimmedSegment.Split('+');

                    Console.WriteLine($"Segment: {elements[0]}");

                    for (int i = 1; i < elements.Length; i++)
                    {
                        string[] components = elements[i].Split(':');
                        if (components.Length > 1)
                        {
                            Console.WriteLine($"  Element {i}:");
                            for (int j = 0; j < components.Length; j++)
                            {
                                Console.WriteLine($"    Komponente {j + 1}: {components[j]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"  Element {i}: {elements[i]}");
                        }
                    }
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Einlesen der Datei:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Drücke Enter, um das Programm zu beenden...");
            Console.ReadLine(); // ersetzt Console.ReadKey()
        }
    }
}

