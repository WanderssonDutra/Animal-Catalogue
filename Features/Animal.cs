using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace AnimalCatalogue.Features
{
    public class Animal
    {
        private string Species { get; set; }
        private string Description { get; set; }
        private float Height { get; set; }
        private float Weight { get; set; }
        /// <summary>
        /// Register the animal species name within a variable that will be transformed into a character array to some validation. If the string doesn't contains any number and is not empty, then the inputed string will be set into the Species property.
        /// </summary>
        public void RegisterSpeciesName()
        {
            Console.WriteLine("Insert the name of the specie: ");
            string readResult = Console.ReadLine();
            bool hasNumber = false;

            foreach (char character in readResult)
                if (decimal.TryParse(Convert.ToString(character), out decimal decimalValidate))
                    hasNumber = true;

            if (String.IsNullOrEmpty(readResult) || readResult.Length >= 30 || hasNumber)
            {
                Console.WriteLine("The specie name is invalid, please insert a valid name:\n1. Cannot be empty.\n2. Cannot contains numbers.\n3. Cannot has more than 30 characters.");
                Console.ReadKey();
                Console.Clear();
            }
            else
                Species = readResult;
        }
        /// <summary>
        /// Register the animal species description within a variable that will be stored as array of strings splitted by commas and after that will be splitted even more by spaces.
        /// </summary>
        public void RegisterSpeciesDescription()
        {
            Console.WriteLine("Make a description about the animal species: ");
            string readResult = Console.ReadLine();
            string[] readResultSplit = readResult.Split(",");
            bool hasLetterandNumber = false;

            foreach (string readResultSplitMore in readResultSplit)
                readResultSplit = readResultSplitMore.Split(" ");

            //within the "for" structure there is an array of characters that stores each letter of the array "readResultSplit" index. after that, the character array is examined throutgh another "for" structure, if the first indexed value can be converted to a decimal, and after that, if the indexed valued that is being examined at the moment cannot be converted to a number, then the "letters" array of characters has both values that can be and cannot be converted to numbers. If the previous condition is true, then the boolean variable "hasLetterAndNumber" is set true.
            for (int count = 0; count < readResultSplit.Length; count++)
            {
                char[] letters = readResultSplit[count].ToCharArray();
                for (int count2 = 0; count2 < letters.Length; count2++)
                {
                    if (decimal.TryParse(Convert.ToString(letters[0]), out decimal decimalValidate))
                    {
                        if (!decimal.TryParse(Convert.ToString(letters[count2]), out decimalValidate))
                            hasLetterandNumber = true;
                    }
                    else if (!decimal.TryParse(Convert.ToString(letters[0]), out decimalValidate))
                    {
                        if (decimal.TryParse(Convert.ToString(letters[count2]), out decimalValidate))
                            hasLetterandNumber = true;
                    }
                }
            }
            if (hasLetterandNumber || readResult.Length > 100 || String.IsNullOrEmpty(readResult))
            {
                Console.WriteLine("The description you tried to assign to the animal species doesn't satisfy the requirements.");
                Console.ReadKey();
            }
            else
                Description = readResult;
        }
        /// <summary>
        /// Stores the weight and height of the animal species.
        /// </summary>
        public void RegisterWeightAndHeight()
        {
            Console.WriteLine("========\n|WEIGHT|\n========");
            string readWeightResult = Console.ReadLine();
            Console.WriteLine("================\n|HEIGHT IN M/CM|\n================");
            string readHeightResult = Console.ReadLine();
            if ((!decimal.TryParse(readHeightResult, out decimal decimalValidate)) || (!decimal.TryParse(readWeightResult, out decimalValidate)))
            {
                if (!decimal.TryParse(readHeightResult, out decimalValidate))
                    Console.WriteLine("The Height is invalid. Please try again.");
                if (!decimal.TryParse(readWeightResult, out decimalValidate))
                    Console.WriteLine("The Weight is invalid. Please try again.");
                Console.ReadKey();
            }
            else
            {
                Height = float.Parse(readHeightResult); Weight = float.Parse(readWeightResult);
            }
        }

    }
}