using AddressBook.DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.INFRASTRUCTURE.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }
        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            return await _context.Contacts.FindAsync(contactId);
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string searchTerm)
        {
            return await _context.Contacts
                .Where(c => c.Name.Contains(searchTerm) || c.Phone.Contains(searchTerm))
                .ToListAsync();
        }
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
