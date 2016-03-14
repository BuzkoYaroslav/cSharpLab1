﻿using System;
using System.Collections.Generic;
using System.IO;
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
         public SearchWord(string fileName, string filter)
        {
            ChangeFilter(filter);
            ChangeFile(fileName);
        }

        public string SetFile
        {
            set
            {
                ChangeFile(value);
            }
        }
        public string SetFilter
        {
            set
            {
                ChangeFilter(value);
            }
        }

        private void ChangeFile(string fName)
        {
            allSentences.Clear();
            filteredSentences.Clear();
            try
            {
                fileName = fName;
                ReadAllSentences();
                SearchSentences();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File does not exist! Input correct file name: ");
                ChangeFile(Console.ReadLine());
            }
        }
        private void ChangeFilter(string writtenFilter)
        {
            writtenFilter = writtenFilter.TrimEnd().TrimStart();
            for (int i = 0; i < writtenFilter.Length; i++)
                if (!char.IsLetter(writtenFilter[i]))
                    throw new Exception("Input string is not a word!");
            filter = writtenFilter.ToLower();
        }

        private void ReadAllSentences()
        {
            StreamReader strRead = new StreamReader(fileName);
            string currentSentence = null;
            string buffer;
            while (!strRead.EndOfStream)
            {
                buffer = strRead.ReadLine();
                while (buffer.IndexOf(spliter) != -1)
                {
                    currentSentence += buffer.Substring(0, buffer.IndexOf(spliter) + 1);
                    buffer = buffer.Substring(buffer.IndexOf(spliter) + 1);
                    buffer = buffer.TrimStart();
                    allSentences.Add(currentSentence);
                    currentSentence = null;
                }
                currentSentence = buffer;
            }
            if (allSentences == null)
                throw new Exception("File has no sentence!");
        }
        private void SearchSentences()
        {
            foreach (string sentece in allSentences)
            {
                if (sentece.ToLower().Contains(filter))
                {
                    filteredSentences.Add((string)sentece.Clone());
                }
            }
        }
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
