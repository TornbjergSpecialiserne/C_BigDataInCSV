using BigData_CSV;
using CsvHelper;
using System.Globalization;

string fileName = "TaskCatagories.csv";
string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName); //Get data in folder

string codeLangues = "c";

Console.WriteLine("Hello, World!");

//Test

try
{
    //Read
    using var reader = new StreamReader(fullPath);
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
    var records = csv.GetRecords<TaskCatagories>();

    Console.WriteLine($"Uniep {codeLangues} programs");

    List<string> showenTasks = new List<string>();

    List<TaskCatagories> allRecoards = new List<TaskCatagories>();

    foreach (var item in records)
    {
        allRecoards.Add(item);

        if (item.Skill == codeLangues)
        {
            if (!showenTasks.Contains(item.TaskDescription))
            {
                Console.WriteLine($"{item.TaskDescription} is {item.Category}");

                showenTasks.Add(item.TaskDescription);
            }
        }
    }

    //Close
    reader.Close();

    //Write
    using StreamWriter writer = new StreamWriter(fullPath);
    using CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

    //New item
    TaskCatagories gameCatagories = new TaskCatagories();
    gameCatagories.Skill = "C#";
    gameCatagories.TaskDescription = "Game development";
    gameCatagories.Category = "Frontend";

    allRecoards.Add(gameCatagories);

    csvWriter.WriteRecords(allRecoards);
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();