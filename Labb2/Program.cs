using System;

class Program
{
    static void Main(string[] args)
    {
        // Datatyp: bool | Identifierare: running
        // En boolesk variabel som håller koll på om programmet ska fortsätta köra
        bool running = true;

        // Programmet körs så länge running är true
        while (running)
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Beräkna windchill-faktor");
            Console.WriteLine("2. Avsluta");

            // Datatyp: int | Identifierare: choice
            // Här sparas användarens menyval som ett heltal
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                // Anropar metoden som gör själva uträkningen av wind chill
                CalculateWindChill();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Programmet avslutas.");
                running = false; // Vi ändrar värdet på running så loopen avslutas
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }
        }
    }

    // Metod för att räkna ut och skriva ut wind chill-faktorn
    static void CalculateWindChill()
    {
        // Datatyp: double | Identifierare: temperature
        // Datatyp: double | Identifierare: windSpeed
        // Datatyp: double | Identifierare: windChillFactor
        // Dessa tre variabler används för temperatur, vindhastighet och själva resultatet
        double temperature, windSpeed, windChillFactor;

        Console.WriteLine("Fyll i utomhustemperaturen i Celsius:");
        temperature = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Fyll i vindhastigheten (ange i km/h eller m/s):");
        windSpeed = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Har du angett vindhastigheten i m/s (ja/nej)?");

        // Datatyp: string? | Identifierare: inputRaw
        // Vi sparar användarens svar som en textsträng – men den kan vara null
        string? inputRaw = Console.ReadLine();

        // Datatyp: string | Identifierare: input
        // Här omvandlar vi till små bokstäver och hanterar null genom att ersätta med tom sträng
        string input = (inputRaw ?? "").ToLower();

        if (input == "ja")
        {
            // Omvandlar från meter per sekund till kilometer per timme
            windSpeed = windSpeed * 3.6;
        }

        // Datatyp: double | Identifierare: windChillFactor
        // Här beräknas den upplevda temperaturen med hjälp av en standardformel
        windChillFactor = 13.12
                        + (0.6215 * temperature)
                        - (11.37 * Math.Pow(windSpeed, 0.16))
                        + (0.3965 * temperature * Math.Pow(windSpeed, 0.16));

        Console.WriteLine($"Wind chill-faktorn är: {windChillFactor:F2} °C");

        // Klassificerar resultatet i olika nivåer beroende på hur kallt det är
        if (windChillFactor > -25)
        {
            Console.WriteLine("Kallt");
        }
        else if (windChillFactor >= -35 && windChillFactor <= -25)
        {
            Console.WriteLine("Mycket kallt");
        }
        else if (windChillFactor >= -60 && windChillFactor < -35)
        {
            Console.WriteLine("Risk för frostskada");
        }
        else
        {
            Console.WriteLine("Stor risk för frostskada");
        }
    }
}
