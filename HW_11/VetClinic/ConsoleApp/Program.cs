using VetClinic.Data;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1 - Добавить");
            Console.WriteLine("2 - Удалить");
            Console.WriteLine("3 - Редактировать");
            Console.WriteLine("4 - Показать все");
            Console.WriteLine("5 - Найти по id");

            switch (Console.ReadLine())
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    DeleteClient();
                    break;
                case "3":
                    EditClient();
                    break;
                case "4":
                    GetAllClients();
                    break;
                case "5":
                    GetClientById();
                    break;
            }



            Console.WriteLine("Нажмите на любую клавишу для завершения ");
            Console.ReadKey();
        }

        static void AddClient()
        {

        }

        static void DeleteClient()
        { 

        }

        static void EditClient()
        {

        }

        static void GetAllClients()
        {
            VetClinicClient vetClinicClient = new VetClinicClient("http://localhost:5133/", new HttpClient());
            List<Client> clients = vetClinicClient.ClientGetAllAsync().Result.ToList();

            foreach (Client client in clients)
            {
                Console.WriteLine("Фамилия: " + client.SurName);
                Console.WriteLine("Имя: " + client.FirstName);
                Console.WriteLine("Отчество: " + client.Patronymic);
                Console.WriteLine("Дата рождения: " + client.Birthday.DateTime);
                Console.WriteLine("Документ: " + client.Document);
                Console.WriteLine();
            }
        }

        static void GetClientById()
        {
            Console.Write("Введите id клиента: ");
            int id = int.Parse(Console.ReadLine());

            VetClinicClient vetClinicClient = new VetClinicClient("http://localhost:5133/", new HttpClient());

            try
            {
                Client client = vetClinicClient.ClientGetByIdAsync(id).Result;

                Console.WriteLine("Фамилия: " + client.SurName);
                Console.WriteLine("Имя: " + client.FirstName);
                Console.WriteLine("Отчество: " + client.Patronymic);
                Console.WriteLine("Дата рождения: " + client.Birthday.DateTime);
                Console.WriteLine("Документ: " + client.Document);
            }
            catch
            {
                Console.WriteLine("Клиент с таким id не найден");
            }
        }

    }
}
