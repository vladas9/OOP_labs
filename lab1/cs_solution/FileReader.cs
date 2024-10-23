class FileReader
{
    public static TextData ReadTxtInTextData(string path)
    {
        var text = File.ReadAllText(path);
        return TextData.FromText(Path.GetFileName(path), text);
    }
}
