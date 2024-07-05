/*Program with the purpose of creating an animal catalog with especifics features of animals that can be classified and searched trought them
.Also, the search can be customized by creating new groups of animal features.*/

using System;
using AnimalCatalogue.Features;

bool endTask = true;
string registrationMenu = "====================\n|ANIMAL REGiSTRATION|\n====================\n1. Name\n2. Description\n3. Weight/Height\n4. Family\n5. Habitat\n6 Finish";
while (endTask)
{
    Console.WriteLine("======================================\n|WELCOME TO THE ANIMAL CATALOG SYSTEM|\n======================================");
    Console.WriteLine("1- Register Animal.\n2- Edit Catalog.\n3- Consult Catalog.\n4- Close");
    string readResult = Console.ReadLine();
    Console.Clear();

    switch (readResult)
    {
        case "1":
            do
            {
                Animal animal = new Animal();
                Console.Clear();
                Console.WriteLine(registrationMenu);
                readResult = Console.ReadLine();
                Console.Clear();
                switch (readResult)
                {
                    case "1":
                        animal.RegisterSpeciesName();
                        break;
                    case "2":
                        animal.RegisterSpeciesDescription();
                        break;
                    case "3":
                        animal.RegisterWeightAndHeight();
                        break;
                }
            } while (readResult != "6");
            break;
        case "2":
            break;
        case "3":
            break;
        case "4":
            endTask = false;
            break;
    }
}