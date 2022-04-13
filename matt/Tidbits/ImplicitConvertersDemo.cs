using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tidbits
{
    [TestClass]
    public class ImplicitConvertersDemo
    {
        [TestMethod]
        public void ImplicitConverterDemo()
        {
            var firstDataModel = new PersonDataModel() { Age = "21" };
            PersonDomainModel firstDomainModel = firstDataModel;
            PersonDataModel secondDataModel = firstDomainModel;

            Console.WriteLine($"Data Model Person Age:   {firstDataModel.Age}");
            Console.WriteLine($"Domain Model Person Age: {firstDomainModel.Age}");
            Console.WriteLine();
            Console.WriteLine($"1st Data Object Hash:    {firstDataModel.GetHashCode()}");
            Console.WriteLine($"1st Domain Object Hash:  {firstDomainModel.GetHashCode()}");
            Console.WriteLine($"2nd Data Object Hash:    {secondDataModel.GetHashCode()}");
        }
    }

    public class PersonDataModel
    {
        public PersonDataModel()
        {
            Age = string.Empty;
        }

        public string Age { get; set; }

        public static implicit operator PersonDomainModel(PersonDataModel sourceObject) =>
            new PersonDomainModel() { Age = int.Parse(sourceObject.Age) };
    }

    public class PersonDomainModel
    {
        public int Age { get; set; }

        public static implicit operator PersonDataModel(PersonDomainModel destinationObject) =>
            new PersonDataModel() { Age = destinationObject.Age.ToString() };

        
    }
}