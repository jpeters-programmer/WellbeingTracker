using System;
using System.Collections.Generic;
using ConsoleUI.Framework;
using Spectre.Console;

namespace ConsoleUI
{
    public class ExitAction : UIAction
    {
        public ExitAction(IAnsiConsole console) : base(name: "Exit", console)  {}

        public override UIActionResult InvokeAction(List<IUIAction> elements)
        {                                    
            return new UIActionResult(new List<IUIAction>());
        }
                
    }
}
