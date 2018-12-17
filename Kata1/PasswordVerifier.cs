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
        int numberOfTrueConditions = 5;
        public bool Verify(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password", "password should not be null");
            }

            const int passwordMinLength = 9;
            if (password.Length < passwordMinLength)
            {
                numberOfTrueConditions--;
            }

            try
            {
                password.First((c) => Char.IsLower(c));              
            }
            catch(InvalidOperationException)
            {
                numberOfTrueConditions--;
            }
            try
            {
                password.First((c) => Char.IsUpper(c));
            }
            catch (InvalidOperationException)
            {
                numberOfTrueConditions--;
            }
            try
            {
                password.First((c) => Char.IsDigit(c));
            }
            catch (InvalidOperationException)
            {
                numberOfTrueConditions--;
            }

            return numberOfTrueConditions >= 3;
        }
    }
}
