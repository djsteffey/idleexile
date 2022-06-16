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
    }
}
