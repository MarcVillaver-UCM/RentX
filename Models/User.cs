using System;

namespace RentXpress.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountType { get; set; }
        public string CompanyName { get; set; }
        // NEW CODE
        // Company payment details are stored on the company user because vehicles already
        // reference their owner through owner_id. This lets renters see payment details
        // without creating a separate payment-profile system.
        public string GCashNumber { get; set; }
        public string GCashName { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public DateTime CreatedAt { get; set; }

        // NEW CODE
        // Company accounts cannot list vehicles or receive rental payments until every
        // payment field is complete. Personal accounts do not need these fields.
        public bool HasCompanyPaymentDetails =>
            AccountType != "company" ||
            (!string.IsNullOrWhiteSpace(GCashNumber) &&
             !string.IsNullOrWhiteSpace(GCashName) &&
             !string.IsNullOrWhiteSpace(BankName) &&
             !string.IsNullOrWhiteSpace(BankAccountNumber) &&
             !string.IsNullOrWhiteSpace(BankAccountName));

        public override string ToString() => FullName;
    }
}

