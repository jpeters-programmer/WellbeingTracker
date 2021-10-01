using System;
using System.Collections.Generic;
using API;
using ConsoleUI.Framework;
using Spectre.Console;
using ConsoleUI.SpectreUtils;

namespace ConsoleUI.Trackables
{
    public class CreateTrackable : UIAction
    {
        private readonly TrackableController _controller;

        public CreateTrackable(IAnsiConsole console, TrackableController controller) : base("Create Trackable", console)
        {
            _controller = controller;
        }      

        public override UIActionResult InvokeAction(List<IUIAction> elements)
        {
            var name = _console.Ask<string>("name?");
            var fieldType = _console.GetOneOf("Field Type", _controller.GetFieldTypes());    
            return new UIActionResult(elements);
        }
    }
}