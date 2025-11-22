using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;

public class World
{
    protected Dictionary<Vector2,Chunk> _WorldChunks;
    protected List<Chunk> _VisibleChunks = new List<Chunk>();
    protected SpriteBatch _SB;
    protected Camera2D _Camera;
    private Bob _Player;

    public World(SpriteBatch SB,Dictionary<Vector2,Chunk> WorldChunks,Bob Player,Camera2D Camera)
    {
        _SB = SB;
        _WorldChunks = WorldChunks;
        _Player = Player;
        _Camera = Camera;
    }

    public World(SpriteBatch SB,Dictionary<Vector2,Chunk> WorldChunks,Camera2D Camera)
    {
        _SB = SB;
        _WorldChunks = WorldChunks;
        _Camera = Camera;
    }

    public virtual void Update()
    {
        KeyboardState MyKey = Keyboard.GetState();
        _Player.Update(MyKey);
        foreach (KeyValuePair<Vector2,Chunk> KVP in _WorldChunks)
        {
            _Player.ApplyCollisions(KVP.Value.CheckCollisions(_Player));
        }
        _Camera.Follow(new Vector2(_Player.X,_Player.Y));
    }

    public virtual void Draw()
    {
        foreach (KeyValuePair<Vector2,Chunk> KVP in _WorldChunks)
        {
            KVP.Value.Draw();
        }
        _Player.Draw();
    }
}