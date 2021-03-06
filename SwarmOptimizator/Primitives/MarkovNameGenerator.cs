﻿using MyRandomGenerator;
using SwarmOptimizator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmOptimizator {
    public sealed class MarkovNameGenerator {
        static readonly Lazy<MarkovNameGenerator> instance = new Lazy<MarkovNameGenerator>(GetStandart);

        public static readonly string[] OrcNameSamples = {
            "Вася","Петя","Саша","Паша"
        };

        public static MarkovNameGenerator GetStandart() {

            return new MarkovNameGenerator(Resources.Names.Split('\n'), 3, 3);
        }
        public static MarkovNameGenerator Instance {
            get {
                return instance.Value;
            }
        }
        public static IEnumerable<string> GetNamesByParents(IEnumerable<string> parentnames, int order=3, int minLength=3, int newParentsCount = 1, int cycleLim = 10) {
            var lst = parentnames.ToList();
            for (int i = 0; i < newParentsCount; i++) {
                lst.Add(Instance.GetNextName());
            }
            var m_new = new MarkovNameGenerator(lst, order, minLength);
            
            while (true) {
                string name;
                int cycle = 0;
                do {
                    name = m_new.GetNextName();
                    cycle++;
                } while (lst.Contains(name) && cycle <= cycleLim);               
                yield return cycleLim <= cycle ? Instance.GetNextName() : name;
            }
        }

        public MarkovNameGenerator(IEnumerable<string> sampleNames, int order = 3, int minLength= 3) {
            //fix parameter values
            if (order < 1)
                order = 1;
            if (minLength < 1)
                minLength = 1;

            m_order = order;
            m_minLength = minLength;

            //split comma delimited lines
            foreach (string line in sampleNames) {
                string[] tokens = line.Split(',');
                foreach (string word in tokens) {
                    string upper = word.Trim().ToUpper();
                    if (upper.Length < order + 1)
                        continue;
                    m_samples.Add(upper);
                }
            }

            //Build chains
            foreach (string word in m_samples) {
                for (int letter = 0; letter < word.Length - order; letter++) {
                    string token = word.Substring(letter, order);
                    List<char> entry;
                    if (m_chains.ContainsKey(token))
                        entry = m_chains[token];
                    else {
                        entry = new List<char>();
                        m_chains[token] = entry;
                    }
                    entry.Add(word[letter + order]);
                }
            }
        }

        //Get the next random name
        public string GetNextName() {
            //get a random token somewhere in middle of sample word
            string s;
            int nCycle = 0;
            do {
                nCycle++;
                int n = m_rnd.GetInt(0,m_samples.Count);
                int nameLength = m_samples[n].Length;
                s = m_samples[n].Substring(m_rnd.GetInt(0, m_samples[n].Length - m_order), m_order);
                while (s.Length < nameLength) {
                    string token = s.Substring(s.Length - m_order, m_order);
                    char c = GetLetter(token);
                    if (c != '?')
                        s += GetLetter(token);
                    else
                        break;
                }

                if (s.Contains(" ")) {
                    string[] tokens = s.Split(' ');
                    s = "";
                    for (int t = 0; t < tokens.Length; t++) {
                        if (tokens[t] == "")
                            continue;
                        if (tokens[t].Length == 1)
                            tokens[t] = tokens[t].ToUpper();
                        else
                            tokens[t] = tokens[t].Substring(0, 1) + tokens[t].Substring(1).ToLower();
                        if (s != "")
                            s += " ";
                        s += tokens[t];
                    }
                } else
                    s = s.Substring(0, 1) + s.Substring(1).ToLower();

                if (nCycle > 300)
                    return s;
            }
            while (s.Length < m_minLength || m_used.Contains(s));
            if (m_used.Count > 10000)
                Reset();
            m_used.Add(s);


            return s;
        }

        //Reset the used names
        public void Reset() {
            m_used.Clear();
        }

        private Dictionary<string, List<char>> m_chains = new Dictionary<string, List<char>>();
        private List<string> m_samples = new List<string>();
        private List<string> m_used = new List<string>(10000 + 1);
        private MyRandom m_rnd = new MyRandom();
        private int m_order;
        private int m_minLength;

        //Get a random letter from the chain
        char GetLetter(string token) {
            if (!m_chains.ContainsKey(token))
                return '?';

            List<char> letters = m_chains[token];
            int n = m_rnd.GetInt(0,letters.Count);

            return letters[n];
        }
    }
}
