using SimpleMvvmToolkit.Express;
using System.Collections.Generic;
using TaskManager.BusinessLogic.Models;
using TaskManager.BusinessLogic.Services;

namespace TaskManager.BusinessLogic.ViewModels
{
    public class RulesViewModels : ModelBase<RulesViewModels>
    {
        private readonly IRulesService _rulesService;

        private List<RuleModel> _rules = new List<RuleModel>();
        public List<RuleModel> Rules
        {
            get { return _rules; }
            set
            {
                _rules = value;
                NotifyPropertyChanged(vm => vm.Rules);
            }
        }

        private List<RuleModel> ReturnProcesses(RulesViewModels vm)
        {
            return vm.Rules;
        }

        public RulesViewModels(IRulesService rulesService)
        {
            _rulesService = rulesService;
            GetRules();
        }

        private void GetRules()
        {
            Rules = _rulesService.GetRules();
        }
    }
}
