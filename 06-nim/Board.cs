using System;
using System.Collections.Generic;

namespace _06_nim
{
    /// <summary>
    /// Keeps track of all of the pieces in play.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    class Board
    {
        // TODO: Declare any member variables here.
        private List<int> _piles = new List<int>();
        /// <summary>
        /// Initialize the Board
        /// </summary>
        public Board()
        {
            Prepare();
        }

        /// <summary>
        /// A helper method that sets up the board in a new random state.
        /// This could be called by the constructor, or if it is desired
        /// to play again.
        /// 
        /// It should have 2-5 piles with 1-9 stones in each.
        /// </summary>
        private void Prepare()
        {
            Random randomGenerator = new Random();
            int numOfPiles = randomGenerator.Next(2,6);

            for (int i = 0; i < numOfPiles; i++)
            {
                int numOfStones = randomGenerator.Next(1,9);
                _piles.Add(numOfStones);
            }

        }

        /// <summary>
        /// Applies this move by removing the number of stones
        /// from the pile specified in the move.
        /// </summary>
        /// <param name="move">Contains the pile and the number of stones</param>
        public void Apply(Move move)
        {
            int stones = move.GetStones();
            int pile = move.GetPile();

            int newStoneAmount = _piles[pile] - stones;

            _piles[pile] = Math.Max(0, newStoneAmount);

        }

        /// <summary>
        /// Indicates if the board is empty (no more stones)
        /// </summary>
        /// <returns>True, if there are no more stones</returns>
        public bool IsEmpty()
        {
            bool foundStones = false;

            foreach (int pileCount in _piles)
            {
                if (pileCount > 0)
                {
                    foundStones = true;
                    break;
                }
            }

            return !foundStones;
        }

        /// <summary>
        /// Get's a string representation of the board in the format:
        /// 
        /// --------------------
        /// 0: O O O O O O 
        /// 1: O O O O O O O
        /// 2: O O O O O O O O 
        /// 3: O O O O 
        /// --------------------
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string text = "\n--------------------\n";

            for (int i = 0; i < _piles.Count; i++)
            {
                text += GetTextForPile(i, _piles[i]);
            }
            
            text += "--------------------\n";

            return text;
        }

        /// <summary>
        /// A helper function that is used by the general ToString method.
        /// This one gets the text for a specific pile in the format:
        /// 
        /// 2: O O O O O O O O 
        /// 
        /// </summary>
        /// <param name="pileNumber">The pile number to display at the front of the line.</param>
        /// <param name="stones">The number of stones in the pile</param>
        /// <returns></returns>
        private string GetTextForPile(int pileNumber, int stones)
        {
            string text = $"{pileNumber}: ";

            for (int i = 0; i < stones; i++)
            {
                text += "O ";
            }

            text += "\n";

            return text;
        }
    }
}
