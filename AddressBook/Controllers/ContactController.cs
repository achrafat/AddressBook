using AddressBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactService.GetContactsAsync();
            return Ok(contacts);
        }
      

        [HttpGet("search")]
        public async Task<IActionResult> SearchContacts([FromQuery] string searchTerm)
        {
            var contacts = await _contactService.SearchContactsAsync(searchTerm);
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactCreateDTO contactDTO)
        {
            var createdContactId = await _contactService.AddContactAsync(contactDTO);

            return RedirectToAction("GetContacts");
        }

        [HttpPut("{contactId}")]
        public async Task<IActionResult> UpdateContact(int contactId, [FromBody] ContactDTO contactDTO)
        {
            if (contactId != contactDTO.ContactId)
            {
                return BadRequest();
            }

            await _contactService.UpdateContactAsync(contactDTO);
            return NoContent();
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            await _contactService.DeleteContactAsync(contactId);
            return NoContent();
        }
       
    }
}
