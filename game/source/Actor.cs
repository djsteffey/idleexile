using SFML.Graphics;
using SFML.System;

namespace game
{
    internal class Actor
    {
        // variables
        protected static Tileset s_tileset;
        protected Transformable m_transformable;
        protected RectangleShape m_shape;

        // properties
        public Vector2f Position
        {
            get { return this.m_transformable.Position; }
        }

        // methods
        public Actor(Vector2f position, Vector2f size)
        {
            // make tileset if needed
            if (Actor.s_tileset == null)
            {
                Actor.s_tileset = new Tileset(new Texture("assets/actors_24x24.png"), 24);
            }

            this.m_transformable = new Transformable();
            this.m_transformable.Position = position;

            this.m_shape = new RectangleShape();
            this.m_shape.Position = new Vector2f(0, 0);
            this.m_shape.Texture = Actor.s_tileset.Texture;
            this.m_shape.TextureRect = Actor.s_tileset.getRect(22);
            this.m_shape.Size = size;
        }

        public void ai(float delta, Battlefield battlefield, List<Actor> actorList)
        {
            // get closest other actor
            Actor other = Ai.getClosestOtherActor(this, actorList);

            // move towards it
            Vector2f direction = Utils.direction(this, other);
            this.m_transformable.Position += direction * delta * 32;
        }

        public void update(float delta)
        {
            this.m_transformable.Position += new Vector2f(delta * 16, 0);
        }

        public void draw(RenderWindow rw, RenderStates rs)
        {
            rs.Transform *= this.m_transformable.Transform;

            rw.Draw(this.m_shape, rs);
        }
    }
}
