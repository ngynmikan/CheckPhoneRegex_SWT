using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckPhoneRegex.Models
{
    public class PhoneNumber
    {
        private string countryCode { get; set; }
        private string areaCode { get; set; }
        private string number { get; set; }

        public PhoneNumber() { }

        public PhoneNumber(string countryCode, string areaCode, string number)
        {
            this.countryCode = countryCode;
            this.areaCode = areaCode;
            this.number = number;
        }

        public string ToString()
        {
            return this.countryCode + "|" + this.areaCode + "|" + this.number;
        }

        public static string checkPhoneRegex(PhoneNumber validPhoneNumber)
        {
            string pattern = @"^(?:\+?84|0)(?:\d){9,10}$";
            Regex regex = new Regex(pattern);

           if (regex.IsMatch(validPhoneNumber.number))
            {
                return validPhoneNumber.number + " is valid phone number";
            }
           else
            {
                return validPhoneNumber.number + " is not valid phone number";
            }
        }

        public string GetCountryCode() { return this.countryCode; }
        public string GetAreaCode() {  return this.areaCode; }
        public string GetNumber() { return this.number; }

    }
}
