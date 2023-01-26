namespace Shop.Extesion
{
    public static class FileExtension
    {
        public static bool CheckSize(this IFormFile file, int kb)
        {
            return kb * 1024 > file.Length;
        }
        public static bool CheckType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }
        public static string SaveFile(this IFormFile file, string path)
        {
            string fileName = ChangeFileName(file.FileName);
            using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fs);
                return fileName;
            }
        }
        static string ChangeFileName(string oldName)
        {
            string extension = oldName.Substring(oldName.IndexOf('.'));
            if (oldName.Length<32)
            {
                oldName.Substring(0, oldName.IndexOf('.'));
            }
            else
            {
                oldName.Substring(0, 31);
            }
            return Guid.NewGuid().ToString() + oldName + extension;
        }
        public static string ChangeValidate(this IFormFile file, string type, int kb)
        {
            string result = "";
            if (!file.CheckSize(kb))
            {
                result += $"{file.FileName} faylinin olcusu {kb} kb-dan artiq olmamalidir";
            }
            if (!file.CheckType(type))
            {
                result += $"{file.FileName} faylinin tipi yalnisdir";
            }
            return result;
        }
        public static void DeleteFile(this string filename, string root, string folder)
        {
            string filePath = Path.Combine(root, folder, filename);
            if (!File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
