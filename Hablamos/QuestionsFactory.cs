using Hablamos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hablamos
{
    internal class QuestionsFactory
    {
        private Dictionary<string, List<string>> _verbsBank = new Dictionary<string, List<string>>();

        private string _previousVerb;

        public QuestionsFactory()
        {
            var lines = File.ReadAllLines(@".\lang\es\Verbs.csv");
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var verb = parts[0].Trim();
                var translation = parts[1].Trim();

                if (_verbsBank.TryGetValue(verb, out var translations))
                {
                    translations.Add(translation);
                }
                else
                {
                    _verbsBank[verb] = new List<string> { translation };
                }
            }
        }

        public Question GetNextQuestion()
        {
            var options = new List<string>();
            string verb = _verbsBank.Keys.ToList().PickRandom();
            var translation = _verbsBank[verb].PickRandom();
            _verbsBank.Remove(verb);
            while (options.Count < 3)
            {
                var option = _verbsBank.Keys.ToList().PickRandom();
                options.Add(_verbsBank[option].PickRandom());                
            }

            return new Question(verb, translation, options);
        }
    }
}
