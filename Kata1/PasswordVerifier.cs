using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A class for password verifications.
    class PasswordVerifier
    {
        public bool Verify(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password", "password should not be null");
            }

            const int passwordMinLength = 9;
            if (password.Length < passwordMinLength)
            {
                throw new ArgumentException("password should be larger than 8 chars");
            }

            try
            {
                password.First((c) => Char.IsLower(c));              
            }
            catch(InvalidOperationException)
            {
                throw new ArgumentException("password should have one lowercase letter at least");
            }
            try
            {
                password.First((c) => Char.IsUpper(c));
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("password should have one uppercase letter at least");
            }
            try
            {
                password.First((c) => Char.IsDigit(c));
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("password should have one number at least");
            }
           
            return true;
        }
    }
}
