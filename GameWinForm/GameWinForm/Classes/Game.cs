using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinForm
{
    //Game is an Abstract class that implements with IComparable interface which will enable sorting of objects(i.e. Game objects).
    public abstract class Game : IComparable
    {
        //Game conditions
        public enum Condition
        {
            poor,
            fair,
            good,
            mint
        };

        //attributes or properties of a Game with protected access modifier
        protected string console;
        protected string gameTitle;
        protected string gameDev;
        protected Condition condition;
        protected decimal originalPrice;
        protected DateTime releaseDate;


        //Constructor for Game class
        public Game(string gameTitle, string gameDev, decimal originalPrice, DateTime releaseDate, Condition condition)
        {
            this.gameTitle = gameTitle;
            this.gameDev = gameDev;
            this.originalPrice = originalPrice;
            this.releaseDate = releaseDate;
            this.condition = condition;
        }

        /*Get methods for each of the class attributes*/
        public string GetConsole
        {
            get { return console; }
        }

        public string GetDeveloper
        {
            get { return gameDev; }
        }

        public string GetTitle
        {
            get { return gameTitle; }
        }

        public decimal OriginalPrice
        {
            get { return originalPrice; }
                       
        }

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            
        }

        public Condition GetCondition()
        {
            return condition;
        }

        public int CalculateApproximateAgeInYears()
        {
            DateTime currentDate = DateTime.Now; // Estimate current date.
            TimeSpan ageAsTimeSpan = currentDate.Subtract(releaseDate);
            int ageInYears = ageAsTimeSpan.Days / 365; //Convert to number of years since release date
            return ageInYears;

        }

        public abstract decimal CalculateApproximateValue();

        //Implement IComparable's CompareTo method which can be used if it is required to sort the Games  
        int IComparable.CompareTo(object obj)
        { // IComparable returns +1, 0 or -1 
            Game otherGames = (Game)obj;
            decimal differenceInPrice = this.CalculateApproximateValue() - otherGames.CalculateApproximateValue();
            // We want to return +1, 0 or -1 
            return Math.Sign(differenceInPrice);
        }

        public virtual string Description()
        {

        // String to get the name of current Game's condition
        string conditionNameForGame = Enum.GetName(typeof(Condition), condition);

        string gameDescription = string.Format("Name of Game: {0}{1}Game Developer: {2}{3}Game Condition: {4}{5}Release Date: {6}{7}Sale Price {8:c}",
           gameTitle,
           Environment.NewLine,
           gameDev,
           Environment.NewLine,
           conditionNameForGame,
           Environment.NewLine,
           releaseDate,
           Environment.NewLine,
           CalculateApproximateValue()
            );

           return gameDescription; //returns description of Game
            
        }
    }
}
