namespace File_input_output;

public class Pokemon
{
    private readonly int id;
    public int ID
    {
        get { return id; }
    }
    private readonly string name;
    public string Name
    {
        get { return name; }
    }
    private readonly string type1;
    public string Type1
    {
        get { return type1; }
    }

    private readonly string type2;
    public string Type2
    {
        get { return type2; }
    }

    private readonly int total;
    public int Total
    {
        get { return total; }
    }

    private int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    private readonly int attack;
    public int Attack
    {
        get { return attack; }
    }

    private readonly int defense;
    public int Defense
    {
        get { return defense; }
    }

    private readonly int spAtk;
    public int SpAtk
    {
        get { return spAtk; }
    }

    private readonly int spDef;
    public int SpDef
    {
        get { return spDef; }
    }

    private readonly int speed;
    public int Speed
    {
        get { return speed; }
    }

    private Attack? attackPrimary;
    public Attack? AttackPrim
    {
        get { return attackPrimary; }
        set { attackPrimary = value; }
    }

    private Attack? attackSecondary;
    public Attack? AttackSec
    {
        get { return attackSecondary; }
        set { attackSecondary = value; }
    }

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
}