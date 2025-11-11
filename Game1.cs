using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_off_2025;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Bob _Bob;
    private StationaryObject Rock;
    private Chunk World;
    private List<StationaryObject> WorldObjects = new List<StationaryObject>();
    private bool MovingForward = true, MovingLeft = true, MovingBackward = true, MovingRight = true;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _Bob = new Bob(new Rectangle(400, 200,32,32), 1f, 20f, 20f);
        Rock = new StationaryObject(new Rectangle(0, 0,20,32), 1f, 200, 200);
        WorldObjects.Add(Rock);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _Bob.Load(_spriteBatch, Content.Load<Texture2D>("BobSpriteSheet"), Color.White);
        Rock.Load(_spriteBatch, Content.Load<Texture2D>("Rock"), Color.White);
        World = new Chunk(new Rectangle(-100,-100,400,400), _Bob, null, WorldObjects, 1f, 2,true);
        World.Load(_spriteBatch,Content.Load<Texture2D>("Sand"),Color.White);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState MyKey = Keyboard.GetState();
        World.Update(MyKey, ref MovingForward, ref MovingLeft, ref MovingBackward, ref MovingRight);
        _Bob.Update(MyKey);
    
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        World.Draw();
        _Bob.Draw();
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

}
