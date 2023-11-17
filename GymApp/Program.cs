using GymApp;

Console.WriteLine("Witaj w programie GymApp tu zostaną zapisane Twoje dzisiejsze wyniki sporotwe.\n" +
    "Za najlepsze wyniki są nagordy!\n" +
    "=====================");

Console.WriteLine();

Console.WriteLine("Podaj swoje imię");
var name = Console.ReadLine();
Console.WriteLine("Podaj swoje nazwisko");
var surname = Console.ReadLine();

Console.WriteLine($"Witaj {name} {surname}. Razem z trenerem podaj wyniki z każdej stacji");
Console.WriteLine("Za każde wykonane zadanie możesz uzyskać maksymalnie 20 punktów. Jeżeli nie podejmiesz się wyzwania wciśnij enter. Powodzenia!");

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
        participant.AddPoint(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }
    continue;
    //tu mam problem, jak dodaje ocenę z poza skali np 50 do 2 zadania to chciałabym żeby była możliwość poprawnego wpisania tej oceny jeszcze raz w tym samym 2 zadaniu   
}

var statistics = participant.GetStatistics();

Console.WriteLine();
Console.WriteLine($"Suma uzyskanych punktów: {statistics.Sum} na 100 \n" +
    $"Ilość podjętych wyzwań: {statistics.Count}/5 \n" +
    $"Maksymalna wartość zdobytych punktów na stacji: {statistics.Max}");

while (true)
{
    Console.WriteLine($"Twoja ocena dzisiejszych zmagań to: {statistics.FinalGrade}");
    if (statistics.FinalGrade == '5')
    {
        Console.WriteLine("Brawo uzyskałeś bardzo dobre wyniki! Gratulacje, trzymaj tak dalej.");
        break;
    }
    else
    {
        Console.WriteLine("Dziękujemy za wzięcie udziału w zawodach, do zobaczenia!");
        break;
    }
}