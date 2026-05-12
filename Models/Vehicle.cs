using System;

namespace RentXpress.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        // NEW CODE
        // These owner payment fields travel with a listed vehicle so the renter can see
        // where to pay after opening chat/payment for that vehicle.
        public string OwnerGCashNumber { get; set; }
        public string OwnerGCashName { get; set; }
        public string OwnerBankName { get; set; }
        public string OwnerBankAccountNumber { get; set; }
        public string OwnerBankAccountName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int Seats { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public string Status { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        // NEW CODE
        // CurrentLocation tells renters where the vehicle is based or available.
        public string CurrentLocation { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime CreatedAt { get; set; }

        public string PriceDisplay => $"PHP {PricePerDay:F0}/day";
        public string RatingDisplay => $" {Rating:F1} ({ReviewCount / 1000.0:F1}k reviews)";
    }
}



