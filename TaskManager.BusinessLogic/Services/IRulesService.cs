using System.Collections.Generic;
using TaskManager.BusinessLogic.Models;

namespace TaskManager.BusinessLogic.Services
{
    public interface IRulesService
    {
        public List<RuleModel> GetRules();
    }
}
