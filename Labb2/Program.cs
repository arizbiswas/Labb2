using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        // Loop som håller programmet igång tills användaren väljer att avsluta
        while (running)
        {
            // Meny för användaren att välja mellan beräkning och avslutning
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Beräkna windchill-faktor");
            Console.WriteLine("2. Avsluta");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                // Anropa metoden för att beräkna windchill
                CalculateWindChill();
            }
            else if (choice == 2)
            {
                // Avsluta programmet
                Console.WriteLine("Programmet avslutas.");
                running = false;
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }
        }
    }

    // Metod för att beräkna och skriva ut Wind Chill-faktorn
    static void CalculateWindChill()
    {
        // Deklarera variabler
        double temperature, windSpeed, windChillFactor;

        // Steg 1: Läs in temperatur från användaren
        Console.WriteLine("Fyll i utomhustemperaturen i Celsius:");
        temperature = Convert.ToDouble(Console.ReadLine());

        // Steg 2: Läs in vindhastighet från användaren och konvertera om nödvändigt
        Console.WriteLine("Fyll i vindhastigheten (ange i km/h eller m/s):");
        windSpeed = Convert.ToDouble(Console.ReadLine());

        // Om användaren har angett vindhastighet i m/s, konvertera till km/h
        Console.WriteLine("Har du angett vindhastigheten i m/s (ja/nej)?");
        string input = Console.ReadLine().ToLower();
        if (input == "ja")
        {
            windSpeed = windSpeed * 3.6; // Omvandling från m/s till km/h
        }

        // Steg 3: Beräkna Windchill med formeln
        windChillFactor = 13.12 + (0.6215 * temperature) - (11.37 * Math.Pow(windSpeed, 0.16)) + (0.3965 * temperature * Math.Pow(windSpeed, 0.16));

        // Steg 4: Skriv ut resultatet och klassificera värdet
        Console.WriteLine($"Wind chill-faktorn är: {windChillFactor:F2} °C");

        // Steg 5: Klassificera WindChill
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
