using DrawingLib.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace DrawingLib.Input
{
    public sealed class CustomMouse : ICustomMouse
    {

        private static CustomMouse _instance;
        public static CustomMouse Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomMouse();
                }
                return _instance;
            }
        }
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        public Point WindowPosition => _currentMouseState.Position;

        private CustomMouse()
        {
            _currentMouseState = Mouse.GetState();
            _previousMouseState = _currentMouseState;
        }

        public Vector2? GetScreenPosition(IScreen screen)
        {
            if (screen == null)
            {
                throw new ArgumentNullException("Screen is null");
            }

            Rectangle screenRect = screen.CalculateDestinationRectangle();
            Point windowPosition = WindowPosition;

            if (screenRect.Contains(windowPosition))
            {
                float X = (windowPosition.X - screenRect.X) / (float)screenRect.Width * screen.Width;
                float Y = (windowPosition.Y - screenRect.Y) / (float)screenRect.Height * screen.Height;
                return new Vector2(X, Y);
            }

            return null;
        }

        public bool IsLeftButtonClicked()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed &&
                   _previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsLeftButtonDown()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftButtonUp()
        {
            return _currentMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsMiddleButtonClicked()
        {
            return _currentMouseState.MiddleButton == ButtonState.Pressed &&
                   _previousMouseState.MiddleButton == ButtonState.Released;
        }

        public bool IsMiddleButtonDown()
        {
            return _currentMouseState.MiddleButton == ButtonState.Pressed;
        }

        public bool IsRightButtonClicked()
        {
            return _currentMouseState.RightButton == ButtonState.Pressed &&
                   _previousMouseState.RightButton == ButtonState.Released;
        }

        public bool IsRightButtonDown()
        {
            return _currentMouseState.RightButton == ButtonState.Pressed;
        }

        public void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }
    }
}
