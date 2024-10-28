class FileReader
{

    public static List<TextData> ReadTxtInTextData(string[] paths)
    {
        List<TextData> textDataList = new List<TextData>();

        foreach (var path in paths)
        {
            try
            {
                var text = File.ReadAllText(path);
                textDataList.Add(TextData.FromText(Path.GetFileName(path), text));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: The file '{path}' was not found. Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file '{path}': {ex.Message}");
            }
        }
        return textDataList;
    }

}
