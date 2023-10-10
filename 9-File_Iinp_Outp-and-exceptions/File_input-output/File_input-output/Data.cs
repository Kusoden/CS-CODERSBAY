namespace File_input_output;
public class PokemonDataReader
{
    public const string POKEMON_CSV_FILE_PATH = "Pokemon.csv";
    public const string ATTACK_CSV_FILE_PATH = "Attacks.csv";

    private readonly Dictionary<int, Pokemon> pokemons;
    private readonly Dictionary<int, Attack> attacks;

    public PokemonDataReader()
    {
        pokemons = new Dictionary<int, Pokemon>();
        attacks = new Dictionary<int, Attack>();
    }

    public void ImportPokemon()
    {
        using StreamReader reader = new(POKEMON_CSV_FILE_PATH);
        reader.ReadLine();
        string currentLine;

        while ((currentLine = reader.ReadLine()) != null)
        {
            string[] column = currentLine.Split(';');
            if (column.Length >= 11)
            {
                int id = int.Parse(column[0]);
                string name = column[1];
                string type1 = column[2];
                string? type2 = column[3];
                int total = int.Parse(column[4]);
                int hp = int.Parse(column[5]);
                int attack = int.Parse(column[6]);
                int defense = int.Parse(column[7]);
                int spAtk = int.Parse(column[8]);
                int spDef = int.Parse(column[9]);
                int speed = int.Parse(column[10]);

                Pokemon pokemon = new(id, name, type1, type2, total, hp, attack, defense, spAtk, spDef, speed);
                pokemons[id] = pokemon;
            }
        }
    }

    public void ImportAttack()
    {
        using StreamReader reader = new(ATTACK_CSV_FILE_PATH);
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

                Attack attack = new(id, name, effect, type, kind, power, accuracy, pp);
                attacks[id] = attack;
            }
        }
    }

    public Pokemon GetRandomPokemon()
    {
        ImportPokemon();
        if (pokemons.Count == 0)
            throw new InvalidOperationException("There are no pokemons right now!");

        int randomIndex = new Random().Next(0, pokemons.Count);
        return pokemons.Values.ElementAt(randomIndex);
    }

    public Attack GetRandomAttack()
    {
        ImportAttack();
        if (attacks.Count == 0)
            throw new InvalidOperationException("There are no attacks right now!");

        int randomAttackId = new Random().Next(1, attacks.Count + 1);
        return attacks[randomAttackId];
    }
}
