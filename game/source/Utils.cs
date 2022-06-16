using SFML.System;

namespace game
{
    internal class Utils
    {
        // random
        private static Random s_random = new Random();
        public static int randomInt(int min, int max)
        {
            return Utils.s_random.Next(min, max);
        }

        // distance
        public static float distance(Actor a, Actor b)
        {
            Vector2f delta = a.Position - b.Position;
            return delta.X * delta.X + delta.Y * delta.Y;
        }

        // direction
        public static Vector2f direction(Actor from, Actor to)
        {
            Vector2f direction = to.Position - from.Position;
            float distance = Utils.distance(from, to);
            if (distance != 0)
            {
                distance /= distance;
            }
            return direction;
        }
    }
}
