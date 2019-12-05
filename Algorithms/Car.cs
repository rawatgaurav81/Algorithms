
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public abstract class Car
    {
        public Car(Boolean isSedan, string seats)
        {
            this.isSedan = isSedan;
            this.seats = seats;
        }
        private Boolean isSedan;
        private string seats;
        
        public Boolean getIsSedan()
        {
            return isSedan;
        }
        public string getSeats()
        {
            return seats;
        }
        public abstract string getMileage();
        public string PrintCar(string carName)
        {            
            if (getIsSedan())
                return "A "+carName+" is Sedan, is "+getSeats()+" - seater, and has a mileage of around "+getMileage()+".";
            else
                return "A " + carName + " is not Sedan, is " + getSeats() + " - seater, and has a mileage of around " + getMileage() + ".";
        }

    }
    public class WagonR : Car
    {
        private int mileage;
        public WagonR(int mileage):base(false,"4")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return this.mileage.ToString()+" kmpl";
        }
    }
    public class InnovaCrysta : Car
    {
        private int mileage;
        public InnovaCrysta(int mileage) : base(false, "6")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return this.mileage.ToString() + " kmpl";
        }
    }
    public class HondaCity : Car
    {
        private int mileage;
        public HondaCity(int mileage) : base(true, "4")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return this.mileage.ToString() + " kmpl";
        }
    }
}
