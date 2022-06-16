using SFML.Graphics;

namespace game
{
    internal class Tileset
    {
        // variables
        private Texture m_texture;
        private int m_tileSize;
        private List<IntRect> m_tiles;

        // properties
        public Texture Texture
        {
            get { return this.m_texture; }
        }

        // methods
        public Tileset(Texture texture, int tileSize)
        {
            this.m_texture = texture;
            this.m_tileSize = tileSize;

            this.m_tiles = new List<IntRect>();
            for (int y = 0; y < this.m_texture.Size.Y; y += this.m_tileSize)
            {
                for (int x = 0; x < this.m_texture.Size.X; x += tileSize)
                {
                    this.m_tiles.Add(new IntRect(x, y, this.m_tileSize, this.m_tileSize));
                }
            }
        }

        public IntRect getRect(int index)
        {
            return this.m_tiles[index];
        }
    }
}
