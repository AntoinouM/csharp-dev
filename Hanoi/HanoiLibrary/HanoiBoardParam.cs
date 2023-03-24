using System;
using System.Collections.Generic;

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
    private Pile[] _pilesArr = new Pile[3];
    private List<string> _diskChara = new List<string>();  

    // Constructor

    // Getters and Setters
    public char StartRod {get{return _startRod;}}
    public char TempRod {get{return _tempRod;}}
    public char EndRod {get{return _endRod;}}
    public int FirstLimit {get{return _firstLimit;}}
    public int SecLimit {get{return _secLimit;}}
    public Pile[] Piles {get{return _pilesArr;}}
    public List<string> DiskChara {get{return _diskChara;}}
    public int MaxDisks {
        get{return _maxDisks;}
        set{_maxDisks = value;}
    }



    // Methods
    // Initiate (put all disks on first stack)
    // Create stack
    public Pile createStack(int capacity, char name, int xPos)
    {

        Pile stack = new Pile(capacity, -1, new int[capacity], name, xPos);
        return stack;
    }

    public void CreateDisksStringRepresentations(int nDisks) {
        _diskChara.Add("");
        string tempStringDisk;
        for (int i = 1; i <= nDisks; i++) {
            tempStringDisk = new String('#', i * 2);
            _diskChara.Add($"<{tempStringDisk}>");
        }
    }

    public void InitiateBoard(int nDisks) {
        _maxDisks = nDisks;
        Pile startStack = createStack(nDisks, _startRod, (0 + ((Console.WindowWidth / 3) / 2)));
        Pile tempStack = createStack(nDisks, _tempRod, (_firstLimit + ((Console.WindowWidth / 3) / 2)));
        Pile endStack = createStack(nDisks, _endRod, (_secLimit + ((Console.WindowWidth / 3) / 2)));

        CreateDisksStringRepresentations(nDisks);

        AddtoStacksArray(0, startStack);
        AddtoStacksArray(1, tempStack);
        AddtoStacksArray(2, endStack);
    }

    // Add in stacks array
    public void AddtoStacksArray(int index, Pile stack) {
        _pilesArr[index] = stack;
    }

    // Finaliser
    ~HanoiBoardParam() {}

}
