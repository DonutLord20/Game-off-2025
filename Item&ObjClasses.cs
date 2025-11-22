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
    public StationaryObject(Rectangle rectangle, float Scale)
    {
        _Rectangle = rectangle;
        _Scale = Scale;
    }

    public void Load(SpriteBatch SB, Texture2D Texture, Color Col)
    {
        _SB = SB;
        _Texture = Texture;
        _Col = Col;
    }
    

    public void Draw()
    {
        _SB.Draw(_Texture, new Vector2(_Rectangle.X, _Rectangle.Y),null, _Col, 0f, Vector2.Zero, _Scale, SpriteEffects.None, 0f);
    }

    public int X
    {
        get {return _Rectangle.X;}
        set {_Rectangle.X = value;}
    }

    public int Y
    {
        get {return _Rectangle.Y;}
        set {_Rectangle.Y = value;}
    }

    public Rectangle Rectangle
    {
        get{return _Rectangle;}
    }
}