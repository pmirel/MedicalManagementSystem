using System;

namespace ExpensesLab2.Models.Account
{
    public class Token
    {
        public string Value { get; set; }

        public DateTime Expiry { get; set; }

        public string Email { get; set; }
    }
}
