using System;
using System.Collections.Generic;
using ConsoleUI.Framework;
using Spectre.Console;
using API;

namespace ConsoleUI
{
    public class SignupAction : UIAction
    {
        LoginController _loginController;
        public SignupAction(IAnsiConsole console, LoginController loginController) : base(name: "Login", console)
        {
            _loginController = loginController;
        }

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
