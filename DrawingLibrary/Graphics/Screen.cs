using DrawingLib.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Graphics
{
    public class Screen : IScreen
    {

        private RenderTarget2D _renderTarget;
        private GraphicsDevice _graphicsDevice;

        public int Height => _renderTarget.Height;
        public int Width => _renderTarget.Width;

        public Screen(RenderTarget2D renderTarget)
        {
            _renderTarget = renderTarget;
            _graphicsDevice = renderTarget.GraphicsDevice;
        }

        

        /// <summary>
        /// Draw sprites to the window.This is performed by using the spritesRenderer to begin drawing,
        /// drawing with the computed rectangle, and ending the batch
        /// </summary>
        /// <param name = "spritesRenderer" > The sprites to be drawn</param>
        /// <param name = "textureFiltering" ></ param >
        /// < exception cref= "ArgumentNullException" > Throws if sprites renderer is null</exception>
        /// 

        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering)
        {
            
            if (spritesRenderer == null)
            {
                throw new ArgumentNullException("SpriteRenderer null");
            }

            spritesRenderer.Begin(textureFiltering);

            Rectangle calculatedRectangle = CalculateDestinationRectangle();

            spritesRenderer.Draw(_renderTarget, calculatedRectangle, Color.White);

            spritesRenderer.End();

        }

        /// <summary>
        /// Enables drawing on the render target. This is done by setting the GraphicsDevice render target 
        /// to a render target object
        /// </summary>
        /// <exception cref="Exception">Throws if screen is already set</exception>
        /// 
       public void Set()
        {
            _graphicsDevice.SetRenderTarget(_renderTarget);
        }

        /// <summary>
        /// Removes drawing on the render target. This is done by setting the GraphicsDevice render target to null
        /// </summary>
        /// <exception cref="Exception">Throws if screen is already unset</exception>
        /// 
        public void UnSet()
        {
            _graphicsDevice.SetRenderTarget(null);

        }

        /// <summary>
        /// Computes the rectangle that fits inside the windows given the screen size. 
        /// Computes the aspect ratio of the window versus the screen and adds a border to either the top or bottom or to the left or right sides
        /// </summary>
        /// <returns>A rectangle whose coordinates and size represent where the screen should be drawn with respect to the window</returns>
        /// <remarks>Note, the coordinate system of the window is (0,0) in the upper left corner with positive X right and positive Y down</remarks>
        public Rectangle CalculateDestinationRectangle()
        {
            int windowWidth = _graphicsDevice.Viewport.Width;
            int windowHeight = _graphicsDevice.Viewport.Height;

            float screenAspectRatio = (float)Width / Height;
            float windowAspectRatio = (float)windowWidth / windowHeight;

            int drawWidth, drawHeight;
            if (windowAspectRatio > screenAspectRatio)
            {
                drawHeight = windowHeight;
                drawWidth = (int)(windowHeight * screenAspectRatio);
            }
            else
            {
                drawWidth = windowWidth;
                drawHeight = (int)(windowWidth / screenAspectRatio);
            }

            int drawX = (windowWidth - drawWidth) / 2;
            int drawY = (windowHeight - drawHeight) / 2;

            return new Rectangle(drawX, drawY, drawWidth, drawHeight);
        }

        public void Dispose()
        {
            _renderTarget.Dispose();
        }


    }
}
