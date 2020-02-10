using System;
using System.IO;
using System.Collections.Generic;
namespace GradeBook
{
    public class Statistics{
        public double average;
        public double low;
        public double high;
        public double count;
        public Statistics(){
            average = 0.0;
            low = double.MaxValue;
            high = double.MinValue;
            count = 0;
        }
        public Statistics getStatistics(string name){
            Console.Write("reading from file ");
            using(var reader= File.OpenText($"{name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = double.Parse(line);
                    average+= grade;
                    count++;
                    low = Math.Min(grade,low);
                    high = Math.Max(grade,high);
                    line = reader.ReadLine();    
                }
            }
            
            average/=count; 
            return this;
        }
        
    }
}