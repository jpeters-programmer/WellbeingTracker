using System;
using System.Collections.Generic;
using ConsoleUI.Framework;
using Spectre.Console;

namespace ConsoleUI
{
    public class LoginAction : UIAction
    {
        public LoginAction(IAnsiConsole console) : base(name: "Login", console)  {}

        public override UIActionResult InvokeAction(List<IUIAction> elements)
        {
            var name = _console.Ask<string>("Enter [green]username[/]: ");
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]password[/]")
                    .PromptStyle("red")
                    .Secret());
            
            
            return new UIActionResult(elements); 
        }
                
    }
}
