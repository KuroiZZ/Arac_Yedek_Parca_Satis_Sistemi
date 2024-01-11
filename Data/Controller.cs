//220229026_HabilTataroğulları
using System;
using System.Text.RegularExpressions;

namespace Workspace
{    
    internal static class Controller
    {
        //Function that checks whether the id complies with the required rules
        internal static bool idController(string id)
        {
            if(id.Length > 4 && id.Length < 21)
            {
                string pattern = "^[a-zA-Z]+[a-zA-Z0-9]*$";
                Regex rg = new Regex(pattern);
                MatchCollection mc = rg.Matches(id);
                if(mc.Count == 1)
                {
                    return true;
                }

                return false;
            }
            return false;
            
        }
        
        //Function that checks whether the password complies with the required rules
        internal static bool passwordController(string password) 
        {
            if(password.Length > 7 && password.Length < 21)
            {
                string pattern = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%&*-+])(?!.*\\s)(?!.*[|]).*";
                Regex rg = new Regex(pattern);
                MatchCollection mc = rg.Matches(password);
                if(mc.Count == 1)
                {
                    return true;
                }

                return false;
            }
            return false;
            
        }

        //Function that checks whether the name complies with the required rules
        internal static bool nameController(string name) 
        {
            string pattern = "^[a-zA-Z\\s]+(?!.*\\W).*";
            Regex rg = new Regex(pattern);
            MatchCollection mc = rg.Matches(name);
            if(mc.Count == 1)
            {
                return true;
            }

            return false;
            
        }

        //Function that checks whether the mail complies with the required rules
        internal static bool mailController(string mail)
        {
            string pattern = "^[^\\W](?=.*[@])(?!.*[|]).*";
            Regex rg = new Regex(pattern);
            MatchCollection mc = rg.Matches(mail);
            if(mc.Count == 1)
            {
                return true;
            }

            return false;
            
        }
        
        //Function that checks whether the phone number complies with the required rules
        internal static bool phone_noController(string phone_no)
        {
            if(phone_no.Length == 12)
            {
                string pattern = "[^a-zA-z|]{3}[-][^a-zA-Z|]{3}[-][^a-zA-Z|]{4}";
                Regex rg = new Regex(pattern);
                MatchCollection mc = rg.Matches(phone_no);
                if(mc.Count == 1)
                {
                    return true;
                }

                return false;
            }
            return false;

            
        }
        
        //Function that checks if there are spaces in string
        internal static bool WhiteSpaceController(string dize)
        {   
            string pattern = "[\\s].*";
            Regex rg = new Regex(pattern);
            MatchCollection mc = rg.Matches(dize);
            if(mc.Count == 1)
            {
                return true;
            }

            return false;
        }
    }
}
