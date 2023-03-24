namespace HanoiLibrary;
 class HanoiBoardParam
{
    // Fields
    private char _startRod = 'A';
    private char _tempRod = 'B';
    private char _endRod = 'C';
    private int _maxDisks;
    private int _firstLimit = Console.WindowWidth / 3;
    private int _secLimit = ((Console.WindowWidth / 3) * 2);
    private Stacks[] _stacks = new Stacks[3];

    // Constructor

    // Getters and Setters
    public char StartRod {get{return _startRod;}}
    public char TempRod {get{return _tempRod;}}
    public char EndRod {get{return _endRod;}}
    public int FirstLimit {get{return _firstLimit;}}
    public int SecLimit {get{return _secLimit;}}
    public Stacks[] Stacks {get{return _stacks;}}
    public int MaxDisks {
        get{return _maxDisks;}
        set{_maxDisks = value;}
    }



    // Methods
    // Initiate (put all disks on first stack)
    // Create stack
    public Stacks createStack(int capacity, char name, int xPos)
    {

        Stacks stack = new Stacks(capacity, -1, new int[capacity], name, xPos);
        return stack;
    }

    // Add in stacks array
    public void AddtoArray(int index, Stacks stack) {
        _stacks[index] = stack;
    }

    // Finaliser
    ~HanoiBoardParam() {}

}
