namespace MultiShop.Utilities
{
    public static class Extension
    {
        public static bool ValidateType(this IFormFile formFile, string type = "image")
        {
            if (formFile.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateSize(this IFormFile formFile, int MbSize)
        {
            if (formFile.Length > MbSize * 1024 * 1024)
            {
                return false;
            }
            return true;
        }
        public static async Task<bool> CreateFormFile(this IFormFile formFile, params string[] paths)
        {
            string path = "";
            try
            {
                foreach (var item in paths)
                {
                    path = Path.Combine(path, item);
                }
                using (FileStream stream = new(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }
        public static bool DeleteFormFile(this string file, params string[] paths)
        {
            string path = paths.Aggregate(Path.Combine);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
        public static string GenerateName(this IFormFile file)
        {
            int i = file.FileName.LastIndexOf('.');
            string fileName = Guid.NewGuid().ToString() + file.FileName.Substring(i);
            return fileName;
        }
    }
}
