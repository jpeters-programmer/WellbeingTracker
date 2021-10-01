using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace ConsoleUI.SpectreUtils
{
    static class IAnsiConsoleExtensions
    {
         #region "styling"
        private static Style selectHighlight = new Style().Foreground(Color.Aqua);
        private static string selectColor = "[aqua]";
        //private static string fieldColor = "[lime]";
        private static string promptColor = "[yellow]";
        private static string subduedColor = "[grey]";
        private static string moreChoicesText = $"[{subduedColor}](Move up and down to reveal more options)[/]";
        
        #endregion
        
        public static TResult GetOneOf<TResult>(this IAnsiConsole console, string itemName, IEnumerable<TResult> items) where TResult: notnull {           
            var selectedItem = console.Prompt(
               new SelectionPrompt<TResult>()
                   .Title($"Select a {selectColor}{itemName}[/]")
                   .PageSize(10)
                   .HighlightStyle(selectHighlight)
                   .MoreChoicesText(moreChoicesText)                   
                   .AddChoices(items)
                   );

            return selectedItem;
        }

        public static void NotifyError(this IAnsiConsole console, string member, Exception ex) {
            console.WriteLine($"Something went wrong with {member}: {promptColor}{ex.Message}[/]");
            if (console.Confirm("Would you like to see details?", defaultValue: false))
            {
                console.WriteException(ex);
            }
        }
    }
}