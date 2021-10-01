using System.Collections.Generic;

namespace ConsoleUI.Framework
{
    public class UIActionResult
    {
        public UIActionResult(List<IUIAction> elements)
        {
            Actions = elements;
        }
        public List<IUIAction> Actions {get;set;}
    }
}