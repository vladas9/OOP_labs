
public class Assistant
{
    public string AssistantName { get; private set; }
    private List<Display> assignedDisplays;

    public Assistant(string name)
    {
        AssistantName = name;
        assignedDisplays = new List<Display>();
    }

    public void AssignDisplay(Display display)
    {
        assignedDisplays.Add(display);
        Console.WriteLine($"{display.Model} has been assigned to {AssistantName}.\n");
    }

    public void Assist()
    {
        Console.WriteLine($"Assisting with display comparisons for {AssistantName}:\n");
        for (int i = 0; i < assignedDisplays.Count - 1; i++)
        {
            assignedDisplays[i].CompareWithMonitor(assignedDisplays[i + 1]);
            Console.WriteLine();
        }
    }

    public Display? BuyDisplay(Display display)
    {
        if (assignedDisplays.Remove(display))
        {
            Console.WriteLine($"{display.Model} has been removed from the list and is ready for purchase. \n");
            return display;
        }
        else
        {
            Console.WriteLine($"{display.Model} is not in the list.\n");
            return null;
        }
    }
}

