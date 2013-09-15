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
            // ������� ����� �� Windows Phone �� ��������� � 30 ������ � �������.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // �������������� ����� ������������ ������������.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// ��������� ���� ��������� �������������, ����������� ����� ��������.
        /// ����� ����� ��������� ������ ������ � ��������� �������������
        /// �������.  ����� base.Initialize �������� � �������� ���� ����������� �
        /// �� �������������.
        /// </summary>
        protected override void Initialize()
        {
            // ������: �������� ����� ������ �������������
            base.Initialize();
        }

        /// <summary>
        /// LoadContent ����� ���������� � ���� ���� ���; ����� �����������
        /// ���� �������.
        /// </summary>
        protected override void LoadContent()
        {
            // �������� ����� SpriteBatch, ������� ����� ������������ ��� ��������� �������.
            //�������� �������� ��������
            rectangleDotted = Content.Load<Texture2D>(@"rectangleDottedKrest");
            rectangleGray = Content.Load<Texture2D>(@"rectangleOrangeKrest");
            bigTexture = Content.Load<Texture2D>(@"bigTexture");
            smallTexture = Content.Load<Texture2D>(@"smallTexture");
            smallTextureDotted = Content.Load<Texture2D>(@"smallTextureDotted");

            grid = new Grid(164, 10, 0, 1, rectangleDotted, rectangleGray, smallTextureDotted, bigTexture, bigTexture);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // ������: ����������� ����� this.Content ��� �������� �������� ����
        }

        /// <summary>
        /// UnloadContent ����� ���������� � ���� ���� ���; ����� �����������
        /// ���� �������.
        /// </summary>
        protected override void UnloadContent()
        {
            // ������: ��������� ����� ���� �������, �� ����������� � ContentManager
        }

        /// <summary>
        /// ��������� ���� ��������� ������ ���������� ����,
        /// �������� ������������, ��������� ����� � ��������������� ������.
        /// </summary>
        /// <param name="gameTime">������������� ������������ ������ �������� �������.</param>
        protected override void Update(GameTime gameTime)
        {
            // ��������� ����� �� ����
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // ������: �������� ����� ������ ����������
            //�������� ��������� ��������, ���������� ���������� � �������� ������
            TouchCollection touchLocations = TouchPanel.GetState();
            //���������� ���������, ���������� ������� ���������� �������
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
        /// ����������, ����� ���� ��������������.
        /// </summary>
        /// <param name="gameTime">������������� ������������ ������ �������� �������.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            // ������: �������� ����� ��� ���������
            
            spriteBatch.Begin();
            grid.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
