using CasinoGame.SaveLoadService;


namespace GamePrototype.Services
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _directoryPath;

        public FileSystemSaveLoadService(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentException("Path can not be null or empty", nameof(directoryPath));
            }

            _directoryPath = directoryPath;

            // Проверяем и создаем директорию, если ее нет
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        public void SaveData(string data, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id can not be null or empty", nameof(id));
            }

            string filePath = Path.Combine(_directoryPath, id + ".txt");
            try
            {
                File.WriteAllText(filePath, data);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while saving data to file {filePath}: {e.Message}");
            }
        }

        public string LoadData(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id can not be null or empty", nameof(id));
            }

            string filePath = Path.Combine(_directoryPath, id + ".txt");
            if (!File.Exists(filePath))
                return null;
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while loading data from file {filePath}: {e.Message}");
            }
        }
    }
}