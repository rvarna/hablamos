// See https://aka.ms/new-console-template for more information
using Hablamos;
using Hablamos.Utils;

Console.WriteLine("Welcome to Hablmos, press q to quit anytime.");

QuestionsFactory factory = new QuestionsFactory();
var question = factory.GetNextQuestion();
var options = question.GetOptions();
do
{
    
    Console.WriteLine(question.Verb);
    for (int i = 0; i < options.Count; i++)
    {
        Console.WriteLine($"{i}: {options[i]}");
    }

    var input = Console.ReadLine();
    if (input == "q")
    {
        Console.WriteLine("Exiting...");
        return;
    }

    if (int.TryParse(input, out int guess) && guess < options.Count)
    {
        if (options[guess] == question.Translation)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Incorrect. Answer is {question.Translation}");
        }

        question = factory.GetNextQuestion();
        options = question.GetOptions();
    }
    else
    {
        Console.WriteLine($"Invalid guess, try again.");
    }
}
while (true);
