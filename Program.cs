using System;
using System;

namespace FahrzeugUebung
{
    // === 1. BASISKLASSE: Vehicle ===
    class Vehicle
    {
        // Property ID (wird von allen anderen Klassen geerbt)
        public int ID { get; set; }

        // Konstruktor für die ID
        public Vehicle(int id)
        {
            this.ID = id;
        }

        // Methode SayId (virtual, damit Unterklassen sie nutzen/überschreiben können)
        public virtual void SayId()
        {
            Console.WriteLine($"Meine ID lautet {ID}");
        }

        // ToString-Methode für die Basisklasse
        public override string ToString()
        {
            return $"Vehicle - ID: {ID}";
        }
    }

    // === 2. UNTERKLASSE: Car (ist ein Vehicle) ===
    class Car : Vehicle
    {
        public string LicenceNumber { get; set; }

        // Der Konstruktor reicht die ID über ': base(id)' an das Vehicle weiter
        public Car(int id, string licenceNumber) : base(id)
        {
            this.LicenceNumber = licenceNumber;
        }

        // Überschreiben der ToString-Methode, um auch das Kennzeichen auszugeben
        public override string ToString()
        {
            return $"{base.ToString()}, LicenceNumber: {LicenceNumber}";
        }
    }

    // === 3. UNTERKLASSE: Ship (ist ein Vehicle) ===
    class Ship : Vehicle
    {
        public string Name { get; set; }

        public Ship(int id, string name) : base(id)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Name: {Name}";
        }
    }

    // === 4. UNTERKLASSE: SailingShip (ist ein Ship, und damit auch ein Vehicle) ===
    class SailingShip : Ship
    {
        // Poles steht für die Anzahl der Masten
        public int Poles { get; set; }

        // Der Konstruktor reicht id und name an 'Ship' weiter
        public SailingShip(int id, string name, int poles) : base(id, name)
        {
            this.Poles = poles;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Poles: {Poles}";
        }
    }

    // === MAIN-METHODE ZUM TESTEN ===
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Teste Aufgabe 1 (SailingShip) ---");

            // Legen Sie eine Instanz von SailingShip an (z.B. ID: 42, Name: "Black Pearl", Masten: 3)
            SailingShip mySailingShip = new SailingShip(42, "Black Pearl", 3);

            // Rufen Sie darauf die Methode SayId auf
            mySailingShip.SayId();

            // Test der ToString-Methode (gibt alle Werte aus)
            Console.WriteLine("\n--- Test der ToString-Methoden ---");
            Console.WriteLine(mySailingShip.ToString());

            // Optional: Testen wir auch ein Auto, um zu sehen, ob alles klappt
            Car myCar = new Car(101, "N-AN 2026");
            Console.WriteLine(myCar.ToString());
        }
    }
}
