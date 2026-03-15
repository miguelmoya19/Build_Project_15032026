using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.ValueObject
{
    public class Email
    {
        public string ValueEmail { get; }

        private Email() { }

        public Email(string value) { 
        
              if(string.IsNullOrWhiteSpace(value))
                throw new Exception("Email Vacio.");

            if (!value.Contains("@"))
            {
                throw new Exception("Email Invalido.");
            }

            ValueEmail = value;
         
        }

    }
}
