/*
Main : starter og evt. looper hvis man vil prøve igen

PickPosition : skal spilleren vælge et tal mellem et og 6

Keeper : enten hvis multiplayer skal modstanderen vælge et tal mellem et og 6,
        eller hvis singleplayer skal programmet vælge et tilfældigt tal

CheckGoal : Hvis spiller scorer, skal spilleren have et point, ellers ingen.
*/
namespace Fifa2077
{
    public class Program
    {
        static void Main(string[] args)
        {
            //local variable
            int score = 0;
            Console.WriteLine("Welcome to Fifa 2077");

            //infinite loop
            while (true)
            {
                //show current score
                Console.WriteLine("Score: " + score);
                //Call PickPosition method, which returns an int
                int kickPos = PickPosition();
                //Call Keeper methid, which returns an int
                int keeperPos = Keeper();
                //Call CheckIfGoal, which returns a true or false (boolean)
                bool wasItAGoal = CheckIfGoal(kickPos, keeperPos);
                //Adds to score if goal
                if (wasItAGoal) score++;
            }
        }

        static int PickPosition()
        {
            Console.WriteLine("Pick a position between 1 and 6");
            //ReadKey returns the key char pressed
            char keyPressed = Console.ReadKey().KeyChar;
            // Checks if char is a number
            if (char.IsDigit(keyPressed))
            {
                //Converts the char to an int
                int pos = (int)char.GetNumericValue(keyPressed);
                // Checks that number is between 1 and 6 and returns it 
                // from where the method was called.
                if (pos <= 6 && pos >= 1) return pos;
            }
            //Else it returns a -1 indicating the pressed key wasnt a digit (miss)
            return -1;
        }

        static int Keeper()
        {
            //Creates an instance of the object Random
            Random rand = new Random();
            //Which we uses to create a random number between 0-5 and adds 1.
            int keeper = rand.Next(6) + 1;
            return keeper;
        }

        static bool CheckIfGoal(int kickPos, int keeperPos)
        {
            //If keeper saves : no goal
            if (kickPos == keeperPos)
            {
                Console.WriteLine("Keeper saves!");
                return false;
            }
            //If kicker misses goal : no goal
            else if (kickPos == -1)
            {
                Console.WriteLine("Player misses!");
                return false;
            }
            //Else kicker scores!!!
            else
            {
                Console.WriteLine("Player scores!!!");
                return true;
            }
        }


    }
}