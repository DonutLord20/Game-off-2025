using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;

public abstract class Character2D
{
    protected Texture2D _SpriteSheet;
    protected Rectangle _Rectangle;
    protected Rectangle _SourceRectangle;
    protected Color _Col;
    protected SpriteBatch _SB;
    protected int _CurrentFrameX = 0, _CurrentFrameY = 0;
    protected float _Scale;

    public Character2D(Rectangle rectangle, float Scale)
    {
        _Rectangle = rectangle;
        _Scale = Scale;
        _SourceRectangle = new Rectangle(0, 0, _Rectangle.Width, _Rectangle.Height);
    }

    public void Load(SpriteBatch SB, Texture2D SpriteSheet, Color Col)
    {
        _SB = SB;
        _SpriteSheet = SpriteSheet;
        _Col = Col;
    }

    public virtual void Draw()
    {
        _SourceRectangle.X = _CurrentFrameX * _Rectangle.Width;
        _SourceRectangle.Y = _CurrentFrameY * _Rectangle.Height;
        _SB.Draw(_SpriteSheet, new Vector2(_Rectangle.X, _Rectangle.Y),_SourceRectangle, _Col, 0f, Vector2.Zero, _Scale, SpriteEffects.None, 0f);
    }

    abstract protected void MoveForward();
    abstract protected void MoveLeft();
    abstract protected void MoveBackward();
    abstract protected void MoveRight();

    public int X
    {
        get { return _Rectangle.X; }
    }

    public int Y
    {
        get { return _Rectangle.Y; }
    }

    public Rectangle Rectangle
    {
        get { return _Rectangle; }
    }

}


public class Bob : Character2D
{
    private float _HP;
    private float _MaxHP;
    private int _StartWidth, _StartHeight;
    public Bob(Rectangle rectangle, float Scale, float HP, float MaxHP) : base(rectangle, Scale)
    {
        _HP = HP;
        _MaxHP = MaxHP;
        _StartWidth = rectangle.Width;
        _StartHeight = rectangle.Height;
    }

    protected override void MoveBackward()
    {
        _CurrentFrameX = 0;
        _CurrentFrameY = 0;
        _Rectangle.Width = _StartWidth;
    }

    protected override void MoveRight()
    {
        _CurrentFrameX = 3;
        _CurrentFrameY = 0;
        _Rectangle.Width = _StartWidth / 2;
    }

    protected override void MoveForward()
    {
        _CurrentFrameX = 2;
        _CurrentFrameY = 0;
        _Rectangle.Width = _StartWidth;
    }

    protected override void MoveLeft()
    {
        _CurrentFrameX = 1;
        _CurrentFrameY = 0;
        _Rectangle.Width = _StartWidth / 2;
    }

    public void Update(KeyboardState MyKey)
    {
        if (MyKey.IsKeyDown(Keys.W)) { MoveForward(); _Rectangle.Y -= 5;}
        else if (MyKey.IsKeyDown(Keys.D)) { MoveRight(); _Rectangle.X += 5;}
        else if (MyKey.IsKeyDown(Keys.S)) { MoveBackward(); _Rectangle.Y += 5;}
        else if (MyKey.IsKeyDown(Keys.A)) { MoveLeft(); _Rectangle.X -= 5;}
    }

    public override void Draw()
    {
        _SourceRectangle.X = _CurrentFrameX * _StartWidth;
        _SourceRectangle.Y = _CurrentFrameY * _StartHeight;
        _SB.Draw(_SpriteSheet, new Vector2(_Rectangle.X, _Rectangle.Y), _SourceRectangle, _Col, 0f, Vector2.Zero, _Scale, SpriteEffects.None, 0f);
    }
}


