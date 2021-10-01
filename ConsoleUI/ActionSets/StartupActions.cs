using System.Collections.Generic;
using ConsoleUI.Framework;
using Spectre.Console;

namespace ConsoleUI.ActionSets
{
    public class StartupActions : UIAction
    {
        private readonly LoginAction loginAction;
        private readonly ExitAction exitAction;

        public StartupActions(IAnsiConsole console, LoginAction loginAction, ExitAction exitAction) : base("startup", console)
        {            
            this.loginAction = loginAction;
            this.exitAction = exitAction;
        }

        public override UIActionResult InvokeAction(List<IUIAction> elements)
        {
            return new UIActionResult(new List<IUIAction>(){loginAction, exitAction});
        }
    }
}