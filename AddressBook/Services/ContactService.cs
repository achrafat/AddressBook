using AddressBook.DOMAIN;
using AddressBook.INFRASTRUCTURE.Data;

namespace AddressBook.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ContactDTO>> GetContactsAsync()
        {
            var contacts = await _contactRepository.GetContactsAsync();
            return contacts.Select(MapToContactDTO);
        }
        public async Task<ContactDTO> GetContactByIdAsync(int contactId)
        {
            var contact = await _contactRepository.GetContactByIdAsync(contactId);
            return MapToContactDTO(contact);
        }

        public async Task<IEnumerable<ContactDTO>> SearchContactsAsync(string searchTerm)
        {
            var contacts = await _contactRepository.SearchContactsAsync(searchTerm);
            return contacts.Select(MapToContactDTO);
        }

        public async Task<ContactDTO> AddContactAsync(ContactCreateDTO contactDTO)
        {

            var contact = MapToContactEntityCreate(contactDTO);
            var createdContact = await _contactRepository.AddContactAsync(contact);

            // Return the created ContactDTO with the actual ContactId
            return MapToContactDTO(createdContact);
        }

        public async Task UpdateContactAsync(ContactDTO contactDTO)
        {
            var contact = MapToContactEntity(contactDTO);
            await _contactRepository.UpdateContactAsync(contact);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            await _contactRepository.DeleteContactAsync(contactId);
        }
       

        // Mapping methods...

        private ContactDTO MapToContactDTO(Contact contact)
        {
            return new ContactDTO
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone
            };
        }

        private Contact MapToContactEntity(ContactDTO contactDTO)
        {
            return new Contact
            {
                ContactId= contactDTO.ContactId,
                Name = contactDTO.Name,
                Email = contactDTO.Email,
                Phone = contactDTO.Phone
            };
        }
        private Contact MapToContactEntityCreate(ContactCreateDTO contactDTO)
        {
            return new Contact
            {
                Name = contactDTO.Name,
                Email = contactDTO.Email,
                Phone = contactDTO.Phone
            };
        }
    }
}
