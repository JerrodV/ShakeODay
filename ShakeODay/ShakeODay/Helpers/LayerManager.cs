using System;
using System.Collections.Generic;
using System.Linq;

namespace ShakeOfTheDay.Helpers
{
    public enum Gamelayers
    { 
        Background = 0,
        GameArea1 = 1,
        GameArea2 = 2,
        GameArea3 = 3,
        GameArea4 = 4,
        GameArea5 = 5,
        GameArea6 = 6,
        GameArea7 = 7,
        GameArea8 = 8,
        UI = 9
    }

    public class LayerManager
    {
        public List<Layer> Layers { get; set; } 
        public LayerManager(Int32 layers)
        {
            this.Layers = new List<Layer>();
            for (int i = 0; i < layers; i++)
            {
                this.Layers.Add(new Layer());
            }
        }
        public List<Sprite> GetAllSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (Layer l in this.Layers)
            {
                foreach (Sprite s in l.Sprites)
                {
                    sprites.Add(s);
                }
            }
            return sprites;
        }

        public List<Sprite> GetSpritesByType<T>()
        {
            return this.GetAllSprites().Where(x => x.GetType() == typeof(T)).ToList();
        }

        public void Clear()
        { 
            foreach(Layer l in Layers)
            {
                l.Sprites.Clear();
            }
        }
    }

    public class Layer
    {
        private List<Sprite> _Sprites = new List<Sprite>();
        public List<Sprite> Sprites 
        {
            get
            {
                return _Sprites;
            }
            set
            {
                _Sprites = value;
            }
        }        
    }
}
