using DrawingLib.Graphics;
using DrawingLib.Input;
using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PaintDrops;

public class PaintDrops : Game
{
    private RenderTarget2D _renderTarget;
    private Screen screen;
    public CustomKeyboard _customKeyboard = CustomKeyboard.Instance;
    public CustomMouse _customMouse = CustomMouse.Instance;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ISpritesRenderer _spritesRenderer;
    private List<IShape> _shapes;
    private IShapesRenderer _shapesRenderer;
    private ISurface _surface;


    public PaintDrops()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        this.Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        _shapes = new List<IShape>();
        _renderTarget = new RenderTarget2D(GraphicsDevice, 640, 480);
        screen = new Screen(_renderTarget);
        _surface = PaintDropSimulationFactory.CreateSurface(screen.Width,screen.Height);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spritesRenderer = new SpritesRenderer(GraphicsDevice);
        _shapesRenderer= new ShapesRenderer(GraphicsDevice);


    }

    protected override void Update(GameTime gameTime)
    {
        _customKeyboard.Update();
        _customMouse.Update();

        if (_customMouse.IsRightButtonClicked())
        {
            _surface.Drops.Clear();

        }

        if (_customMouse.IsLeftButtonClicked())
        {
            
            Vector2? screenPosition = _customMouse.GetScreenPosition(screen);
            if (screenPosition.HasValue)
            {
                Random random = new Random();
                int red = random.Next(0, 256);
                int green = random.Next(0, 256);
                int blue = random.Next(0, 256);
                Colour randomColor = new Colour(red, green, blue);
                ICircle circle = ShapesFactory.CreateCircle(screenPosition.Value.X, screenPosition.Value.Y, 50, randomColor);

                IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);


                _surface.AddPaintDrop(drop);
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        screen.Set();
        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.White);
        _shapesRenderer.Begin();

        foreach (IPaintDrop drops in _surface.Drops)
        {
            _shapesRenderer.DrawShape(drops.Circle);

        }

        _shapesRenderer.End();
        screen.UnSet();
        screen.Present(_spritesRenderer, true);


        base.Draw(gameTime);
    }
}
