using GamePrototype.Services;


namespace GamePrototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаем сервис сохранения/загрузки
            var saveLoadService = new FileSystemSaveLoadService("C:/CasinoData");

            // Создаем казино
            Casino casino = new Casino(saveLoadService);

            // Запускаем казино
            casino.StartGame();
        }
    }
}