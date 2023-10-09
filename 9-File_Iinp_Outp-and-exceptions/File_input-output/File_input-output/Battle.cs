using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace File_input_output;
public class Battle
{
    private bool statusGame = false;
    private Pokemon playerPokemon;
    private Pokemon computerPokemon;
    private Random random = new Random();

    public void DisplayBattleInformation()
    {
        PokemonDataReader pokemons = new();
        PokemonDataReader attacks = new();

        playerPokemon = pokemons.GetRandomPokemon();
        playerPokemon.AttackPrimary = attacks.GetRandomAttack();
        playerPokemon.AttackSecondary = attacks.GetRandomAttack();

        computerPokemon = pokemons.GetRandomPokemon();
        computerPokemon.AttackPrimary = attacks.GetRandomAttack();
        computerPokemon.AttackSecondary = attacks.GetRandomAttack();

        if (playerPokemon == null || computerPokemon == null)
        {
            throw new ArgumentException("Some information is missing!");
        }

        Console.WriteLine("Player's Pokemon: " + playerPokemon.Name);
        Console.WriteLine("Primary Attack: " + playerPokemon.AttackPrimary.Name);
        Console.WriteLine("Secondary Attack: " + playerPokemon.AttackSecondary.Name);
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Computer's Pokemon: " + computerPokemon.Name);
        Console.WriteLine("Primary Attack: " + computerPokemon.AttackPrimary.Name);
        Console.WriteLine("Secondary Attack: " + computerPokemon.AttackSecondary.Name);
    }

    public void StartBattle()
    {
        DisplayBattleInformation();

        while (!statusGame)
        {
            if (playerPokemon.Speed >= computerPokemon.Speed)
            {
                AttackPokemonComputer();
                if (computerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("The Battle is over, the winner is Player!");
                    break;
                }

                AttackPokemonPlayer();
                if (playerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("The Battle is over, the winner is Computer!");
                    break;
                }
            }
            else
            {
                AttackPokemonPlayer();
                if (playerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("The Battle is over, the winner is Computer!");
                    break;
                }

                AttackPokemonComputer();
                if (computerPokemon.Hp <= 0)
                {
                    statusGame = true;
                    Console.WriteLine("The Battle is over, the winner is Player!");
                    break;
                }
            }
        }
    }

    private void AttackPokemonPlayer()
    {
        int damage;
        int attackOption = random.Next(1, 3);
        if (attackOption == 1)
        {
            damage = (int)((computerPokemon.AttackPrimary.Power) * (computerPokemon.AttackPrimary.Power / playerPokemon.Defense) * (1.0 / 25.0));
            playerPokemon.Hp -= damage;
            Console.WriteLine("Computer used " + computerPokemon.AttackPrimary.Name);
        }
        else if (attackOption == 2)
        {
            damage = (int)((computerPokemon.AttackSecondary.Power) * (computerPokemon.AttackPrimary.Power / playerPokemon.Defense) * (1.0 / 25.0));
            playerPokemon.Hp -= damage;
            Console.WriteLine("Computer used " + computerPokemon.AttackSecondary.Name);
        }
        else
        {
            Console.WriteLine("Invalid attack option. Try again.");
        }

        Console.WriteLine("Player's HP: " + playerPokemon.Hp);
        Thread.Sleep(1000);
    }

    private void AttackPokemonComputer()
    {
        int attackOption;
        int damage;
        Console.WriteLine("Player, choose your attack!");
        Console.WriteLine("1. " + playerPokemon.AttackPrimary.Name);
        Console.WriteLine("2. " + playerPokemon.AttackSecondary.Name);

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out attackOption) && (attackOption == 1 || attackOption == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid attack option. Try again.");
            }
        }

        if (attackOption == 1)
        {
            damage = (int)((playerPokemon.AttackPrimary.Power) * (playerPokemon.AttackPrimary.Power / computerPokemon.Defense) * (1.0 / 25.0));
            computerPokemon.Hp -= damage;
            Console.WriteLine("Player used " + playerPokemon.AttackPrimary.Name);
        }
        else if (attackOption == 2)
        {
            damage = (int)((playerPokemon.AttackSecondary.Power) * (playerPokemon.AttackPrimary.Power / computerPokemon.Defense) * (1.0 / 25.0));
            computerPokemon.Hp -= damage;
            Console.WriteLine("Player used " + playerPokemon.AttackSecondary.Name);
        }

        Console.WriteLine("Computer's HP: " + computerPokemon.Hp);
        Thread.Sleep(1000);
    }
}
