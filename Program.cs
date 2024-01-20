// See https://aka.ms/new-console-template for more information

//zgadywanie zwierząt
//tablica i rnd
//przyjmowanie i porównywanie - matematycznie
//nazwij swego gracza
//punkty

using System.Formats.Asn1;

string[] availableAnimals = { "cat", "dog", "goose", "sheep", "horse" };

Random rng = new Random();

Console.WriteLine("Quess the animal!");

while (true)
{
    Console.WriteLine("You can choose from: ");
    foreach (string animal in availableAnimals)
    {
        Console.Write($"| {animal} | ");
    }

    Console.WriteLine();

    string? choosedAnimal;
    Console.WriteLine("Which animal was choosed? Provide animal or write 'end' the game: ");
    string? quessedAnimal = Console.ReadLine()?.ToLower().Trim();

    int quessedAnimalIndex = Array.IndexOf(availableAnimals, quessedAnimal);

    while (!availableAnimals.Contains(quessedAnimal) && quessedAnimal != "end" && quessedAnimal != "ultimate animal")
    {
        Console.WriteLine("Really? Provide animal or write 'end' to end the game.");
        quessedAnimal = Console.ReadLine()?.ToLower().Trim();
    }

    int choosedanimalIndex = rng.Next(availableAnimals.Length);
    choosedAnimal = availableAnimals[choosedanimalIndex];

    string? answer;

    string[] availableAnswers = { "yes", "no", "just a small coffe, please" };

    if (quessedAnimal == "end")
    {
        break;
    }

    if (quessedAnimal == choosedAnimal)
    {
        Console.WriteLine($"You're right! It's the {choosedAnimal}!");
    }
    else if (quessedAnimal == "ultimate animal")
    {
        Console.WriteLine("You're sure you want this? Write back to come back!");
        answer = Console.ReadLine();
        while (!availableAnswers.Contains(answer) && answer != "back")
        {
            Console.WriteLine("Really? Why do you even try this? You wanna come back? Write 'back'!");
            answer = Console.ReadLine()?.ToLower().Trim();
        }

        //tu losowanie ultimate animal i pat pat albo picie kawy - wybór kawy - picie kawy

        if (answer == "back")
        {
            break;
        }
    }
    else
    {
        Console.WriteLine($"You're far from truth! It's the {choosedAnimal}!");
        if (choosedanimalIndex > quessedAnimalIndex)
        {
            Console.WriteLine("But you're also some place before the correct animal!");
            Console.WriteLine("I know it's uselles info!");
        }
        else
        {
            Console.WriteLine("But you're also some place after the correct animal!");
            Console.WriteLine("I know it's uselles info!");
        }
    }
}
