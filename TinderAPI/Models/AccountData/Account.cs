using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.AccountData
{
    public class Account
    {
        [JilDirective("account_email")]
        public string Email { get; protected set; }
        [JilDirective("is_email_verified")]
        public bool IsEmailVerified { get; protected set; }
    }
}
