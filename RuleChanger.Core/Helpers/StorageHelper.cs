namespace RuleChanger.Core.Helpers;

public class StorageHelper
{
    public static void Write(string path, string data)
    {
        var fileInfo = new FileInfo(path);

        if (!Directory.Exists(fileInfo.DirectoryName) && fileInfo.DirectoryName != null)
            Directory.CreateDirectory(fileInfo.DirectoryName);

        using var st = new StreamWriter(path);
        st.Write(data);
    }

    public static void WriteLine(string path, string data, bool append = false)
    {
        var fileInfo = new FileInfo(path);

        if (!Directory.Exists(fileInfo.DirectoryName) && fileInfo.DirectoryName != null)
            Directory.CreateDirectory(fileInfo.DirectoryName);

        using var st = new StreamWriter(path, append);
        st.WriteLine(data);
    }

    public static string? Read(string path)
    {
        if (!File.Exists(path))
            return null;

        return File.ReadAllText(path);
    }

    public static bool Exists(string path)
    {
        return File.Exists(path);
    }
}
