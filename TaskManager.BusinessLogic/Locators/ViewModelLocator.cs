using SimpleInjector;
using TaskManager.BusinessLogic.ViewModels;
using TaskManager.BusinessLogic.Services;

namespace TaskManager.BusinessLogic.Locators
{
    public class ViewModelLocator
    {
        private Container _container;

        public ProcessesViewModels ProcessesViewModel => _container.GetInstance<ProcessesViewModels>();
        public RulesViewModels RulesViewModels => _container.GetInstance<RulesViewModels>();

        public ViewModelLocator()
        {
            _container = new Container();
            Bootstrap();
        }

        private void Bootstrap()
        {
            _container.Register<IProcessesService, ProcessesService>(Lifestyle.Transient);
            _container.Register<IRulesService, RulesService>(Lifestyle.Transient);

            _container.Register<ProcessesViewModels>(Lifestyle.Transient);
            _container.Register<RulesViewModels>(Lifestyle.Transient);
        }
    }
}
