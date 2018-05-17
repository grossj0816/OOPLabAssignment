using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOPLab2.Models
{
    public class BrokenRules
    {
        //list of broken rules
        Dictionary<string, string> brokenRules = new Dictionary<string, string>();

        //we want a count to count how many
        //rules were broken
        public int Count()
        {
            return brokenRules.Count();
        }

        public void AddRule(string key, string value)
        {
            if (!brokenRules.ContainsKey(key))
            {
                brokenRules.Add(key, value);
            }
        }

        public void RemoveRule(string key)
        {
            if (brokenRules.ContainsKey(key))
            {
                brokenRules.Remove(key);
            }
        }

        public List<string> ListErrors()
        {
            List<string> errors = new List<string>();

            foreach (var e in brokenRules)
            {
                errors.Add(e.Key.ToString() + ": " + e.Value.ToString());
            }

            return errors;
        }
    }
}