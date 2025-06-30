namespace CambiaColores;

public static class DataBasePathHelper
{
    public static string GetDataBasePath(string dbName)
    {
        string folderPath = FileSystem.Current.AppDataDirectory;

        string fullPath = Path.Combine(folderPath, dbName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        return fullPath;
    }
}