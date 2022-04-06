using System.IO;

namespace SingleResponsibility
{
    /// <summary>
    /// Class that persist work with file operation for Journal instance
    /// So we create separate class to work with file and Journals
    /// </summary>
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}
