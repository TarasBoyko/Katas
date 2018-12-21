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
        // If @password is valid returns true,
        // otherwise returns false.
        // @password specifies a password for verification.
        public bool Verify(string password)
        {
            try
            {
                password.First((c) => Char.IsLower(c));
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            // Already 2 conditions are true.

            const int passwordMinLength = 9;
            List<Func<string, bool>> partOfConditions = new List<Func<string, bool>>
            {
                { (str) => { return str.Length >= passwordMinLength; }},
                { (str) =>
                    {
                        try
                            {
                                str.First((c) => Char.IsDigit(c));
                            }
                        catch (InvalidOperationException)
                        {
                            return false;
                        }
                        return true;
                    }
                },
                { (str) =>
                    {
                        try
                            {
                                str.First((c) => Char.IsUpper(c));
                            }
                        catch (InvalidOperationException)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            };

            // If at least one with other conditions is true,
            // than @password is valid,
            // otherwise @password is invalid.
            foreach (Func<string, bool> predicate in partOfConditions)
            {
                if (predicate(password))
                {
                    return true;
                }
            }

            return false;
        } // Verify
    } // PasswordVerifier
} // Kata1
