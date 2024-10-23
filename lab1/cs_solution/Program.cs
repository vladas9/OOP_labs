class Program
{
    static void Task_1()
    {
        Display display1 = new Display(1920, 1080, 300, "Display1");
        Display display2 = new Display(2560, 1440, 400, "Display2");
        Display display3 = new Display(3840, 2160, 500, "Display3");

        display1.CompareWithMonitor(display2);
        System.Console.WriteLine();
        display2.CompareWithMonitor(display3);
        System.Console.WriteLine();
        display1.CompareWithMonitor(display3);
    }
    static void Task_2(string path)
    {
        TextData data = FileReader.ReadTxtInTextData(path);
        Console.WriteLine(data);
    }
    static void Main(string[] Args)
    {
        Task_1();
        Task_2(Args[0]);
    }
}
