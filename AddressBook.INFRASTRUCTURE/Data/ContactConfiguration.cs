using AddressBook.DOMAIN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.INFRASTRUCTURE.Data
{
    public class ContactConfiguration: IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable( "Contacts"); // Set the table name
            builder.HasKey(c => c.ContactId); 

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);// Specify that the column is non-unicode

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(10);
            
        }
    }
}
