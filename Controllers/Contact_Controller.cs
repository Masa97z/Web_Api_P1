using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;
using Web_Api_P1.Data;
using Web_Api_P1.Models;

namespace Web_Api_P1.Controllers
{
    [ApiController]
    [Route("api/Contact_Controller")]
    public class Contact_Controller : Controller
    {
        private readonly Contact_Api_Db dbcontext;

        public Contact_Controller(Contact_Api_Db dbcontext)
        {
            this.dbcontext = dbcontext;
        }



        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok( await dbcontext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContacts([FromRoute]int id)
        {
            var contact = await dbcontext.Contacts.FindAsync(id);
            if (contact == null)
                return NotFound();
            return Ok(contact);

        }


        [HttpPost]
        public async Task <IActionResult> AddNewContact(Add_Contact_Requist add_Contact_Requist)
        {
            var contact = new Contact()
            {
                Id = new int() ,
                Name = add_Contact_Requist.Name,
                Email = add_Contact_Requist.Email,
                Phone = add_Contact_Requist.Phone,
                City = add_Contact_Requist.City,
                Country = add_Contact_Requist.Country,
            };
           await dbcontext.Contacts.AddAsync(contact);
            await dbcontext.SaveChangesAsync();

            return Ok(contact);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContact(
            [FromRoute] int id,
            UpdateContact updateContact) 
        {
            var contact = await dbcontext.Contacts.FindAsync(id);
            if(contact != null)
            {
                contact.Name = updateContact.Name;
                contact.Email = updateContact.Email;
                contact.Phone = updateContact.Phone;
                contact.City = updateContact.City;
                contact.Country = updateContact.Country;
                await dbcontext.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContact([FromRoute]int id)
        {
            var contact = await dbcontext.Contacts.FindAsync(id);
            if (contact != null)
            {
                dbcontext.Contacts.Remove(contact);
                await dbcontext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();

        }
    }
}
