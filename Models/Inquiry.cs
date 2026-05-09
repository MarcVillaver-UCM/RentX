using System;

namespace RentXpress.Models
{
    public class Inquiry
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public bool IsEmergency { get; set; }
        public string PriorityLevel { get; set; }
        // NEW CODE
        // These fields extend the existing inquiry into a lightweight booking request.
        // The app does not have a separate Booking model/table, so keeping this data on
        // Inquiry preserves the current structure while storing payment and total details.
        public decimal BasePrice { get; set; }
        public decimal SurchargeAmount { get; set; }
        public decimal TotalPrice { get; set; }
        // NEW CODE
        // NumberOfDays stores the renter's requested duration. TotalAmount mirrors the
        // final amount saved to the database for booking summaries and payment screens.
        public int NumberOfDays { get; set; } = 1;
        public decimal TotalAmount { get; set; }
        // NEW CODE
        // PlatformFee is RentXpress's earning. OwnerAmount is what the company receives.
        public decimal PlatformFee { get; set; }
        public decimal OwnerAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        // NEW CODE
        // Renters submit proof/reference first; owners confirm it before payment becomes paid.
        public string PaymentReference { get; set; }
        public int PaymentConfirmedBy { get; set; }
        public DateTime? PaymentConfirmedAt { get; set; }
        // NEW CODE
        // Owner payment details are copied into conversation data for payment screens.
        public string OwnerGCashNumber { get; set; }
        public string OwnerGCashName { get; set; }
        public string OwnerBankName { get; set; }
        public string OwnerBankAccountNumber { get; set; }
        public string OwnerBankAccountName { get; set; }
        public DateTime CreatedAt { get; set; }

        // MODIFIED CODE
        // "Urgent Booking" replaces the older catastrophe/emergency wording in user-facing text.
        public string PriorityDisplay => IsEmergency ? $"Urgent Booking - {PriorityLevel.ToUpper()}" : PriorityLevel;
    }
}

