using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    interface Builder {
        void SetSeats(int seats);
        void SetEngine(string engine);
        void SetGPS(bool gps);

        void Reset();

    }

    class CarBuilder : Builder
    {
        Car car = new Car();
        public void SetEngine(string engine)
        {
            car.Engine = engine;
        }

        public void SetGPS(bool gps)
        {
            car.GPS = gps;
        }

        public void SetSeats(int seats)
        {
            car.Seats = seats;
        }
        public Car ReturnProduct()
        {
            return car;
        }

        public void Reset()
        {
            car = new Car();
        }
    }

    class CarManualBuilder: Builder
    {
        Manual manual = new Manual();
        public void SetEngine(string engine)
        {
            manual.CarManualEntries.Add("Engine", engine);
        }

        public void SetGPS(bool gps)
        {
            manual.CarManualEntries.Add("GPS", gps.ToString());
        }

        public void SetSeats(int seats)
        {
            manual.CarManualEntries.Add("Seats", seats.ToString());
        }
        public Manual ReturnProduct()
        {
            return manual;
        }

        public void Reset()
        {
            manual = new Manual();
        }
    }

    class Director
    {
        Builder builder;
        public void SetBuilder(Builder builder)
        {
            this.builder = builder;
        }

        public void ConstructSportsCar()
        {
            builder.SetEngine("Sports engine");
            builder.SetGPS(true);
            builder.SetSeats(2);
            builder.Reset();
        }

        public void ConstructSUV()
        {
            builder.SetEngine("SUV engine");
            builder.SetGPS(true);
            builder.SetSeats(4);
            builder.Reset();
        }

    }


    class Car {

        public string Engine { get; set; }
        public bool GPS { get; set; }
        public int Seats { get; set; }

    }

    class Manual {
        public Manual()
        {
            CarManualEntries = new Dictionary<string, string>();
        }
       public  Dictionary<string, string> CarManualEntries { get; set; }
    }
}
