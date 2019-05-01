
using System;
using System.IO;
using System.Security;

namespace DocumentationSamplesCS
{
    static class OpenFile
    {
        // This example contains different ways of opening an Xtractor input
        // file and how to handle passwords.
        public static void Example()
        {
            // Open a file from disk.
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.pdf"))
            {
                // Perform your extractions here.
                Console.WriteLine("Successfully opened Xtractor.Input.pdf with Xtractor.");
            }

            //Open a file from memory.
            byte[] examplePDF = File.ReadAllBytes(@"..\..\..\Input\Xtractor.Input.pdf");
            using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(file: examplePDF))
            {
                // Perform your extractions here.
                Console.WriteLine("Successfully opened Xtractor.Input.pdf with Xtractor as a byte array.");
            }

            // Open a file with a password from disk.
            using (SecureString password = new SecureString())
            {
                // We recommend never storing secure data like a password in a
                // 'string', however we will here for simplicity.
                string insecurePassword = "userpass";
                foreach (char c in insecurePassword)
                {
                    password.AppendChar(c);
                }
                password.MakeReadOnly();
                using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.Secure.pdf", password: password))
                {
                    // Perform your extractions here.
                    Console.WriteLine("Successfully opened Xtractor.Input.Secure.pdf with Xtractor and input password.");
                }
            }

            // Open a file with a password from memory.
            examplePDF = File.ReadAllBytes(@"..\..\..\Input\Xtractor.Input.Secure.pdf");
            using (SecureString password = new SecureString())
            {
                string insecurePassword = "userpass";
                foreach (char c in insecurePassword)
                {
                    password.AppendChar(c);
                }
                password.MakeReadOnly();

                using (Xtractor.Xtractor xtractor = new Xtractor.Xtractor(file: examplePDF, password: password))
                {
                    // Perform your extractions here.
                    Console.WriteLine("Successfully opened Xtractor.Input.Secure.pdf with Xtractor as a byte array using a password.");
                }
            }

            // Handle an invalid password.
            // We aren't using a 'using' block here, like most other examples.
            // Since the runtime expands 'using' into a try/finally pattern anyway, we'll
            // manually expand it so we can add in a 'catch' as well.
            {
                Xtractor.Xtractor xtractor = null;
                try
                {
                    string password = "incorrect password";
                    SecureString securePassword = new SecureString();
                    foreach (char c in password)
                    {
                        securePassword.AppendChar(c);
                    }
                    securePassword.MakeReadOnly();

                    xtractor = new Xtractor.Xtractor(filename: @"..\..\..\Input\Xtractor.Input.Secure.pdf", password: securePassword);

                    // Perform your extractions here.
                    Console.WriteLine("Successfully opened Xtractor.Input.pdf with Xtractor.");
                }
                catch (Xtractor.InvalidPasswordException)
                {
                    // Handle the error here.
                    Console.WriteLine("InvalidPasswordException caught opening Xtractor.Input.Secure.pdf");
                }
                finally
                {
                    xtractor?.Dispose();
                }
            }
        }
    }
}
