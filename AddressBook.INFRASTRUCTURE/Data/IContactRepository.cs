using AddressBook.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.INFRASTRUCTURE.Data
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContactByIdAsync(int contactId);
        Task<IEnumerable<Contact>> SearchContactsAsync(string searchTerm);
        Task<Contact> AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int contactId);
    }
}
