using System.Drawing;
using GymApp;

WritelineColor(ConsoleColor.Blue, "Witaj w programie GymApp tu zostaną zapisane Twoje dzisiejsze wyniki sporotwe.\n" +
    "Za najlepsze wyniki są nagordy!");
Console.WriteLine("==============================================================================");
Console.WriteLine();

WritelineColor(ConsoleColor.Magenta, "Podaj swoje imię");
var name = Console.ReadLine();
WritelineColor(ConsoleColor.Magenta, "Podaj swoje nazwisko");
var surname = Console.ReadLine();

Console.WriteLine();
WritelineColor(ConsoleColor.Green, $"Witaj {name} {surname}. Razem z trenerem podaj wyniki z każdej stacji.\n" +
"Za każde wykonane zadanie możesz uzyskać maksymalnie 20 punktów. Jeżeli nie podejmiesz się wyzwania wpisz 0. Powodzenia!");

var participant = new ParticipantInFile(name, surname);
participant.PointAdded += ParticipantPointAdded;

void ParticipantPointAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dziękuję za dodanie oceny");
}


for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Podaj wynik ze stacji numer {i}:");
    var input = Console.ReadLine();
    
    try
    {
        {
            participant.AddPoint(input);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
        i--;
    }
    continue;
}

var statistics = participant.GetStatistics();

Console.WriteLine();
WritelineColor(ConsoleColor.DarkCyan, $"Suma uzyskanych punktów: {statistics.Sum} na 100 \n" +
    $"Ilość podjętych wyzwań: {statistics.Count}/5 \n" +
    $"Maksymalna wartość zdobytych punktów na stacji: {statistics.Max}");

while (true)
{
    Console.WriteLine();
    WritelineColor(ConsoleColor.Gray, $"Twoja ocena dzisiejszych zmagań to: {statistics.FinalGrade}");
    if (statistics.FinalGrade == '5')
    {
        WritelineColor(ConsoleColor.Gray, "Brawo uzyskałeś bardzo dobre wyniki! Gratulacje, trzymaj tak dalej.");
        break;
    }
    else
    {
        WritelineColor(ConsoleColor.Gray, "Dziękujemy za wzięcie udziału w zawodach, do zobaczenia!");
        break;
    }
}

static void WritelineColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}