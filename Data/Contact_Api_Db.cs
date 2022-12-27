using Microsoft.EntityFrameworkCore;
using Web_Api_P1.Models;

namespace Web_Api_P1.Data
{
    public class Contact_Api_Db : DbContext
    {
        public Contact_Api_Db(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
