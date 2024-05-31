using static System.Net.Mime.MediaTypeNames;

namespace Arena2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rounds = GetPositiveNumberOfBattles();
            int knightWins = 0, rogueWins = 0, mageWins = 0, berserkerWins = 0;

            for (int i = 0; i < rounds; i++)
            {
                Hero one = CreateRandomHero(null);
                Hero two = CreateRandomHero(one.GetType());

                Console.WriteLine($"Arena fight between: {one.Name} and {two.Name}");
                Arena arena = new Arena(one, two);
                Hero winner = arena.Battle();
                Console.WriteLine($"Winner is: {winner.Name}");

                if (winner is Knight) knightWins++;
                else if (winner is Rogue) rogueWins++;
                else if (winner is Mage) mageWins++;
                else if (winner is Berserker) berserkerWins++;

                Console.WriteLine(); // Add a blank line between battles
            }

            Console.WriteLine();
            Console.WriteLine($"Knight has {knightWins} wins.");
            Console.WriteLine($"Rogue has {rogueWins} wins.");
            Console.WriteLine($"Mage has {mageWins} wins.");
            Console.WriteLine($"Berserker has {berserkerWins} wins.");

            Console.ReadLine();
        }

        static int GetPositiveNumberOfBattles()
        {
            int rounds;
            while (true)
            {
                Console.Write("Enter number of battles: ");
                if (Int32.TryParse(Console.ReadLine(), out rounds) && rounds > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid positive number.");
            }
            return rounds;

        }

        static Hero CreateRandomHero(Type previousHeroType)
        {
            Random rand = new Random();
            int heroType;

            do
            {
                heroType = rand.Next(4);
            } while (previousHeroType != null && GetTypeFromInt(heroType) == previousHeroType);

            switch (heroType)
            {
                case 0:
                    return new Knight("Knight Tristan", Weapons.Sword);
                case 1:
                    return new Rogue("Rogue Vesper", Weapons.Dagger);
                case 2:
                    return new Mage("Mage Shadowblade", Weapons.Bow);
                case 3:
                    return new Berserker("Berserker Thorin", Weapons.Axe);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        static Type GetTypeFromInt(int heroType)
        {
            switch (heroType)
            {
                case 0: return typeof(Knight);
                case 1: return typeof(Rogue);
                case 2: return typeof(Mage);
                case 3: return typeof(Berserker);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}