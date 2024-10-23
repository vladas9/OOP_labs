public class Display
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public float PPI { get; private set; }
    public string Model { get; private set; }

    public Display(int width, int height, float ppi, string model)
    {
        Width = width;
        Height = height;
        PPI = ppi;
        Model = model;
    }

    private int GetArea()
    {
        return Width * Height;
    }

    public void CompareSize(Display otherDisplay)
    {
        int thisArea = GetArea();
        int otherArea = otherDisplay.GetArea();

        Dictionary<int, string> sizeComparison = new Dictionary<int, string>
            {
                { 1, $"{Model} is larger in size with an area of {thisArea} pixels." },
                { -1, $"{otherDisplay.Model} is larger in size with an area of {otherArea} pixels." },
                { 0, $"Both {Model} and {otherDisplay.Model} have the same size with an area of {thisArea} pixels." }
            };

        int comparisonResult = thisArea.CompareTo(otherArea);
        Console.WriteLine($"Comparing size between {Model} and {otherDisplay.Model}:");
        Console.WriteLine(sizeComparison[comparisonResult]);
    }

    public void CompareSharpness(Display otherDisplay)
    {
        Dictionary<int, string> sharpnessComparison = new Dictionary<int, string>
            {
                { 1, $"{Model} is sharper with a PPI of {PPI}." },
                { -1, $"{otherDisplay.Model} is sharper with a PPI of {otherDisplay.PPI}." },
                { 0, $"Both {Model} and {otherDisplay.Model} have the same sharpness with a PPI of {PPI}." }
            };

        int comparisonResult = PPI.CompareTo(otherDisplay.PPI);
        Console.WriteLine($"Comparing sharpness between {Model} and {otherDisplay.Model}:");
        Console.WriteLine(sharpnessComparison[comparisonResult]);
    }

    public void CompareWithMonitor(Display otherDisplay)
    {
        Console.WriteLine($"Comparing overall (size and sharpness) between {Model} and {otherDisplay.Model}:");
        CompareSize(otherDisplay);
        CompareSharpness(otherDisplay);
    }
}
