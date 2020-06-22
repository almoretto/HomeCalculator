using Bridge;
using Newtonsoft.Json;
using System;
using Bridge.Html5;
using Bridge.Utils;
namespace HomeConstructionCalculator
{
    public class App
    {
        public static void Main()
        {
            var div = new HTMLDivElement();

            var input = new HTMLInputElement()
            {
                Id = "number",
                Type = InputType.Text,
                Placeholder = "Enter a number to store...",
                Style =
        {
            Margin = "5px"
        }
            };

            var buttonSave = new HTMLButtonElement()
            {
                Id = "b",
                InnerHTML = "Save"
            };

            var buttonRestore = new HTMLButtonElement()
            {
                Id = "r",
                InnerHTML = "Restore",
                Style =
        {
            Margin = "5px"
        }
            };

            div.AppendChild(input);
            div.AppendChild(buttonSave);
            div.AppendChild(buttonRestore);
        }
    }
}