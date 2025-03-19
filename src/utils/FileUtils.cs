namespace nuoqin.src.utils
{
    public class FileUtils
    {
        public static string getFileType(string fileName)
        {
            var lastIndex = fileName.LastIndexOf('.');
            return fileName.Substring(lastIndex + 1);
        }
    }
}
