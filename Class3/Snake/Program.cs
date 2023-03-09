using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Snake // Note: actual namespace depends on the project name.
{

    class Program
    {
        
        private static bool _inPlay = true;
        private static int _score = 0;
        private static Snake _snake = new Snake(); // make it static to make it easy at first to finish coding
        private static Food _food = new Food();

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
        static ConsoleKeyInfo? _lastKey;
        private static bool AcceptInput()
        {
            if (!Console.KeyAvailable) {
                return false;
            }
            _lastKey = Console.ReadKey();
            return true;
        }

        // UpdateGame
        private static DateTime nextUpdate = DateTime.MinValue;
        private static bool UpdateGame()
        {
            // Check if the time is valid
            if(DateTime.Now < nextUpdate) return false;

            if(_food.Position == null) {
                _food.Position = new Position {
                    left = _food.Rnd.Next(Console.WindowWidth),
                    top = _food.Rnd.Next(Console.WindowHeight)
                };
            }

            //if a valid key input
            if (_lastKey.HasValue) {
                Move(_lastKey.Value);
            }

            nextUpdate = DateTime.Now.AddMilliseconds(500/(_score + 1));

            return true;
        }

        // Move function
        private static void Move(ConsoleKeyInfo key) {
            Position currentPos;

            if(_snake.Points.Count != 0) {
                currentPos = new Position() {
                    left = _snake.Points.Last().left,
                    top = _snake.Points.Last().top
                };
            } else {
                currentPos = _snake.SetIntitialPosition();
            }

            switch(key.Key) {
                case ConsoleKey.LeftArrow: 
                currentPos.left--;
                    break;                
                case ConsoleKey.RightArrow: 
                currentPos.left++;
                    break;                
                case ConsoleKey.UpArrow: 
                currentPos.top--;
                    break;                
                case ConsoleKey.DownArrow: 
                currentPos.top++;
                    break;
                default:
                // Undefined key
                    break;
            }

            // Check if the new position collides with the console boundary or if self-overlapping
            if(!DetectCollision(currentPos)) {
                _snake.Points.Add(currentPos);
                _snake.CleanUp();
            }
        }

        // Detect collision
        private static bool DetectCollision(Position currentPos) 
        {
            // check if we are off the screen
            if (currentPos.top < 0 || currentPos.top > Console.WindowHeight -1 || 
                currentPos.left < 0 || currentPos.left > Console.WindowWidth - 1) 
            {
                GameOver();
                return true;
            }

            // check if the snake crashes itself
            if (_snake.IfOverlapped(currentPos))
            {
                GameOver();
                return true;
            }

            //Check if the snake eat the food
            if (((_food.Position != null) &&_food.Position.left == currentPos.left) && (_food.Position.top == currentPos.top))
            {
                _snake.Lenght++;
                _score ++;
                _food.Position = null;
            }
            return false;
        }

        // DrawScreen
        private static void DrawScreen() 
        {
            Console.Clear(); // make the console all black for further drawings

            // draw the score
            Console.SetCursorPosition(Console.WindowWidth-3, Console.WindowHeight-1);
            Console.Write(_score);

            // draw the snake
            for (int i = 0; i < _snake.Points.Count; i++) {
                Console.SetCursorPosition(_snake.Points[i].left, _snake.Points[i].top);
                Console.Write(Snake._bodyPattern);
            }

            // draw the food
            if(_food.Position != null) {
                Console.SetCursorPosition(_food.Position.left, _food.Position.top);
                Console.Write("∞");
            }
        }

        private static void GameOver() 
        {
            _inPlay = false;
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadLine();
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
            public static char _bodyPattern = '*';
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

            /****** methods ******/

            // IFOverlapped
            public bool IfOverlapped(Position currentPos) 
            {
                for (int i = 0; i < _points.Count; i++) {
                    if ((_points[i].left == currentPos.left) && 
                    (_points[i].top == currentPos.top)) 
                    {
                        return true;
                    }
                }
                return false;
            }

            // SetInitialPosition
            public Position SetIntitialPosition() {
                return new Position() {
                    left = 0,
                    top = 0
                };
            }
            // Cleanup
            public void CleanUp() {
                while(_points.Count > _length) {
                    _points.Remove(_points.First());
                }
            }
        
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
                get{return _position;}
                set{_position = value;}
            }

        public Random Rnd
        {
            get{return _rnd;}
            set{_rnd = value;}
        }
            // methods

         }
    }
