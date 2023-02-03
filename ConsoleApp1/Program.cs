// Get the total salaries of all the Senior Developers // Senior Salaries Formula = [Hourly Rate x Working Hours] + 20% bonus 
using System;
using System.Collections.Generic;
namespace RCG.Test
{
    static class Program
    {
        public static void Main(string[] args)
        {

            ISalaryCalculator _calculator = new DevelopersSalaryCalculator();
            double total = _calculator.CalculateTotalSalary(Data.Developers());
            Console.WriteLine(total);
        }
    }
    public enum DeveloperLevel
    {
        Senior,
        Junior
    }
    public class Developer
    {
        public string Name { get; set; }
        public DeveloperLevel Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
    }
    public static class Data
    {
        public static IEnumerable<Developer> Developers()
        {
            return new List<Developer>
            {
                 new Developer()
                 {
                 Name = "John", Level = DeveloperLevel.Senior, HourlyRate = 30.5, WorkingHours = 160
                 },
                 new Developer()
                 {
                 Name = "Max", Level = DeveloperLevel.Junior, HourlyRate = 20, WorkingHours = 120
                 },
                 new Developer()
                 {
                 Name = "Robert", Level = DeveloperLevel.Senior, HourlyRate = 32.5, WorkingHours = 130
                 },
                 new Developer()
                 {
                 Name = "Daniel", Level = DeveloperLevel.Junior, HourlyRate = 24.5, WorkingHours = 140
                 }
             }.ToArray();
        }
    }

    public class DevelopersSalaryCalculator : ISalaryCalculator
    {
        public double CalculateTotalSalary(IEnumerable<Developer> developers)
        {

            double total = 0;

            foreach (Developer developer in developers)
            {
                double employeeSalary = (developer.HourlyRate * developer.WorkingHours) + ((developer.HourlyRate * developer.WorkingHours) * 0.2);
                total += employeeSalary;
            }

            return total;
        }


    }

    public interface ISalaryCalculator
    {
        double CalculateTotalSalary(IEnumerable<Developer> developers);

    }
}