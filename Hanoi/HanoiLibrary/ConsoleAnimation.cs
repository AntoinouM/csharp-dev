using System;
using System.Threading;
using System.Collections.Generic;

namespace HanoiLibrary;

public class ConsoleAnimation
{
    // Fields
    private int _btmOffset;
    private int _delay;
    private bool _animation;

    // Constructor
    public ConsoleAnimation(int btmOffset, int delay) {
        _btmOffset = btmOffset;
        _delay = delay;
    }

    // Getters and setters
    public int BottomOffset {
        get {return _btmOffset;}
        set {_btmOffset = value;}
    }

    public int Delay {
        get {return _delay;}
        set {_delay = value;}
    }

    public bool Animation {
        get {return _animation;}
        set {_animation = value;}
    }

    // Methods
        // First state
    public void DisplayConsole(Pile[] piles, int disk, int maxDisks, char fromRod, char endRod, List<string> diskStrings) {
        if (_animation) {
            AnimateASCII(piles, disk, maxDisks, diskStrings);
        } else {
            TextDisplay(disk, fromRod, endRod);
        }
        
    }
        // All iteration
    public void AnimateASCII(Pile[] piles, int disk, int maxDisks, List<string> diskStrings) {

        Thread.Sleep(_delay);
        Console.Clear();
        DrawPegs(maxDisks, piles);

        for (int i = 0; i < piles.Length; i++) {
            int level = 0;
            for (int j = 0; j < piles[i].Disks.Length; j++) {
                string tempDisk = diskStrings[piles[i].Disks[j]];
                Pile peg = piles[i];
                    Console.SetCursorPosition(peg.xPos - (tempDisk.Length / 2), Console.WindowHeight - level - _btmOffset);
                    Console.Write(tempDisk);
                    level++;
            }
        }
    }

    public void TextDisplay(int disk, char fromRod, char endRod) {
        Thread.Sleep(_delay);
        System.Console.WriteLine($"Disk {disk} from {fromRod} to {endRod}");
    }
    public void DrawPegs(int maxDisks, Pile[] piles) {

        int xThird = (Console.WindowWidth / 3);
        string pegLabel;
        for (int i = 0; i <= maxDisks; i++) {
            Console.SetCursorPosition(xThird, Console.WindowHeight - i - _btmOffset);
            Console.Write('|');
            Console.SetCursorPosition(xThird * 2, Console.WindowHeight - i - _btmOffset);
            Console.Write('|');
            for (int j = 0; j < 3; j++) {
                pegLabel = $"== {piles[j].Name} ==";
                Console.SetCursorPosition(((xThird / 2) + (xThird * j)) - (pegLabel.Length / 2), Console.WindowHeight + 2 - _btmOffset);
                Console.Write(pegLabel);
            }
        }
        System.Console.WriteLine("");
    }

    // Finaliser
    ~ConsoleAnimation() {}

}