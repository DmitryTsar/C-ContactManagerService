using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ContactManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        void AddContact(Contact contact);

        [OperationContract]
        Contact GetContact(string email);

        [OperationContract]
        List<Contact> GetAllContacts();

        [OperationContract]
        void UpdateContact(Contact contact);

        [OperationContract]
        void DeleteContact(string email);
    }

    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }
    }
}
