using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasData(
                new Ticket
                {
                    Id = 1,
                    CreationDate = DateTime.UtcNow.AddMinutes(-10),
                    PhoneNumber = "01234567890",
                    Governorate = "Cairo",
                    City = "Nasr City",
                    District = "District 1",
                    Status = TicketStatus.New
                },
                new Ticket
                {
                    Id = 2,
                    CreationDate = DateTime.UtcNow.AddMinutes(-20),
                    PhoneNumber = "09876543210",
                    Governorate = "Giza",
                    City = "Dokki",
                    District = "District 2",
                    Status = TicketStatus.New
                },
                new Ticket
                {
                    Id = 3,
                    CreationDate = DateTime.UtcNow.AddMinutes(-40),
                    PhoneNumber = "01112223344",
                    Governorate = "Alexandria",
                    City = "Sidi Gaber",
                    District = "District 3",
                    Status = TicketStatus.New
                }
            );
        }

    }
}