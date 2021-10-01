using System.Collections.Generic;
using System.Linq;
using ConsoleUI.Framework;
using Spectre.Console;
using ConsoleUI.SpectreUtils;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public class Root
    {
        private IAnsiConsole _console;
        private readonly ActionSets.StartupActions startupActions;        

        public Root(IAnsiConsole console, ActionSets.StartupActions startupActions)
        {
            _console = console;
            this.startupActions = startupActions;
        }
              
        public void Run() {                       
            var actions = new List<IUIAction>();
            actions.Add(startupActions);
            
            while (actions.Count > 0) {
                IUIAction action;
                if (actions.Count == 1) {
                    action = actions[0];
                } else {
                    action = _console.GetOneOf("action", actions);
                }                
                try
                {
                   actions = action.InvokeAction(actions).Actions;
                }
                catch (Exception ex)
                {
                    _console.NotifyError(action.Name, ex);
                }
            }
        }               
    }
}