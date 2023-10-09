using System;

namespace File_input_output;
public class Attack
{
    private readonly int id;
    private readonly string name;
    private readonly string effect;
    private readonly string type;
    private readonly string kind;
    private readonly int power;
    private readonly string accuracy;
    private readonly int pp;

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

    public int Id
    {
        get { return id; }
    }

    public string Name
    {
        get { return name; }
    }

    public string Effect
    {
        get { return effect; }
    }

    public string Type
    {
        get { return type; }
    }

    public string Kind
    {
        get { return kind; }
    }

    public int Power
    {
        get { return power; }
    }

    public string Accuracy
    {
        get { return accuracy; }
    }

    public int Pp
    {
        get { return pp; }
    }
}