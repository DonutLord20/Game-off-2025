using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Camera2D Camera;
    private Bob _Player;
    private Dictionary<Vector2,Chunk> WorldChunks = new Dictionary<Vector2, Chunk>();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Camera = new Camera2D(GraphicsDevice.Viewport.Height,GraphicsDevice.Viewport.Width);
        _Player = new Bob(new Rectangle(200,200,32,32),1f,5,5);
        Chunk Temp;
        for (int i = 0; i < 36; i++)
        {
            Temp = new Chunk(1f);
            WorldChunks.Add(Temp.GetPosition(),Temp);
        }
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
       _Player.Load(_spriteBatch,Content.Load<Texture2D>("BobSpriteSheet"),Color.White);

        foreach (KeyValuePair<Vector2,Chunk> KVP in WorldChunks)
        {
            KVP.Value.Load(_spriteBatch,Content.Load<Texture2D>("Sand"),Color.White);
        }
       
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState MyKey = Keyboard.GetState();
        _Player.Update(MyKey);
        Camera.Follow(new Vector2(_Player.X,_Player.Y));
       
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp,transformMatrix: Camera.Transform);
        foreach (KeyValuePair<Vector2,Chunk> KVP in WorldChunks)
        {
            KVP.Value.Draw();
        }

        _Player.Draw();
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

}
