using System;
using System.Collections.Generic; 
using System.IO;
namespace GradeBook
{
    public delegate void AddedGradeDelegate(Object sender, EventArgs args);
    public interface IBook{
        
        void addGrade(double x);
        event AddedGradeDelegate GradeAdded;
    }
    public class Book : IBook
    {
        // don't use implicit typing with fields : var keyword  
        List<double> grades;//this is a field= attribute 
        public string Name;

        public event AddedGradeDelegate GradeAdded;

        public Book(string name) : base()
        {
            this.Name= name;
            grades = new List<double>();
        }
        public Statistics getStatistics()
        {
            return new Statistics().getStatistics(Name);
        }
        public void addGrade(double grade){
            //always add validation input in every method
            if(grade>=0 && grade<=100) 
            {
                grades.Add(grade) ;
                //if we want to avoid the IO exception we 
                //can declare the Writer as a field and use within this method (keep it open)  
                using (var writer= File.AppendText($"{this.Name}.txt"))
                {
                    writer.WriteLine(grade);
                    //GradeAdded != null means that there is code somewhere that is listening to  
                    //this method and interested in knowing its status so we should keep it informed
                    //otherwise no need to activate the event
                    if(GradeAdded != null)
                    GradeAdded(this, new EventArgs());
                }
                //or we can close it thus flush all the data and be sure it's all written  
            }
            else throw new ArgumentException($"Invalid input");
        }
        
    }
}