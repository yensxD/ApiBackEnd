namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinq()
        {
            string[] cars =
         {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            var carLista = from car in cars select car;

            foreach (var car in carLista) Console.WriteLine(car);
        }
    }
}
