using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace PresentlyServer.Dtos
{
    public class UserRegistrate
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Password { get; set; }

        private byte[] hash;
        private byte[] salt;
        public UserRegistrate() { }

        public void SetPassword(string password)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);
            this.salt = salt;
            this.hash = this.HashPassword(password);
        }

        private byte[] HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(this.salt + password));
        }

        public bool CheckPassword(string password)
        {
            return StructuralComparisons.StructuralEqualityComparer.Equals(this.HashPassword(password), this.hash);
        }

        public byte[] GetSalt()
        {
            return this.salt;
        }

        public byte[] GetHash()
        {
            return this.hash;
        }

    }
}
