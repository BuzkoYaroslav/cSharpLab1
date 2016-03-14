using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchSentencesWithSomeWord
{
    class SearchWord
    {
        const char spliter = '.';
        List<string> allSentences = new List<string>(),
                    filteredSentences = new List<string>();
        public string fileName { get; private set; }
        public string filter { get; private set; }

        private void WriteSeveralSentences(List<string> sentences)
        {
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
        public void WriteResults()
        {
            Console.WriteLine("Result for file: {0}", fileName);
            Console.WriteLine("All sentences in this file: ");
            WriteSeveralSentences(allSentences);
            Console.WriteLine("Sentences filtred by : {0}", filter);
            if (filteredSentences != null)
            {
                WriteSeveralSentences(filteredSentences);
            }
            else
            {
                Console.WriteLine("Sentences with that filter do not exist");
            }
        }

    }
}
