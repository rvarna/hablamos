using Hablamos.Utils;

namespace Hablamos
{
    internal class Question
    {
        public Question(string verb, string translation, IList<string> options)
        {
            Verb = verb;
            Translation = translation;
            OtherOptions = options;
        }

        public string Verb { get; set; }

        public string Translation { get; set; }

        public IList<string> OtherOptions { get; set; }

        public IList<string> GetOptions()
        {
            var options = new List<string>(OtherOptions);
            options.Add(Translation);
            options.Shuffle();
            return options;
        }
    }
}
