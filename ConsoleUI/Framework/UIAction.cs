using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using API;

namespace ConsoleUI.Framework
{
    public abstract class UIAction : IUIAction
    {
        protected IAnsiConsole _console;

        protected UIAction(string name, IAnsiConsole console)
        {
            Name = name;
            _console = console;
        }
        public string Name { get; set; }
        public abstract UIActionResult InvokeAction(List<IUIAction> elements);

    }
}