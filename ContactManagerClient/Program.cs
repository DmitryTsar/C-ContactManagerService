using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerClient.ContactServiceReference;

namespace ContactManagerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ContactServiceClient();

            Console.WriteLine("=== Тест WCF Contact Manager ===");

            // 1. Добавим контакт
            var contact = new Contact
            {
                Name = "Иван Иванов",
                Email = "ivan@example.com",
                Phone = "+37529121212"
            };

            client.AddContact(contact);
            Console.WriteLine($"Добавлен контакт: {contact.Name} - {contact.Email}");

            // 2. Получим все контакты
            Console.WriteLine("\nСписок всех контактов:");
            var all = client.GetAllContacts();
            foreach (var c in all)
            {
                Console.WriteLine($"{c.Name} | {c.Email} | {c.Phone}");
            }

            // 3. Обновим контакт
            contact.Phone = "+375292323232";
            client.UpdateContact(contact);
            Console.WriteLine($"\nКонтакт {contact.Email} обновлён!");

            // 4. Получим один контакт
            var single = client.GetContact("ivan@example.com");
            Console.WriteLine($"Детали: {single.Name} | {single.Email} | {single.Phone}");

            // 5. Удалим контакт
            client.DeleteContact("ivan@example.com");
            Console.WriteLine("\nКонтакт удалён.");

            // Проверим, что список пуст
            Console.WriteLine("\nСписок после удаления:");
            all = client.GetAllContacts();
            if (all.Length == 0)
                Console.WriteLine("Контактов нет.");
            else
                foreach (var c in all)
                    Console.WriteLine($"{c.Name} | {c.Email} | {c.Phone}");

            client.Close();
            Console.WriteLine("\nТест завершён.");
            Console.ReadLine();
        }
    }
}
