namespace File_input_output;
public class Attack
{
    private readonly int id;
    public int Id
    {
        get { return id; }
    }

    private readonly string name;
    public string Name
    {
        get { return name; }
    }

    private readonly string effect;
    public string Effect
    {
        get { return effect; }
    }

    private readonly string type;
    public string Type
    {
        get { return type; }
    }

    private readonly string kind;

    public string Kind
    {
        get { return kind; }
    }

    private readonly int power;
    public int Power
    {
        get { return power; }
    }

    private readonly string accuracy;

    public string Accuracy
    {
        get { return accuracy; }
    }

    private readonly int pp;
    public int Pp
    {
        get { return pp; }
    }

    public Attack(int id, string name, string effect, string type, string kind, int power, string accuracy, int pp)
    {
        this.id = id;
        this.name = name;
        this.effect = effect;
        this.type = type;
        this.kind = kind;
        this.power = power;
        this.accuracy = accuracy;
        this.pp = pp;
    }
}
