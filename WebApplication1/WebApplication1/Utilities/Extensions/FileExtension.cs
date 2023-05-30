namespace WebApplication1.Utilities.Extensions
{
    public static class FileExtension
    {
        public static  bool CheckFileType(this IFormFile file,string fileType)
        {
            return file.ContentType.Contains(fileType+"/");
        }
        public static bool CheckFileSize(this IFormFile file,int size)
        {
            return file.Length/1024 > size;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file,string root,string folder)
        {
            string uniqueFileName=Guid.NewGuid().ToString()+file.FileName;
            string path=Path.Combine(root,folder,uniqueFileName);
            using(FileStream stream=new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return uniqueFileName;
        }
        public static void DeleteFile(this string file,string root,string folder)
        {
            string path = Path.Combine(root, folder,file);
            FileStream stream = new FileStream(path, FileMode.Open);
            if (System.IO.File.Exists(path))
            {
                stream.Close();
                File.Delete(path);
            }

        }
    }
}
