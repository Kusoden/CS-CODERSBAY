namespace File_input_output;

public class Pokemon
{
    private readonly int id;
    private readonly string name;
    private readonly string type1;
    private readonly string type2;
    private readonly int total;
    private int hp;
    private readonly int attack;
    private readonly int defense;
    private readonly int spAtk;
    private readonly int spDef;
    private readonly int speed;

    private Attack attackPrimary;
    private Attack attackSecondary;

    public Pokemon(int id, string name, string type1, string type2, int total, int hp, int attack, int defense, int spAtk, int spDef, int speed)
    {
        this.id = id;
        this.name = name;
        this.type1 = type1;
        this.type2 = type2;
        this.total = total;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.spAtk = spAtk;
        this.spDef = spDef;
        this.speed = speed;
    }

    public Attack AttackPrimary
    {
        get { return attackPrimary; }
        set { attackPrimary = value; }
    }

    public Attack AttackSecondary
    {
        get { return attackSecondary; }
        set { attackSecondary = value; }
    }

    public int ID
    {
        get { return id; }
    }

    public string Name
    {
        get { return name; }
    }

    public string Type1
    {
        get { return type1; }
    }

    public string Type2
    {
        get { return type2; }
    }

    public int Total
    {
        get { return total; }
    }

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SpAtk
    {
        get { return spAtk; }
    }

    public int SpDef
    {
        get { return spDef; }
    }

    public int Speed
    {
        get { return speed; }
    }
}
