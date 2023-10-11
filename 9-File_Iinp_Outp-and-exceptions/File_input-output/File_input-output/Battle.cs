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
        }
    }

    private void AttackAI()
    {
        double damage;
        int attackOption = random.Next(1, 3);
        if (attackOption == 1)
        {
            damage = (computerPokemon.AttackPrim.Power * (computerPokemon.Attack / playerPokemon.Defense) * (1.0 / 25.0));
            playerPokemon.Hp -= damage;
            Console.WriteLine("\nOpponent used " + computerPokemon.AttackPrim.Name);
        }
        else if (attackOption == 2)
        {
            damage = (int)(computerPokemon.AttackSec.Power * (computerPokemon.Attack / playerPokemon.Defense) * (1.0 / 25.0));
            playerPokemon.Hp -= damage;
            Console.WriteLine("\nOpponent used " + computerPokemon.AttackSec.Name);
        }
        else
            Console.WriteLine("Invalid attack option. Try again.");

        Console.WriteLine("Player's HP: " + (int) playerPokemon.Hp); //int - just that it looks nice for the user (no commas)
        Thread.Sleep(1000);
    }

    private void AttackPlayer()
    {
        int attackOption;
        double damage;
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
            damage = (playerPokemon.AttackPrim.Power * (playerPokemon.Attack / computerPokemon.Defense) * (1.0 / 25.0));
            computerPokemon.Hp -= damage;
            Console.WriteLine("\nPlayer used " + playerPokemon.AttackPrim.Name);
        }
        else if (attackOption == 2)
        {
            damage = (playerPokemon.AttackSec.Power * (playerPokemon.Attack / computerPokemon.Defense) * (1.0 / 25.0));
            computerPokemon.Hp -= damage;
            Console.WriteLine("\nPlayer used " + playerPokemon.AttackSec.Name);
        }

        Console.WriteLine("Opponent's HP: " + (int) computerPokemon.Hp); //int - just that it looks nice for the user (no commas)
        Thread.Sleep(1000);
    }
}


