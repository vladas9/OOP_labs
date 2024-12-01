using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string queueFolder = "queue";
        string pythonScript = "./random_cars.py";

        if (!Directory.Exists(queueFolder))
        {
            Directory.CreateDirectory(queueFolder);
        }

        Process pythonProcess = StartPythonScript(pythonScript);
        Semaphore semaphore = null;

        try
        {
            var peopleDiningService = new PeopleDinner();
            var robotDiningService = new RobotDinner();
            var gasStation = new GasStation();
            var electricStation = new ElectricStation();

            var gasStationCarStation = new CarStation(peopleDiningService, robotDiningService, gasStation, new SimpleQueue<Car>());
            var electricStationCarStation = new CarStation(peopleDiningService, robotDiningService, electricStation, new SimpleQueue<Car>());

            semaphore = new Semaphore(gasStationCarStation, electricStationCarStation);

            var scheduler = new Scheduler(semaphore, queueFolder, readInterval: 5, serveInterval: 10);
            scheduler.Start();

            Console.WriteLine("Scheduler started. Press any key to stop...");
            Console.ReadKey();

            scheduler.Stop();
            Console.WriteLine("Scheduler stopped.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            if (pythonProcess != null && !pythonProcess.HasExited)
            {
                pythonProcess.Kill();
                Console.WriteLine("Python script stopped.");
            }
            if (semaphore != null)
            {
                Console.WriteLine("Final Statistics:");
                Console.WriteLine($"Gas cars served: {semaphore.GetGasCarsServed()}");
                Console.WriteLine($"Electric cars served: {semaphore.GetElectricCarsServed()}");
            }
        }
    }

    private static Process StartPythonScript(string pythonScript)
    {
        try
        {
            var pythonProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "python3",
                    Arguments = pythonScript,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            Console.WriteLine("Starting the Python generator script...");
            pythonProcess.Start();

            return pythonProcess;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to start Python script: {ex.Message}");
            return null;
        }
    }
}
