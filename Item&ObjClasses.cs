using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;

public abstract class UaseableItem
{

}

public class StationaryObject
{
    private Texture2D _Texture;
    private Rectangle _Rectangle;
    private SpriteBatch _SB;
    private Color _Col;
    private float _Scale;
    private int _X;
    private int _Y;
    public StationaryObject(Rectangle rectangle, float Scale,int X,int Y)
    {
        _Rectangle = rectangle;
        _Scale = Scale;
        _X = X;
        _Y = Y;
    }

    public void Load(SpriteBatch SB, Texture2D Texture, Color Col)
    {
        _SB = SB;
        _Texture = Texture;
        _Col = Col;
    }
    
    public bool IsColliding(Character2D character)
    {
        return _Rectangle.Intersects(character.Rectangle);
    }
    public void Draw()
    {
        _SB.Draw(_Texture, new Vector2(_Rectangle.X, _Rectangle.Y),null, _Col, 0f, Vector2.Zero, _Scale, SpriteEffects.None, 0f);
    }
}