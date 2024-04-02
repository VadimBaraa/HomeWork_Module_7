using System;
using System.Security.Cryptography.X509Certificates;

class Programm
{
    static void Main(string[] args)
    {
        
        string[] array_description = new string[5];
        Console.Write("Введите марку, модель, кол-во цилиндров, количество л.с. и массу авто в кг. :\t");

        for (int i = 0; i < array_description.Length; i++)
        {
            array_description[i] = Console.ReadLine();
        }

        int Weight = int.Parse(array_description[4]);

        if (Weight < 3000)
        {
            Car passenger_car = new Passenger_Car(array_description[0], array_description[1], array_description[2], array_description[3], Weight);
            passenger_car.Start_Engine();
            Console.WriteLine("Двигатель легкового автомобиля успешно запущен.");
        }
        else if (Weight >= 3000)
        {
            Car truck = new Truck_Car(array_description[0], array_description[1], array_description[2], array_description[3], Weight);
            truck.Start_Engine();
            Console.WriteLine("Двигатель грузового автомобиля успешно запущен.");
        }
                
    }
}

public class Engine
{
    public string Type { get; set; }
    public string Horse_power { get; set; }

    public Engine(string type, string horse_power)
    {
        Type = type;
        Horse_power = horse_power;
    }
}


public abstract class Car
{
    public string Car_Brand { get; set; }
    public string Car_Model { get; set;}
    public Engine Car_Engine { get; set; }
    public int Weight {  get; set; }
    protected Car(string car_Brand, string car_Model, string engineType, string engineHorse_power, int weight)
    {
        Car_Brand = car_Brand;
        Car_Model = car_Model;
        Car_Engine = new Engine(engineType, engineHorse_power);
        Weight = weight;
    }

    public abstract void Start_Engine();
}

public class Passenger_Car : Car
{
    public Passenger_Car(string car_Brand, string car_Model, string engineType, string engineHorse_power, int Weight) : base(car_Brand, car_Model, engineType, engineHorse_power, Weight) { }
    public override void Start_Engine()
    {
        Console.WriteLine($"Запуск {Car_Engine.Type}-х цилиндрового двигателя легкового автомобиля {Car_Brand} {Car_Model} массой {Weight}, с мощностью {Car_Engine.Horse_power} л.с.");
    }
}

public class Truck_Car : Car
{
    public Truck_Car(string car_Brand, string car_Model, string engineType, string engineHorse_power, int Weight) : base(car_Brand, car_Model, engineType, engineHorse_power, Weight) { }
    public override void Start_Engine()
    {
        Console.WriteLine($"Запуск {Car_Engine.Type}-х цилиндрового двигателя грузового автомобиля {Car_Brand} {Car_Model} массой {Weight}, с мощностью {Car_Engine.Horse_power} л.с.");
    }
}