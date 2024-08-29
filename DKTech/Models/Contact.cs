using DKTech.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace DKTech.Models

{
    public class Contact
    {
        public int ContactID { get; set; }
        // user ID from AspNetUser table.
        public string? OwnerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public ContactStatus Status { get; set; }
    }

    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
    public static void SeedData(DKTechContext context, string adminID)
    {
        if (context.Contact.Any())
        {
            return;   // DB has been seeded
        }

        context.Contact.AddRange(
            new Contact
            {
                Name = "Dexter Ku",
                Address = "1234 Dale St",
                City = "Auckland",
                State = "Auckland",
                Zip = "10999",
                Email = "ac116595@avcol.school.nz",
                Status = ContactStatus.Approved,
                OwnerID = adminID
            });
    }
}


