using System;
namespace Aevitas.Adapter
{
    /// <summary>
    /// Incompatable with the client, but we need the functionality: the Adaptee.
    /// </summary>
    public class Adaptee
    {
        public double CalculateSomething(int a, int b)
        {
            a += b;
            b = a * b - 14 * ( a ^ 6);

            return Math.Sqrt(b - a);
        }

        public void ReportFindings()
        {
            Console.WriteLine("Findings: {0}", CalculateSomething(16, 24));
        }
    }
}
