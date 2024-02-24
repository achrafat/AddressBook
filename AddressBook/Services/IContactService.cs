namespace AddressBook.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(int contactId);
        Task<IEnumerable<ContactDTO>> SearchContactsAsync(string searchTerm);
        Task<ContactDTO> AddContactAsync(ContactCreateDTO contactDTO);
        Task UpdateContactAsync(ContactDTO contactDTO);
        Task DeleteContactAsync(int contactId);
    }
}
