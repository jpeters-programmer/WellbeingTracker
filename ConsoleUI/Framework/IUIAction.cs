using System.Collections.Generic;

namespace ConsoleUI.Framework
{
    public interface IUIAction
    {
        string Name { get; set; }

        UIActionResult InvokeAction(List<IUIAction> elements);
    }
}