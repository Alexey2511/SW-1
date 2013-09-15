using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Grid
    {
        Rectangle rect;
        Texture2D texture;
        List<Cell> cellList = new List<Cell>();
        int state;
        int posX, posY;
        const int length = 164;
        const int height = 10;
        public Grid(int x, int y, int px, int py, Texture2D rectangleDotted, Texture2D texture, Texture2D cellTexture, Texture2D smallTextureDotted, Texture2D subCellTexture)
        {
            rect = new Rectangle(x, y, 450, 450);//размеры главной разметки
            this.texture = subCellTexture;
            int cellID = 0;
            posX = x;
            posY = y;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (px == i && py == j)
                        cellList.Add(new Cell(posX, posY, cellID, texture, cellTexture));
                    else
                        cellList.Add(new Cell(posX, posY, cellID, rectangleDotted, cellTexture));
                    posX += 150;// расстояние между тройками или ширина клеки умноженная на три
                    cellID++;
                }
                posY += 150;//расстояние между тройками или ширина клеки умноженная на три
                posX = x;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
            foreach (Cell cell in cellList)
            {
                cell.Draw(spriteBatch);
            }
        }

        public SubCell GetSubCell(Vector2 position)
        {
            if (position.X < length || position.X > length + 450 || position.Y < height || position.Y > height + 450)
                return null;
            int tempXID = (int)((position.X - length) / 150.0);
            int tempYID = (int)((position.Y - height) / 150.0);
            int cellID = tempYID * 3 + tempXID;
            foreach (Cell cell in cellList)
            {
                if (cell.GetID() == cellID)
                {
                    return cell.GetSubCell(position);
                }
            }
            return null;
        }

        public void SetSubCell(SubCell subcell)
        {
            int id = subcell.GetID();
            id /= 10;
            cellList[id].SetSubCell(subcell);
        }
    }
