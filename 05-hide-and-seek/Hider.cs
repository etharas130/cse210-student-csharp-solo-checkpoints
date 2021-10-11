using System;
using System.Collections.Generic;

namespace _05_hide_and_seek
{
    /// <summary>
    /// The Hider is responsible to watch the seeker and give hints.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    public class Hider
    {
        // TODO: Add any member variables here
        public int _location = 0;
        public List<int> _distance;
        /// <summary>
        /// Initializes the location of the hider to a random location 1-1000.
        /// Also initializes the list of distances to be a new, empty list.
        /// </summary>
        public Hider()
        {
            Random randomGenerator = new Random();
            _location = randomGenerator.Next(1, 1001);
            _distance = new List<int>();
            
        }

        /// <summary>
        /// Computes the distance from the hider's location to the provided location of the seeker
        /// and stores it in a list of distances to use later.
        /// </summary>
        /// <param name="seekerLocation">The current location of the seeker.</param>
        public void Watch(int seekerLocation)
        {
            int distance = Math.Abs(_location -seekerLocation);
            _distance.Add(distance);
        }

        /// <summary>
        /// Get's a hint.
        /// 
        /// If there is not enough information yet (fewer than 2 distances), a generic hint is given.
        /// If the seeker has found the hider, the hint notes they have been found.
        /// If the seeker is moving closer, the hint notes they are getting warmer.
        /// If the seeker is moving futher away, the hing notes they are getting colder.
        /// </summary>
        /// <returns>The hint message</returns>
        public string GetHint()
        {
            string hint = "";

            if(_distance.Count > 2)
            {
                hint = ("(-.-) Maybe I should take a nap.");
            }
            else 
            {
                if (IsFound())
                {
                    hint = ("(;.;) You found me!");
                }
                else if (_distance[_distance.Count - 1] > _distance[_distance.Count -2])
                {
                    hint = ("(^.^) Getting colder!");
                }
                else 
                {
                    hint = ("(>.<) Getting warmer!");
                }
            }
            return hint;
        }

        /// <summary>
        /// Returns whether the hider has been found. (Hint: the last distance is 0 in that case.)
        /// </summary>
        /// <returns>True if the hider has been found.</returns>
        public bool IsFound()
        {
            return _distance[_distance.Count - 1] == 0;
        }
    }
}
