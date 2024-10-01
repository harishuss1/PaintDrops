using DrawingLib.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Input
{
    public sealed class CustomKeyboard : ICustomKeyboard
    {
        public KeyboardState _currentKeyboardState;
        public KeyboardState _previousKeyboardState;

        private static CustomKeyboard _instance;
        public static CustomKeyboard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomKeyboard();
                }
                return _instance;
            }
        }
        private CustomKeyboard()
        {
            _currentKeyboardState = Keyboard.GetState();
            _previousKeyboardState = _currentKeyboardState;
        }
        public bool IsKeyClicked(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
        }

        public bool IsKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        public void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }
    }
}

