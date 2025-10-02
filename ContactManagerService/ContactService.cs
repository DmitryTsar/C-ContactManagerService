using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace ContactManagerService
{
    public class ContactService : IContactService
    {
        private static List<Contact> _contacts = new List<Contact>();
        private static readonly string logFile = "service_log.txt";

        private void Log(string message)
        {
            File.AppendAllText(logFile, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }

        public void AddContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Email) || !contact.Email.Contains("@"))
                throw new ArgumentException("Некорректный email");

            _contacts.Add(contact);
            Log($"Добавлен контакт: {contact.Email}");
        }

        public Contact GetContact(string email)
        {
            var contact = _contacts.FirstOrDefault(c => c.Email == email);
            Log($"Запрос контакта: {email}");
            return contact;
        }

        public List<Contact> GetAllContacts()
        {
            Log("Запрос всех контактов");
            return _contacts;
        }

        public void UpdateContact(Contact contact)
        {
            var existing = _contacts.FirstOrDefault(c => c.Email == contact.Email);
            if (existing != null)
            {
                existing.Name = contact.Name;
                existing.Phone = contact.Phone;
                Log($"Обновлён контакт: {contact.Email}");
            }
        }

        public void DeleteContact(string email)
        {
            var contact = _contacts.FirstOrDefault(c => c.Email == email);
            if (contact != null)
            {
                _contacts.Remove(contact);
                Log($"Удалён контакт: {email}");
            }
        }
    }
}
