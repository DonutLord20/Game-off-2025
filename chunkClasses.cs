using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;

public class Camera2D
{
private Matrix _Transform;
private Vector2 _Position;
private int _Height,_Width;
public Camera2D(int Height,int Width)
{
    _Height = Height;
    _Width = Width;    
}

public void Follow(Vector2 Target)
{
    _Position = Target - new Vector2(_Width / 2,_Height / 2);
    _Transform = Matrix.CreateTranslation(new Vector3(-_Position,0));  
}

public Matrix Transform
{
     get {return _Transform;}   
}
}

public class Chunk
{
    private Texture2D _Texture;
    private Vector2 _Position;
    private float _Scale;
    private SpriteBatch _SB;
    private Color _Col;
    private static int _SeedX = 0;
    private static int _SeedY = 0;
    public const int CHUNK_SIZE = 128;
    public Chunk(float Scale)
    {
        _Position = new Vector2(_SeedX,_SeedY);
        _Scale = Scale;

         if (_SeedX == CHUNK_SIZE * 6)
        {
            _SeedX = 0;
            _SeedY += CHUNK_SIZE;
        }
        else
        {
            _SeedX += CHUNK_SIZE;
        }
    }

    public void Load(SpriteBatch SB,Texture2D Texture,Color Col)
    {
        _SB = SB;
        _Texture = Texture;
        _Col = Col;
    }

    public void Draw()
    {
        _SB.Draw(_Texture,_Position,null, _Col, 0f, Vector2.Zero, _Scale, SpriteEffects.None, 0f);
    }

    public Vector2 GetPosition()
    {
        return _Position;
    }
}