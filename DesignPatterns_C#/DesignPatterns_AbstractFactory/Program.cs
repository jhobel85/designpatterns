using System;

namespace DesignPatterns_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // factory auto oder Fahrrad
            string vehicle_name;
            if (args.Length != 0)
            {
                vehicle_name = args[1];
            }
            else
            {
                vehicle_name = Console.ReadLine();
            }

            IVehicleFactory vehicleFactory;
            IVehicle vehicle;
            switch(vehicle_name)
            {
                case "car":
                    vehicleFactory = new CarFactory();
                    break;
                case "bicycle":
                    vehicleFactory = new BicycleFactory();
                    break;
                default:
                    vehicleFactory = null;
                    break;
            }
            vehicle = vehicleFactory.FactoryMethod();
            Console.WriteLine(vehicle.getSpeed());

        }
    }
}
