using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TaskManager.BusinessLogic.Models;

namespace TaskManager.BusinessLogic.Services
{
    class RulesService : IRulesService
    {
        public List<RuleModel> GetRules()
        {
            using StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + @"\Models\DefaultRules.json");
            string json = r.ReadToEnd();
            List<RuleModel> rules = JsonConvert.DeserializeObject<List<RuleModel>>(json);
            return rules;
        }
    }
}
