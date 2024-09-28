// Code Busters
// Dechiffrer message T9, de 0 à 9. 3-4 lettres par chiffre.
// Input touch client, Output messages possible

namespace CodeBusters.Main
{
    using CodeBusters.Algo;
    public static class Program
    {
        public static void Main()
        {
            const string inputKeys = "234567989";

            var decryptT9 = new T9Encrypt();
            var messages = decryptT9.GetPossibleMessages(inputKeys);

            Console.WriteLine($"Message is : {inputKeys}");
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            Console.ReadKey();
        }
    }
}

namespace CodeBusters.Algo
{
    using System.Text;

    public class T9Encrypt
    {
        private IReadOnlyDictionary<char, string> _dictT9Reference = new Dictionary<char, string>
    {
        { '2', "abc"},
        { '3', "def"},
        { '4', "ghi"},
        { '5', "jkl"},
        { '6', "mno"},
        { '7', "pqrs"},
        { '8', "tuvw"},
        { '9', "xyz"}
    };

        /// <summary>
        /// Write the possible messages from the input keys
        /// </summary>
        /// <param name="input">keys form user</param>
        public IReadOnlyList<string> GetPossibleMessages(string input)
        {
            var resultMessages = new List<string>();
            var possibilities = loadPossibilitiesValues(input);

            // Iterate through the possibilities, until the shortest one
            var iterator = possibilities.Min(x => x.Length);
            for (int i = 0; i < iterator; i++)
            {
                // Add the ith of each values found
                var sb = new StringBuilder();
                foreach (var possibility in possibilities)
                {
                    sb.Append(possibility[i]);
                }
                resultMessages.Add(sb.ToString());
            }
            return resultMessages.AsReadOnly();
        }

        /// <summary>
        /// Get & Store the possibilities ValuePair in the dictionary
        /// </summary>
        /// <param name="input">User keys</param>
        /// <returns>List of the Value in the dictionary match with each key (char) of it dict</returns>
        private IReadOnlyList<string> loadPossibilitiesValues(string input)
        {
            var possibilities = new List<string>();
            input.ToList().ForEach((x) => possibilities.Add(_dictT9Reference[x]));

            return possibilities.AsReadOnly();
        }
    }
}