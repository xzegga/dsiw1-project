using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WAMiCafesitoApp.Services
{
    public static class Validator
    {
        // Validar dirección de correo electrónico
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regular expression for validating email address
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Validar cadena genérica (nombre, apellido, etc.)
        public static bool ValidateString(string input, int minLength = 1, int maxLength = 100)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input.Length < minLength || input.Length > maxLength)
                return false;

            // Expresión regular para validar nombres con caracteres Unicode
            string namePattern = @"^[\p{L}\s'-]+$";
            return Regex.IsMatch(input, namePattern);
        }

        // Validar contraseña y confirmación de contraseña
        public static bool ValidatePassword(string password, string confirmPassword, int minLength = 8)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                return false;

            if (password.Length < minLength)
                return false;

            // Check if passwords match
            if (password != confirmPassword)
                return false;

            // Expresión regular para la validación de contraseñas (al menos un número, una letra minúscula y una letra mayúscula)
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
            return Regex.IsMatch(password, passwordPattern);
        }

        // Validar número (entero o de punto flotante)
        public static bool ValidateNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return false;

            // Regular expression for validating number
            string numberPattern = @"^-?\d+(\.\d+)?$";
            return Regex.IsMatch(number, numberPattern);
        }

        // Validar fecha
        public static bool ValidateDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return false;

            // Try to parse the date string
            return DateTime.TryParse(date, out _);
        }

        // Validar número de teléfono con formato de El Salvador
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Expresión regular para validar número de teléfono de El Salvador
            string phoneNumberPattern = @"^(\+?503)?\d{8}$"; // Formato: (opcional "+503")xxxxxxxx
            return Regex.IsMatch(phoneNumber, phoneNumberPattern);
        }
    }
}