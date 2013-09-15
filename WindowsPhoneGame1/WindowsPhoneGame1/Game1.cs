using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace WindowsPhoneGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //
        Texture2D rectangleGray;
        Texture2D rectangleDotted;
        Texture2D bigTexture;
        Texture2D smallTexture;
        Texture2D smallTextureDotted;
        Grid grid;
        Cell cell;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Частота кадра на Windows Phone по умолчанию — 30 кадров в секунду.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Дополнительный заряд аккумулятора заблокирован.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Позволяет игре выполнить инициализацию, необходимую перед запуском.
        /// Здесь можно запросить нужные службы и загрузить неграфический
        /// контент.  Вызов base.Initialize приведет к перебору всех компонентов и
        /// их инициализации.
        /// </summary>
        protected override void Initialize()
        {
            // ЗАДАЧА: добавьте здесь логику инициализации
            base.Initialize();
        }

        /// <summary>
        /// LoadContent будет вызываться в игре один раз; здесь загружается
        /// весь контент.
        /// </summary>
        protected override void LoadContent()
        {
            // Создайте новый SpriteBatch, который можно использовать для отрисовки текстур.
            //загрузка текстуры квадрата
            rectangleDotted = Content.Load<Texture2D>(@"rectangleDottedKrest");
            rectangleGray = Content.Load<Texture2D>(@"rectangleOrangeKrest");
            bigTexture = Content.Load<Texture2D>(@"bigTexture");
            smallTexture = Content.Load<Texture2D>(@"smallTexture");
            smallTextureDotted = Content.Load<Texture2D>(@"smallTextureDotted");

            grid = new Grid(164, 10, 0, 1, rectangleDotted, rectangleGray, smallTextureDotted, bigTexture, bigTexture);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // ЗАДАЧА: используйте здесь this.Content для загрузки контента игры
        }

        /// <summary>
        /// UnloadContent будет вызываться в игре один раз; здесь выгружается
        /// весь контент.
        /// </summary>
        protected override void UnloadContent()
        {
            // ЗАДАЧА: выгрузите здесь весь контент, не относящийся к ContentManager
        }

        /// <summary>
        /// Позволяет игре запускать логику обновления мира,
        /// проверки столкновений, получения ввода и воспроизведения звуков.
        /// </summary>
        /// <param name="gameTime">Предоставляет моментальный снимок значений времени.</param>
        protected override void Update(GameTime gameTime)
        {
            // Позволяет выйти из игры
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // ЗАДАЧА: добавьте здесь логику обновления
            //Получаем коллекцию объектов, содержащих информацию о касаниях экрана
            TouchCollection touchLocations = TouchPanel.GetState();
            //Перебираем коллекцию, присваивая объекту координаты касания
            foreach (TouchLocation touchLocation in touchLocations)
            {
                if (touchLocation.State == TouchLocationState.Pressed)
                {
                    SubCell t = grid.GetSubCell(touchLocation.Position);
                    if (t == null)
                        continue;
                    t.ApplyTexture(rectangleGray);
                    t.ChangeState(1);
                    grid.SetSubCell(t);
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Вызывается, когда игра отрисовывается.
        /// </summary>
        /// <param name="gameTime">Предоставляет моментальный снимок значений времени.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            // ЗАДАЧА: добавьте здесь код отрисовки
            
            spriteBatch.Begin();
            grid.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
