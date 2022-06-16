using SFML.Graphics;

namespace game
{
    internal class BattleScreen : Screen
    {
        // variables
        private Battlefield m_battlefield;

        // methods
        public BattleScreen() : base()
        {
            this.m_battlefield = new Battlefield();
        }

        public override void update(float delta)
        {
            this.m_battlefield.update(delta);
            base.update(delta);
        }

        public override void draw(RenderWindow rw, RenderStates rs)
        {
            this.m_battlefield.draw(rw, rs);
            base.draw(rw, rs);
        }
    }
}
