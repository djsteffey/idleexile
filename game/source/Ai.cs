namespace game
{
    internal class Ai
    {
        // variables


        // methods
        public Ai()
        {

        }

        public static Actor getClosestOtherActor(Actor actor, List<Actor> actorsList)
        {
            // save actor and distance
            Actor closestActor = null;
            float closestDistance = float.MaxValue;

            // loop over all actors
            foreach (Actor other in actorsList)
            {
                // skip actor
                if (other == actor)
                {
                    continue;
                }

                // compute distance
                float distance = Utils.distance(actor, other);

                // check if this is the new closest
                if (distance < closestDistance)
                {
                    // save as closest
                    closestActor = other;
                    closestDistance = distance;
                }
            }

            // done
            return closestActor;
        }
    }
}
