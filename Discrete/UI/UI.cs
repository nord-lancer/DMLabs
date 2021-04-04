using System;
using System.Collections.Generic;

namespace  Discrete.UI
{
        public static class UI
    {
        public static void StartingUI()
        {
            while (true)
            {

                ConsolePrint.HeaderPrint("\"Discrete models\"");
                ConsolePrint.HeaderPrint("Ok, select method to solve");

                GetActions();

                SelectUIAction(Console.ReadLine());
            }
        }
        private static readonly Dictionary<string, Action> UIactions = new Dictionary<string, Action>
        {
            { "Press [1] Kruskal's", Actions.GetKruskal },
            { "Press [2] Chinese postman problem", Actions.GetChinesePostman },
            { "Press [3] Salesman problem", Actions.GetSalesman },
            { "Press [4] Maximum flow", Actions.GetMaxFlowByFF },
        };
        private static void GetActions()
        {
            foreach (var item in UIactions.Keys)
            {
                System.Console.WriteLine(item);
            }
        }

        private static void SelectUIAction(string selector)
        {
            foreach (var item in UIactions)
            {
                if (item.Key.Contains($"[{selector}]"))
                {
                    UIactions[item.Key]();
                    break;
                }
            }
        }

    }

}