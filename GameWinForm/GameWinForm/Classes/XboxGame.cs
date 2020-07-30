using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinForm.Classes
{
    [Serializable()] //Serializable implies that this class can be written to disk
    //XboxGame is inheritted class from base class, Game.
    public class XboxGame : Game
    {
        public XboxGame(string gameTitle, string gameDev, decimal originalPrice, DateTime releaseDate, Condition condition) : base(gameTitle, gameDev, originalPrice, releaseDate, condition)
        {
            //As this class inherits from a base class, 
            //the constructor will generate the instance based on the attributes of the Base class and an additional attribute considered for this class.
            this.console = "Xbox";
        }

        //This method is overridden in this inherited class (XboxGame)
        public override decimal CalculateApproximateValue()
        {
            decimal estimate = 0;
            //Modify Game's estimated value based on its condition
            if(condition == Condition.poor)
            {
                estimate = originalPrice * 0.5m; //50% of original price
            }
            else if (condition == Condition.fair)
            {
                estimate = originalPrice * 0.7m; //70% of original price
            }
            else if (condition == Condition.good)
            {
                estimate = originalPrice * 0.8m;  //80% of original price
            }
            else if(condition == Condition.mint)
            {
                estimate = originalPrice * 0.9m;  //90% of original price
            }

            //considering the game's age
            int gameAge = CalculateApproximateAgeInYears();
            //For each year, a further 10% is lost (i.e. keep 90%)
            //for(int i = 0; i < gameAge; i++)
            //{
            //  estimate = estimate * 0.9m;
            //}
            //or 
            /*Alternative process instead of the commented loop process above*/
            estimate = estimate * (decimal)Math.Pow(0.9, gameAge);

            estimate = Decimal.Round(estimate, 0); //round-up to nearest whole value of estimate price

            return estimate;


        }

        public override string Description()
        {
            //Extra infomation of the console is added to the description for the game.
            string description = base.Description() + Environment.NewLine + string.Format("Console: {0}", console);
            return description;
        }
    }
}
