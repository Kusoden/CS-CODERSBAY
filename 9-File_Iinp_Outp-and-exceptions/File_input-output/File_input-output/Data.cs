using File_input_output;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace File_input_output;
public class PokemonDataReader
{
    public const string POKEMON_CSV_FILE_PATH = "./common_data/2023-03-13-Pokemon.csv";
    public const string ATTACK_CSV_FILE_PATH = "./common_data/2023-04-03-Attacks.csv";

    private Dictionary<int, Pokemon> pokemons;
    private Dictionary<int, Attack> attacks;

    public PokemonDataReader()
    {
        pokemons = new Dictionary<int, Pokemon>();
        attacks = new Dictionary<int, Attack>();
    }

    public void LoadPokemons()
    {
        Random random = new();
        using (StreamReader reader = new(POKEMON_CSV_FILE_PATH))
        {
            reader.ReadLine(); 
            string currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                string[] parts = currentLine.Split(';');
                if (parts.Length >= 11)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string type1 = parts[2];
                    string type2 = string.IsNullOrEmpty(parts[3]) ? null : parts[3];
                    int total = int.Parse(parts[4]);
                    int hp = int.Parse(parts[5]);
                    int attack = int.Parse(parts[6]);
                    int defense = int.Parse(parts[7]);
                    int spAtk = int.Parse(parts[8]);
                    int spDef = int.Parse(parts[9]);
                    int speed = int.Parse(parts[10]);

                    Pokemon pokemon = new(id, name, type1, type2, total, hp, attack, defense, spAtk, spDef, speed);
                    pokemons[id] = pokemon;
                }
            }
        }
    }

    public void LoadAttacks()
    {
        using (StreamReader reader = new(ATTACK_CSV_FILE_PATH))
        {
            reader.ReadLine();
            string currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                string[] parts = currentLine.Split(';');
                if (parts.Length >= 8)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string effect = parts[2];
                    string type = parts[3];
                    string kind = parts[4];
                    int power = int.Parse(parts[5]);
                    string accuracy = parts[6];
                    int pp = int.Parse(parts[7]);

                    Attack attack = new Attack(id, name, effect, type, kind, power, accuracy, pp);
                    attacks[id] = attack;
                }
            }
        }
    }

    public void DisplayAllPokemons()
    {
        foreach (var pokemon in pokemons.Values)
        {
            Console.WriteLine($"{pokemon.ID} {pokemon.Name} {pokemon.Type1} {pokemon.Type2} {pokemon.Total} {pokemon.Hp} {pokemon.Attack} {pokemon.Defense} {pokemon.SpAtk} {pokemon.SpDef} {pokemon.Speed}");
        }
    }

    public void DisplayAllAttacks()
    {
        foreach (var attack in attacks.Values)
        {
            Console.WriteLine($"{attack.Id} {attack.Name} {attack.Effect} {attack.Type} {attack.Kind} {attack.Power} {attack.Accuracy} {attack.Pp}");
        }
    }

    public Pokemon PrintPokemonDetails(int pokemonId)
    {
        if (pokemons.TryGetValue(pokemonId, out var pokemon))
        {
            Console.WriteLine($"{pokemon.Name} {pokemon.Type1} {pokemon.Type2} {pokemon.Total} {pokemon.Hp} {pokemon.Attack} {pokemon.Defense} {pokemon.SpAtk} {pokemon.SpDef} {pokemon.Speed}");
            Console.WriteLine("-----------------------------------");
        }
        else
        {
            Console.WriteLine($"Pokemon not found for ID: {pokemonId}");
        }
        return pokemon;
    }

    public Pokemon GetRandomPokemon()
    {
        LoadPokemons();
        if (pokemons.Count == 0)
        {
            throw new InvalidOperationException("There are no pokemons right now!");
        }

        int randomIndex = new Random().Next(0, pokemons.Count);
        return pokemons.Values.ElementAt(randomIndex);
    }

    public Attack GetRandomAttack()
    {
        LoadAttacks();
        if (attacks.Count == 0)
        {
            throw new InvalidOperationException("There are no attacks right now!");
        }

        int randomAttackId = new Random().Next(1, attacks.Count + 1);
        return attacks[randomAttackId];
    }
}
