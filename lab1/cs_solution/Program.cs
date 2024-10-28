class Program
{
    static void Task_1()
    {
        Display display1 = new Display(50, 100, 300, "Display1");
        Display display2 = new Display(20, 60, 400, "Display2");
        Display display3 = new Display(140, 50, 500, "Display3");

        display1.CompareWithMonitor(display2);
        System.Console.WriteLine();
        display2.CompareWithMonitor(display3);
        System.Console.WriteLine();
        display1.CompareWithMonitor(display3);
        System.Console.WriteLine();
    }

    static void Task_2(string path)
    {
        List<TextData> dataList = FileReader.ReadTxtInTextData([path]);
        foreach (var data in dataList)
        {
            Console.WriteLine(data + "\n");
        }
    }

    static void Task_3()
    {
        Display display1 = new Display(50, 100, 300, "Display1");
        Display display2 = new Display(20, 60, 400, "Display2");
        Display display3 = new Display(140, 50, 500, "Display3");
        Assistant assistant = new Assistant("Assistant1");

        assistant.AssignDisplay(display1);
        assistant.AssignDisplay(display2);
        assistant.AssignDisplay(display3);

        assistant.Assist();

        assistant.BuyDisplay(display2);
        Console.WriteLine();

        assistant.Assist();
    }

    static void Task_4(string[] paths)
    {
        List<TextData> dataList = FileReader.ReadTxtInTextData(paths);
        foreach (var data in dataList)
        {
            Console.WriteLine(data + "\n");
        }
    }

    static void Main(string[] Args)
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("Choose a task to perform(tasks number 1-4):");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Task_1();
                    break;
                case 2:
                    Task_2(Args[0]);
                    break;
                case 3:
                    Task_3();
                    break;
                case 4:
                    Task_4(Args);
                    break;
                case 0:
                    break;
            }
        }
    }
}
