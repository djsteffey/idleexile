using SFML.Graphics;
using SFML.System;

namespace game
{
    internal class Battlefield
    {
        // variables
        private RectangleShape m_shape;
        private Transformable m_transformable;
        private List<Actor> m_actors;

        // methods
        public Battlefield()
        {
            // position
            this.m_transformable = new Transformable();
            
            // background
            this.m_shape = new RectangleShape();
            this.m_shape.Position = new Vector2f(0, 0);
            this.m_shape.FillColor = Color.Black;
            this.m_shape.OutlineColor = Color.White;
            this.m_shape.OutlineThickness = -2;
            this.m_shape.Size = new Vector2f(720 - 8, 720 - 8);

            // make some initial actors
            this.m_actors = new List<Actor>();
            for (int i = 0; i < 10; ++i)
            {
                Actor actor = new Actor(
                    new Vector2f(Utils.randomInt(4, (int)(this.m_shape.Size.X - 4 - 48)), Utils.randomInt(4, (int)(this.m_shape.Size.Y - 4 - 48))),
                    new Vector2f(48, 48)
                ); ;
                this.m_actors.Add(actor);
            }

            // position to center
            this.m_transformable.Position = new Vector2f((1280 - this.m_shape.Size.X) / 2, (720 - this.m_shape.Size.Y) / 2);
        }

        public void update(float delta)
        {
            // update actors
            foreach (Actor actor in this.m_actors)
            {
                actor.update(delta);
            }
        }

        public void draw(RenderWindow rw, RenderStates rs)
        {
            // adjust to position
            rs.Transform *= this.m_transformable.Transform;

            // draw background
            rw.Draw(this.m_shape, rs);

            // draw actors
            foreach (Actor actor in this.m_actors)
            {
                actor.draw(rw, rs);
            }
        }
    }
}
