-- RentXpress Database Schema
-- Compatible with XAMPP MySQL
-- Run this in phpMyAdmin or MySQL CLI

CREATE DATABASE IF NOT EXISTS rentxpress;
USE rentxpress;

-- Users Table
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    phone VARCHAR(20),
    password_hash VARCHAR(255) NOT NULL,
    account_type ENUM('personal', 'company') DEFAULT 'personal',
    company_name VARCHAR(150),
    -- NEW CODE
    -- Company payout details. Renters use these inside chat when paying by GCash or bank transfer.
    gcash_number VARCHAR(50) DEFAULT '',
    gcash_name VARCHAR(150) DEFAULT '',
    bank_name VARCHAR(150) DEFAULT '',
    bank_account_number VARCHAR(80) DEFAULT '',
    bank_account_name VARCHAR(150) DEFAULT '',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Vehicles Table
CREATE TABLE IF NOT EXISTS vehicles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    owner_id INT NOT NULL,
    name VARCHAR(150) NOT NULL,
    type VARCHAR(50) NOT NULL,          -- Sedan, SUV, Electric, Truck, etc.
    fuel_type VARCHAR(50) DEFAULT 'Gasoline',
    transmission VARCHAR(50) DEFAULT 'Automatic',
    seats INT DEFAULT 5,
    price_per_day DECIMAL(10,2) NOT NULL,
    rating DECIMAL(3,2) DEFAULT 0.00,
    review_count INT DEFAULT 0,
    status ENUM('available', 'rented', 'maintenance') DEFAULT 'available',
    tags VARCHAR(255),                  -- comma-separated tags
    description TEXT,
    -- NEW CODE
    -- Current/base location shown to renters before booking.
    current_location VARCHAR(255) DEFAULT '',
    image_path VARCHAR(255),
    image_data LONGBLOB,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (owner_id) REFERENCES users(id) ON DELETE CASCADE
);

-- Inquiries Table
CREATE TABLE IF NOT EXISTS inquiries (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_id INT NOT NULL,
    vehicle_id INT NOT NULL,
    owner_id INT NOT NULL,
    subject VARCHAR(255) NOT NULL,
    message TEXT NOT NULL,
    status ENUM('pending', 'replied', 'closed') DEFAULT 'pending',
    -- MODIFIED CODE
    -- Urgent Booking replaces the old catastrophe wording. It still uses the same flag
    -- so existing code/data remains backward compatible.
    is_emergency TINYINT(1) DEFAULT 0,
    priority_level ENUM('normal', 'high', 'critical') DEFAULT 'normal',
    -- NEW CODE
    -- Booking/payment details are stored with the inquiry because this app currently
    -- treats each inquiry as the renter's booking request.
    base_price DECIMAL(10,2) DEFAULT 0,
    surcharge_amount DECIMAL(10,2) DEFAULT 0,
    total_price DECIMAL(10,2) DEFAULT 0,
    -- NEW CODE
    -- number_of_days is required by the booking form. total_amount stores the final
    -- renter-facing amount saved with the request for chat/payment summaries.
    number_of_days INT DEFAULT 1,
    total_amount DECIMAL(10,2) DEFAULT 0,
    -- NEW CODE
    -- platform_fee is RentXpress's earning. owner_amount is paid to the company.
    platform_fee DECIMAL(10,2) DEFAULT 0,
    owner_amount DECIMAL(10,2) DEFAULT 0,
    payment_method VARCHAR(50) DEFAULT 'Cash',
    payment_status VARCHAR(50) DEFAULT 'Pending',
    -- NEW CODE
    -- Renter-submitted proof/reference. Owner confirmation is required before status becomes paid.
    payment_reference VARCHAR(255) DEFAULT '',
    payment_confirmed_by INT NULL,
    payment_confirmed_at DATETIME NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (sender_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (vehicle_id) REFERENCES vehicles(id) ON DELETE CASCADE,
    FOREIGN KEY (owner_id) REFERENCES users(id) ON DELETE CASCADE
);

-- Inquiry Replies Table
CREATE TABLE IF NOT EXISTS inquiry_replies (
    id INT AUTO_INCREMENT PRIMARY KEY,
    inquiry_id INT NOT NULL,
    sender_id INT NOT NULL,
    message TEXT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (inquiry_id) REFERENCES inquiries(id) ON DELETE CASCADE,
    FOREIGN KEY (sender_id) REFERENCES users(id) ON DELETE CASCADE
);

-- Sample Data - Users
INSERT INTO users (first_name, last_name, email, phone, password_hash, account_type) VALUES
('John', 'Doe', 'john@example.com', '+1 (555) 000-0001', MD5('password123'), 'personal'),
('Jane', 'Smith', 'jane@example.com', '+1 (555) 000-0002', MD5('password123'), 'company'),
('Admin', 'User', 'admin@rentxpress.com', '+1 (555) 000-0000', MD5('admin123'), 'company');

-- Sample Data - Vehicles
INSERT INTO vehicles (owner_id, name, type, fuel_type, transmission, seats, price_per_day, rating, review_count, status, tags, description) VALUES
(2, 'Toyota Camry', 'Sedan', 'Hybrid', 'Automatic', 5, 65.00, 4.8, 4200, 'available', 'Fuel Efficient,Popular', 'Comfortable and efficient sedan perfect for city and highway driving.'),
(2, 'Honda CR-V', 'SUV', 'Gasoline', 'Automatic', 7, 85.00, 4.7, 4200, 'available', 'Best for Families,Large Baggage', 'Spacious SUV with plenty of room for the whole family.'),
(2, 'Tesla Model 3', 'Electric', 'Electric', 'Automatic', 5, 120.00, 4.9, 4200, 'available', 'Eco-Friendly,Premium', 'All-electric premium sedan with autopilot capabilities.'),
(3, 'Ford Explorer', 'SUV', 'Gasoline', 'Automatic', 7, 95.00, 4.6, 3100, 'available', 'Best for Families,Adventure Ready', 'Rugged SUV great for family adventures and off-road trips.'),
(3, 'BMW 5 Series', 'Sedan', 'Gasoline', 'Automatic', 5, 150.00, 4.8, 2800, 'available', 'Premium,Business Class', 'Luxury business sedan with top-notch comfort and performance.'),
(2, 'Toyota Yaris', 'Hatchback', 'Gasoline', 'Manual', 5, 45.00, 4.5, 1900, 'available', 'Budget Friendly,City Car', 'Compact and easy to park, ideal for city commuting.');

-- Run this once if your existing vehicles table was created before image uploads were added.
-- ALTER TABLE vehicles ADD COLUMN image_data LONGBLOB NULL AFTER image_path;




