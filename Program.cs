using System.Buffers;
using System.Runtime.InteropServices;

string[] availableAnimals = { "cat", "dog", "goose", "sheep", "horse" };

string[] availableAnswers = { "of course", "history", "coffee" };

string[] availableUltimateAnimals = { "unicorn", "dragon", "phoenix" };

string[] menu = { "mocha", "latte", "black" };

Random rng = new Random();

Random ua = new Random();


Console.WriteLine("Quess the animal!");
Console.WriteLine();

int points = 0;

string coffeeanswer;

string yourName = PlayersName("Steven");
string secondOneName = PlayersName("Steve");

Console.WriteLine($"How many quessed to win, {yourName}? If you want to unlocked secret you have to correctly quessed the animal at least 5 times.");
string manyWin = Console.ReadLine() ?? string.Empty;

bool result = Int32.TryParse(manyWin, out int winWin);
if (!result)
{
    winWin = 5;
}

Console.WriteLine();

while (points < winWin)
{
    Console.WriteLine("You can choose from: ");
    foreach (string animal in availableAnimals)
    {
        Console.Write($"| {animal} | ");
    }

    Console.WriteLine();
    Console.WriteLine("You can also write 'end' to end the game.");
    Console.WriteLine();

    string choosedAnimal;
    
    string quessedAnimal = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    Console.WriteLine();

    int quessedAnimalIndex = Array.IndexOf(availableAnimals, quessedAnimal);

    while (!availableAnimals.Contains(quessedAnimal) && quessedAnimal != "end" && quessedAnimal != "ultimate animal")
    {
        Console.WriteLine("Really? Provide animal or write 'end' to end the game.");
        quessedAnimal = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    }

    int choosedanimalIndex = rng.Next(availableAnimals.Length);
    choosedAnimal = availableAnimals[choosedanimalIndex];

    string answer;

    string ultimateAnimal;

    if (quessedAnimal == "end")
    {
        break;
    }

    if (quessedAnimal == choosedAnimal)
    {
        Console.WriteLine($"You're right! It's the {choosedAnimal}!");
        points++;
    }
    else if (quessedAnimal == "ultimate animal")
    {
        while (true)
        {
            Console.WriteLine("You're sure you want this? Write 'back' to come back!");
            Console.WriteLine("Possible answers: ");

            foreach (string possibleAnswer in availableAnswers)
            {
                Console.Write($"| {possibleAnswer} | ");
            }

            Console.WriteLine();

            int ultimateAnimalIndex = rng.Next(availableUltimateAnimals.Length);

            ultimateAnimal = availableUltimateAnimals[ultimateAnimalIndex];

            string? yesOrNo;
            string? coffeeYesNo;

            answer = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
            Console.WriteLine();

            while (!availableAnswers.Contains(answer) && answer != "back")
            {
                Console.WriteLine("Really? Why do you even try this? Write 'back' to come back!");
                answer = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                Console.WriteLine();

            }

            if (answer == "of course")
            {
                Console.WriteLine($"You can see: {ultimateAnimal} ");

                Console.WriteLine("Do you want to pet it? yes/no");
                yesOrNo = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                Console.WriteLine();

                while (yesOrNo != "yes" && yesOrNo != "no")
                {
                    Console.WriteLine("Really? Why do you even try this?");
                    yesOrNo = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                    Console.WriteLine();
                }

                if (yesOrNo == "yes")
                {
                    Console.WriteLine($"The {ultimateAnimal} is happy!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"The {ultimateAnimal} is sad!");
                    Console.WriteLine();
                }

            }
            else if (answer == "history")
            {
                Console.WriteLine($"My name is {secondOneName}. I don't have idea who I am and who you are. It kinda weird, isn't it? All the story, nothing more.");
                Console.WriteLine();
            }
            else if (answer == "coffee")
            {
                Console.WriteLine("Wanna coffee? why not/not today");
                coffeeYesNo = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                Console.WriteLine();

                while (coffeeYesNo != "why not" && coffeeYesNo != "not today")
                {
                    Console.WriteLine("Really? Why do you even try this?");
                    coffeeYesNo = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                    Console.WriteLine();
                }
                if (coffeeYesNo == "why not")
                {
                    Console.WriteLine("Menu: ");
                    foreach (string coffeeType in menu)
                    {
                        Console.Write($"| {coffeeType} | ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Which coffee do you want?");
                    coffeeanswer = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;

                    while (!menu.Contains(coffeeanswer))
                    {
                        Console.WriteLine("Really? Why do you even try this?");
                        coffeeanswer = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine($"That's your {coffeeanswer}!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("That's ok.");
                    Console.WriteLine();
                }

            }
            if (answer == "back")
            {
                break;
            }
        }

    }
    else
    {
        Console.WriteLine($"You're far from truth! It's the {choosedAnimal}!");
        if (choosedanimalIndex > quessedAnimalIndex)
        {
            Console.WriteLine("But you're also some place before the correct animal!");
            Console.WriteLine("I know it's uselles info!");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("But you're also some place after the correct animal!");
            Console.WriteLine("I know it's uselles info!");
            Console.WriteLine();
        }
    }

    Console.WriteLine($"{yourName}, you have points: {points}");

    if (points >= 5)
    {
        Console.WriteLine("You have unlocked command: ultimate animal");
        Console.WriteLine();
    }

}

Console.WriteLine("Clik anything to end the game...");
Console.ReadLine();

string PlayersName(string name)
{
    Console.WriteLine($"Provide name, {name}: ");
    string naming = Console.ReadLine()?.Trim() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(naming))
    {
        return name;
    }
    else
    {
        return naming;
    }
}