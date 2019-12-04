using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTests.SampleData
{
    public class Car
    {
        private IEngine _engine;
        public bool IsOilDiodaActive { get; private set; }
        public  string Brand { get; private set; }
        public string Model { get; private set; }
        public int Millage { get; private set; }
        public Person Owner { get; private set; }


        public Car(string brand, string model, int millage,
            IEngine engine)
        {
            _engine = engine;
            Brand = brand;
            Model = model;
            Millage = millage;

            if (!_engine.IsOilOk())
                IsOilDiodaActive = true;
        }

        public  void IncremenrMillage()
        {
            Millage++;
        }

        public double GetOilStatus()
        {
            return _engine.OilStatus;
        }

        internal void SellTo(Person person)
        {
            if (string.IsNullOrEmpty(person.Name))
                throw new Exception("Person should have a name");
            else if (!person.License)
                throw new Exception("Person should have a license");
            else if (person.Budget < 100000)
                throw new Exception("Person has not enought money");

            Owner = person;
        }
    }
}
