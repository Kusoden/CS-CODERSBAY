namespace File_input_output;

public class Effect
{
    private readonly string attacking;
    public string Attacking
    {
        get { return attacking; }
    }

    private readonly int normal;
    public int Normal
    {
        get { return normal; }
    }

    private readonly int fire;
    public int Fire
    {
        get { return fire; }
    }

    private readonly int water;
    public int Water
    {
        get { return water; }
    }

    private readonly int electric;
    public int Electric
    {
        get { return electric; }
    }

    private readonly int grass;
    public int Grass
    {
        get { return grass; }
    }

    private readonly int ice;
    public int Ice
    {
        get { return ice; }
    }

    private readonly int fighting;
    public int Fighting
    {
        get { return fighting; }
    }

    private readonly int poison;
    public int Poison
    {
        get { return poison; }
    }

    private readonly int ground;
    public int Ground
    {
        get { return ground; }
    }

    private readonly int flying;
    public int Flying
    {
        get { return flying; }
    }

    private readonly int psychic;
    public int Psychic
    {
        get { return psychic; }
    }

    private readonly int bug;
    public int Bug
    {
        get { return bug; }
    }

    private readonly int rock;
    public int Rock
    {
        get { return rock; }
    }

    private readonly int ghost;
    public int Ghost
    {
        get { return ghost; }
    }

    private readonly int dragon;
    public int Dragon
    {
        get { return dragon; }
    }

    private readonly int dark;
    public int Dark
    {
        get { return dark; }
    }

    private readonly int steel;
    public int Steel
    {
        get { return steel; }
    }

    private readonly int fairy;
    public int Fairy
    {
        get { return fairy; }
    }

    public Effect(string attacking, int againstNormal, int againstFire, int againstWater, int againstElectric, 
        int againstGrass, int againstIce, int againstFighting, int againstPoison, int againstGround, int againstFlying, int againstPsychic, int againstBug, int againstRock, int againstDragon, int againstDark, int againstSteel, int againstFairy)
    {
        this.attacking = attacking;
        this.normal = againstNormal;
        this.fire = againstFire;
        this.water = againstWater;
        this.electric = againstElectric;
        this.grass = againstGrass;
        this.ice = againstIce;
        this.fighting = againstFighting;
        this.poison = againstPoison;
        this.ground = againstGround;
        this.flying = againstFlying;
        this.psychic = againstPsychic;
        this.bug = againstBug;
        this.rock = againstRock;
        this.dragon = againstDragon;
        this.dark = againstDark;
        this.steel = againstSteel;
        this.fairy = againstFairy;
    }
}