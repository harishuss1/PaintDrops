using DrawingLib.Graphics;
using DrawingLib.Input;
using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PaintDropSimulation;
using PatternGenerationLib;
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
    private IShapesRenderer _shapesRenderer;
    private ISurface _surface;
    private IPatternGenerator _patternGenerator;
    private bool _isPatternGenerating;
    private SpriteFont _font;
    private int _currentRadius;
    private List<IPatternGenerator> _patterns;
    private int _currentPatternIndex;

    public PaintDrops()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        this.Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        _renderTarget = new RenderTarget2D(GraphicsDevice, 640, 480);
        screen = new Screen(_renderTarget);
        _surface = PaintDropSimulationFactory.CreateSurface(screen.Width,screen.Height);


        _patterns = new List<IPatternGenerator>
        {   
        PatternGenerationFactory.CreatePhylloPattern(10),
        PatternGenerationFactory.CreateSpiroPattern(100, 6)
        };
        _currentPatternIndex = 0;
        _patternGenerator = _patterns[_currentPatternIndex];
        _surface.PatternGeneration += _patternGenerator.CalculatePatternPoint;

        _currentRadius = 50;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spritesRenderer = new SpritesRenderer(GraphicsDevice);
        _shapesRenderer= new ShapesRenderer(GraphicsDevice);
        _font = Content.Load<SpriteFont>("Counter");


    }

    protected override void Update(GameTime gameTime)
    {
        _customKeyboard.Update();
        _customMouse.Update();

        if (_customKeyboard.IsKeyClicked(Keys.Up))
        {
            _currentRadius = Math.Min(_currentRadius + 10, 150);
        }
        if (_customKeyboard.IsKeyClicked(Keys.Down))
        {
            _currentRadius = Math.Max(_currentRadius - 10, 10);
        }

        if (_customKeyboard.IsKeyClicked(Keys.M))
        {
            _isPatternGenerating = true; 
        }
        if (_customKeyboard.IsKeyClicked(Keys.E))
        {
            _isPatternGenerating = false;
        }

        if (_customKeyboard.IsKeyClicked(Keys.P))
        {
            _surface.PatternGeneration -= _patternGenerator.CalculatePatternPoint;

            _currentPatternIndex = (_currentPatternIndex + 1) % _patterns.Count;
            _patternGenerator = _patterns[_currentPatternIndex];

            _surface.PatternGeneration += _patternGenerator.CalculatePatternPoint;
        }

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
                ICircle circle = ShapesFactory.CreateCircle(screenPosition.Value.X, screenPosition.Value.Y, _currentRadius, randomColor);

                IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);


                _surface.AddPaintDrop(drop);
            }
        }
        if (_isPatternGenerating)
        {
            _surface.GeneratePaintDropPattern(5, new Colour(255, 0, 0)); 
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

        _spriteBatch.Begin();
        string radiusText = $"Radius: {_currentRadius}";

        Vector2 textSize = _font.MeasureString(radiusText);

        Vector2 textPosition = new Vector2(screen.Width - textSize.X, 0);

        _spriteBatch.DrawString(_font, radiusText, textPosition, Microsoft.Xna.Framework.Color.Black);
        _spriteBatch.End();
        screen.UnSet();
        screen.Present(_spritesRenderer, true);


        base.Draw(gameTime);
    }
}
