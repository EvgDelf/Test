using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MDivination.Models
{
    public class Generator
    {
        public static Random random = new Random();
        public int RandomNumber = random.Next(0, 3);

       
        public int Generate()
        {
            return RandomNumber;
        }

    }
}
