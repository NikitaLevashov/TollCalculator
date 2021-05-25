using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using TollCalculator.Repository;

namespace toll_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tollCalcPremiumFall = new TollCalculator(new PeakTimePremiumFullRepository());
            var tollCalcPremium = new TollCalculator(new PeakTimePremiumRepository());
            var tollCalcPremiumIfElse = new TollCalculator(new RepositoryPeakTimePremiumIfElseRepository());

            var soloDriver = new Car();
            var twoRideShare = new Car { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };
            var emptyTaxi = new Taxi();
            var singleFare = new Taxi { Fares = 1 };
            var doubleFare = new Taxi { Fares = 2 };
            var fullVanPool = new Taxi { Fares = 5 };
            var lowOccupantBus = new Bus { Capacity = 90, Riders = 15 };
            var normalBus = new Bus { Capacity = 90, Riders = 75 };
            var fullBus = new Bus { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck { GrossWeightClass = 2500 };

            Console.WriteLine($"The toll for a solo driver is {tollCalcPremium.CalculateToll(soloDriver)}");
            Console.WriteLine($"The toll for a two ride share is {tollCalcPremium.CalculateToll(twoRideShare)}");
            Console.WriteLine($"The toll for a three ride share is {tollCalcPremium.CalculateToll(threeRideShare)}");
            Console.WriteLine($"The toll for a fullVan is {tollCalcPremium.CalculateToll(fullVan)}");

            Console.WriteLine($"The toll for an empty taxi is {tollCalcPremium.CalculateToll(emptyTaxi)}");
            Console.WriteLine($"The toll for a single fare taxi is {tollCalcPremium.CalculateToll(singleFare)}");
            Console.WriteLine($"The toll for a double fare taxi is {tollCalcPremium.CalculateToll(doubleFare)}");
            Console.WriteLine($"The toll for a full van taxi is {tollCalcPremium.CalculateToll(fullVanPool)}");

            Console.WriteLine($"The toll for a low-occupant bus is {tollCalcPremium.CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"The toll for a regular bus is {tollCalcPremium.CalculateToll(normalBus)}");
            Console.WriteLine($"The toll for a bus is {tollCalcPremium.CalculateToll(fullBus)}");

            Console.WriteLine($"The toll for a truck is {tollCalcPremium.CalculateToll(heavyTruck)}");
            Console.WriteLine($"The toll for a truck is {tollCalcPremium.CalculateToll(truck)}");
            Console.WriteLine($"The toll for a truck is {tollCalcPremium.CalculateToll(lightTruck)}");

            try
            {
                tollCalcPremium.CalculateToll("this will fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalcPremium.CalculateToll(null!);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }

            Console.WriteLine("Testing the time premiums");

            var testTimes = new DateTime[]
            {
                new DateTime(2019, 3, 4, 8, 0, 0), // morning rush
                new DateTime(2019, 3, 6, 11, 30, 0), // daytime
                new DateTime(2019, 3, 7, 17, 15, 0), // evening rush
                new DateTime(2019, 3, 14, 03, 30, 0), // overnight

                new DateTime(2019, 3, 16, 8, 30, 0), // weekend morning rush
                new DateTime(2019, 3, 17, 14, 30, 0), // weekend daytime
                new DateTime(2019, 3, 17, 18, 05, 0), // weekend evening rush
                new DateTime(2019, 3, 16, 01, 30, 0), // weekend overnight
            };

            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {tollCalcPremium.PeakTimeMethod(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {tollCalcPremium.PeakTimeMethod(time, false)}");
            }
            Console.WriteLine("====================================================");
            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {tollCalcPremiumFall.PeakTimeMethod(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {tollCalcPremiumFall.PeakTimeMethod(time, false)}");
            }
            Console.WriteLine("====================================================");
            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {tollCalcPremiumIfElse.PeakTimeMethod(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {tollCalcPremiumIfElse.PeakTimeMethod(time, false)}");
            }
        }
    }
}
