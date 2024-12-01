public class Scheduler
{
    private readonly Semaphore _semaphore;
    private readonly int _readInterval;
    private readonly int _serveInterval;
    private readonly string _queueFolder;
    private CancellationTokenSource _cancellationTokenSource;

    public Scheduler(Semaphore semaphore, string queueFolder, int readInterval = 5, int serveInterval = 10)
    {
        _semaphore = semaphore;
        _queueFolder = queueFolder;
        _readInterval = readInterval * 1000;
        _serveInterval = serveInterval * 1000;
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public void Start()
    {
        var cancellationToken = _cancellationTokenSource.Token;

        Task.Run(() => ReadFromQueueFolderAsync(cancellationToken), cancellationToken);
        Task.Run(() => ServeCarsAsync(cancellationToken), cancellationToken);
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }

    private async Task ReadFromQueueFolderAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                Console.WriteLine("Checking for new car JSON files...");
                foreach (var file in Directory.GetFiles(_queueFolder, "*.json"))
                {
                    string json = File.ReadAllText(file);

                    _semaphore.ProcessCarFromJson(json);

                    File.Delete(file);
                    Console.WriteLine($"Processed and deleted file: {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading files: {ex.Message}");
            }

            await Task.Delay(_readInterval, cancellationToken);
        }
    }

    private async Task ServeCarsAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                Console.WriteLine("Serving cars...");
                _semaphore.ServeAllCars();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while serving cars: {ex.Message}");
            }

            await Task.Delay(_serveInterval, cancellationToken);
        }
    }
}
