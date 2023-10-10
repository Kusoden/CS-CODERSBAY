using System.Security.Cryptography.X509Certificates;

namespace File_input_output;
public class Battle
{
    private bool statusGame = false;
    private Pokemon? playerPokemon;
    private Pokemon? computerPokemon;
    private readonly Random random = new();
    private int round = 1;
    public void DisplayBattleInfo()
    {
        PokemonDataReader pokemons = new();
        PokemonDataReader attacks = new();

        playerPokemon = pokemons.GetRandomPokemon();
        playerPokemon.AttackPrim = attacks.GetRandomAttack();
        playerPokemon.AttackSec = attacks.GetRandomAttack();

        computerPokemon = pokemons.GetRandomPokemon();
        computerPokemon.AttackPrim = attacks.GetRandomAttack();
        computerPokemon.AttackSec = attacks.GetRandomAttack();

        Console.WriteLine("Player's Pokemon: " + playerPokemon.Name);
        Console.WriteLine("Primary Attack: " + playerPokemon.AttackPrim.Name);
        Console.WriteLine("Secondary Attack: " + playerPokemon.AttackSec.Name);
        Console.WriteLine("\n+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+\n");
        Console.WriteLine("Opponent's Pokemon: " + computerPokemon.Name);
        Console.WriteLine("Primary Attack: " + computerPokemon.AttackPrim.Name);
        Console.WriteLine("Secondary Attack: " + computerPokemon.AttackSec.Name);
    }

    private void LoadTypeEffectiveness()
    {
        using (StreamReader reader = new("Effectiveness.csv"))
        {
            string header = reader.ReadLine();
            string[] typeNames = header.Split(';').Skip(1).ToArray();

            foreach (string typeName in typeNames)
            {
                typeEffectiveness[typeName] = new Dictionary<string, double>();
            }

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                string attackingType = values[0];

                for (int i = 1; i < values.Length; i++)
                {
                    string defendingType = typeNames[i - 1];
                    double effectiveness = double.Parse(values[i]);
                    typeEffectiveness[attackingType][defendingType] = effectiveness;
                }
            }
        }
    }

    public void calculateDmgType()
    {
        string computertype = computerPokemon.Type1;
        string playertype = playerPokemon.Type1;
        string aiDefenceDmgFromType;
        int dealable

    }

    public void StartBattle()
    {
        DisplayBattleInfo();

        while (!statusGame)
        {
            if (playerPokemon.Speed >= computerPokemon.Speed)
            {
                AttackPlayer();
                if (computerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("\nThe Battle is over, Player is the WINNER!\n");
                    Console.WriteLine("GG'S in the chat");
                    break;
                }

                AttackAI();
                if (playerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("\nThe Battle is over, AI is the WINNER!\n");
                    Console.WriteLine("BG'S in the chat");
                    break;
                }
            }
            else
            {
                AttackAI();
                if (playerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("\nThe Battle is over, AI is the WINNER!\n");
                    Console.WriteLine("BG'S in the chat");
                    break;
                }

                AttackPlayer();
                if (computerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("\nThe Battle is over, Player is the WINNER!\n");
                    Console.WriteLine("GG'S in the chat");
                    break;
                }
            }
            round++;
        }
    }

    private void AttackAI()
    {
        int damage;
        int attackOption = random.Next(0, 2);
        if (attackOption == 0)
        {
            damage = (int)(computerPokemon.AttackPrim.Power * (computerPokemon.Attack / playerPokemon.Defense) * (1.0 / 50.0) * round * defenceDmgFromType);
            playerPokemon.Hp -= damage;
            Console.WriteLine("\nOpponent used " + computerPokemon.AttackPrim.Name);
        }
        else if (attackOption == 1)
        {
            damage = (int)(computerPokemon.AttackSec.Power * (computerPokemon.Attack / playerPokemon.Defense) * (1.0 / 50.0) * round);
            playerPokemon.Hp -= damage;
            Console.WriteLine("\nOpponent used " + computerPokemon.AttackSec.Name);
        }
        else
        {
            Console.WriteLine("Invalid attack option. Try again.");
        }

        Console.WriteLine("Player's HP: " + playerPokemon.Hp);
        Thread.Sleep(1000);
    }

    private void AttackPlayer()
    {
        int attackOption;
        int damage;
        Console.WriteLine("\n         +--+--+--+--+--+--+--+--+");
        Console.WriteLine("Player's Pokemon: " + playerPokemon.Name);
        Console.WriteLine("                    -----");
        Console.WriteLine("\nPlayer, choose your attack!\n");
        Console.WriteLine("To use Primary Attack: " + playerPokemon.AttackPrim.Name + "  press 1");
        Console.WriteLine("To use Secondary Attack: " + playerPokemon.AttackSec.Name + "  press 2");
        Console.WriteLine("\n         +--+--+--+--+--+--+--+--+\n");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out attackOption) && (attackOption == 1 || attackOption == 2))
                break;
            else
                Console.WriteLine("Invalid attack option. Try again.");
        }

        if (attackOption == 1)
        {
            damage = (int)((playerPokemon.AttackPrim.Power) * (playerPokemon.Attack / computerPokemon.Defense) * (1.0 / 50.0));
            computerPokemon.Hp -= damage;
            Console.WriteLine("\nPlayer used " + playerPokemon.AttackPrim.Name);
        }
        else if (attackOption == 2)
        {
            damage = (int)((playerPokemon.AttackSec.Power) * (playerPokemon.Attack / computerPokemon.Defense) * (1.0 / 50.0));
            computerPokemon.Hp -= damage;
            Console.WriteLine("\nPlayer used " + playerPokemon.AttackSec.Name);
        }

        Console.WriteLine("Opponent's HP: " + computerPokemon.Hp);
        Thread.Sleep(1000);
    }

    private Dictionary<string, Dictionary<string, double>> typeEffectiveness;

    public DamageCalculator()
    {
        typeEffectiveness = new Dictionary<string, Dictionary<string, double>>();
        LoadTypeEffectiveness();
    }

    

    public double CalculateDamage(Pokemon attacker, Pokemon defender, Attack attack)
    {
        double attackPower = attack.Power;
        double attackerAttack = attacker.Attack;
        double defenderDefense = defender.Defense;
        double level = 50.0; // Assuming level 50 for simplicity
        double randomFactor = new Random().NextDouble() * (1.0 - 0.85) + 0.85; // Random factor between 0.85 and 1.0

        // Calculate type effectiveness
        double type1Effectiveness = typeEffectiveness[attack.Type][defender.Type1];
        double type2Effectiveness = 1.0; // Default to 1.0 if there's no Type2

        if (!string.IsNullOrEmpty(defender.Type2))
        {
            type2Effectiveness = typeEffectiveness[attack.Type][defender.Type2];
        }

        // Calculate damage using the formula
        double damage = (attackPower * (attackerAttack / defenderDefense) * (level / 50.0) * randomFactor *
                         type1Effectiveness * type2Effectiveness);

        return damage;
    }
}


