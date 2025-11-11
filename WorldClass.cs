using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;


public class Chunk
{
    protected Texture2D _Texture;
    protected Rectangle _Rectangle;
    protected SpriteBatch _SB;
    protected Color _Col;
    protected List<StationaryObject> _Objects;
    protected List<Character2D> _NPC;
    protected List<Character2D> _Party = new List<Character2D>();
    protected Character2D _Player;
    protected float _Scale;
    protected int _MoveSpeed;
    protected bool _IsDrawn;
    public Chunk(Rectangle rectangle,Character2D Player, List<Character2D> NPC, List<StationaryObject> Objects, float Scale,int MoveSpeed,bool IsDrawn)
    {
        _Rectangle = rectangle;
        _Player = Player;
        _NPC = NPC;
        _Objects = Objects;
        _Scale = Scale;
        _MoveSpeed = MoveSpeed;
        _IsDrawn = IsDrawn;
        _Party.Add(_Player);
    }

    public void Load(SpriteBatch SB, Texture2D Texture, Color Col)
    {
        _SB = SB;
        _Texture = Texture;
        _Col = Col;
    }

    public void Update(KeyboardState MyKey, ref bool CanMoveForward, ref bool CanMoveLeft, ref bool CanMoveBackward, ref bool CanMoveRight)
    {
        if (MyKey.IsKeyDown(Keys.W) && CanMoveForward) { _Rectangle.Y += _MoveSpeed; }
        else if (MyKey.IsKeyDown(Keys.A) && CanMoveLeft) { _Rectangle.X += _MoveSpeed; }
        else if (MyKey.IsKeyDown(Keys.S) && CanMoveBackward) { _Rectangle.Y -= _MoveSpeed; }
        else if (MyKey.IsKeyDown(Keys.D) && CanMoveRight) { _Rectangle.X -= _MoveSpeed; }

        if (_IsDrawn)
        {
            foreach (StationaryObject Object in _Objects)
            {
                Object.Update(this);

                if (MyKey.IsKeyDown(Keys.W) && Object.IsColliding(_Player) || (MyKey.GetPressedKeys().Length == 0 && !CanMoveForward)) { CanMoveForward = false; }
                else { CanMoveForward = true; }
                if (MyKey.IsKeyDown(Keys.A) && Object.IsColliding(_Player) || (MyKey.GetPressedKeys().Length == 0 && !CanMoveLeft)) { CanMoveLeft = false; }
                else { CanMoveLeft = true; }
                if (MyKey.IsKeyDown(Keys.S) && Object.IsColliding(_Player) || (MyKey.GetPressedKeys().Length == 0 && !CanMoveBackward)) { CanMoveBackward = false; }
                else { CanMoveBackward = true; }
                if (MyKey.IsKeyDown(Keys.D) && Object.IsColliding(_Player) || (MyKey.GetPressedKeys().Length == 0 && !CanMoveRight)) { CanMoveRight = false; }
                else { CanMoveRight = true; }
            }
        }
    }

    public void Draw()
    {
        _SB.Draw(_Texture, new Vector2(_Rectangle.X, _Rectangle.Y),null, _Col, 0f, Vector2.Zero, _Scale, SpriteEffects.None, 0f);
        foreach (StationaryObject Object in _Objects)
        {
            Object.Draw();
        }
    }
    


    public int X
    {
        get { return _Rectangle.X; }
    }

    public int Y
    {
        get { return _Rectangle.Y; }
    }
}

