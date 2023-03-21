namespace Classes;

    public class HanoiParam 
    {
        // Fields
        private char[] _pegs = {'A', 'B', 'C'};

        // Getters
        public char[] Pegs 
        {
            get { return _pegs;} // shortend of having a Getage() function with a return
        }

        // Methods

        // Finalisers
        ~HanoiParam() {}
    }