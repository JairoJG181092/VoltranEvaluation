using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionVoltron.Clases
{
    internal class Order
    {
        private double standardLength = 2.5;
        private double[] availableHeights = { 1.03, 1.53, 2.03 };
        private Dictionary<double, int> fixatorsPerHeight = new Dictionary<double, int>
        {
            { 1.03, 3 },
            { 1.53, 4 },
            { 2.03, 6 }
        };
        private List<string> availableColors = new List<string> { "sin pintura", "blanca", "negra", "verde" };

        

        public string GetOrderSummary(double requestedLength, double height, string color)
        {
            double soldLength = Math.Max(requestedLength, standardLength);
            double fencestoSell = Math.Ceiling(requestedLength / standardLength);
            double lengthDifference = (fencestoSell * standardLength) - requestedLength;
            int fixators = fixatorsPerHeight[height];
            int firstFence = 2;
            double restFences = fencestoSell - 1;

            double totalPostSell = firstFence + restFences;

            string summary = "";

            summary = $"Altura: {height}m | Color: {color} | Largo vendido: {soldLength}m | Cercas vendidas {fencestoSell} | Fijadores por poste {fixators} | Postes a vender {totalPostSell} ";

            if (lengthDifference > 0)
            {
                summary += $" | Diferencia de largo: {lengthDifference} m";
            }
           
            

            return summary;
        }
    }
}
