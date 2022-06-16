using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game
{
    internal class Game
    {
        // variables
        private bool m_running;
        private Screen m_currentScreen;
        private Screen m_nextScreen;

        // methods
        public Game()
        {
            this.m_running = false;
            this.m_currentScreen = null;
            this.m_nextScreen = null;
        }

        public void run()
        {
            // check if already running
            if (this.m_running)
            {
                // bail
                return;
            }

            // flag running
            this.m_running = true;

            // create window
            RenderWindow rw = new RenderWindow(new VideoMode(1280, 720), "Idle Exile", Styles.Close);
            rw.KeyPressed += onWindowKeyPressed;

            // initial screen
            this.m_nextScreen = new BattleScreen();

            // timing
            Clock clock = new Clock();
            clock.Restart();

            // loop
            while (this.m_running)
            {
                // next screen
                if (this.m_nextScreen != null)
                {
                    this.m_currentScreen = this.m_nextScreen;
                    this.m_nextScreen = null;
                }

                // events
                rw.DispatchEvents();

                // update
                float delta = clock.Restart().AsSeconds();
                if (this.m_currentScreen != null)
                {
                    this.m_currentScreen.update(delta);
                }

                // draw
                rw.Clear();
                if (this.m_currentScreen != null)
                {
                    this.m_currentScreen.draw(rw, RenderStates.Default);
                }
                rw.Display();
            }
        }

        private void onWindowKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                this.m_running = false;
            }
        }
    }
}
