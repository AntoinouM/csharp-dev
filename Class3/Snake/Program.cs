using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Snake // Note: actual namespace depends on the project name.
{

    class Program
    {
        
        private static bool _inPlay = true;
        private static int _score = 0;
        private Snake _snake = new Snake();
        private Food _food = new Food();

        static void Main(string[] args)
        {
            while(_inPlay) 
            {
                if(AcceptInput() || UpdateGame())
                {
                    DrawScreen();
                }
            }
        }
        // AcceptInput
        private static bool AcceptInput()
        {
            return true;
        }

        // UpdateGame
        private static bool UpdateGame()
        {
            return true;
        }
        // DrawScreen
        private static void DrawScreen() 
        {
            Console.Clear();
        }
    }

        /************
         * Position *
         ************/
        public class Position
        {
            public int left;
            public int top;
        }

        /*********
         * Snake *
         *********/
         public class Snake
         {
            // fields
            private int _length = 6; //initial default value
            private List<Position> _points = new List<Position>(); // a list to store the position of the snake

            // getters and setters
            public int Lenght 
            {
                get 
                {
                    return _length;
                }
                set
                {
                    _length = value;
                }
            }
            public List<Position> Points
            {
                get 
                {
                    return _points;
                }
                set
                {
                    _points = value;
                }
            }

            // methods

            // IFOverlapped
            // SetInitialPosition
            // Cleanup
        
         }

        /**********
         *  Food  *
         **********/
         public class Food
         {
            // fields
            private Position _position = null;
            private Random _rnd = new Random();

            // getters and setters
            public Position? Position
            {
                get 
                {
                    return _position;
                }
                set
                {
                    _position = value;
                }
            }

            // methods


         }
    }
