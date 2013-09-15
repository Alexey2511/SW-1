using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Cell
{
    List<SubCell> subCellList = new List<SubCell>();
    Rectangle rect;
    Texture2D texture;
    int id;
    int state;
    int posX, posY;
    const int length = 164;
    const int height = 10;

    public Cell(int x, int y, int ID, Texture2D texture, Texture2D CellTexture)
    {
        rect = new Rectangle(x, y, 150, 150);//размеры разметки в большом квадрате

        this.texture = CellTexture;
        id = ID;
        int cellID = id * 10;
        posX = x;
        posY = y;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                subCellList.Add(new SubCell(posX, posY, cellID, texture));
                posX += 50;//заменить на ширину клетки
                cellID++;
            }
            posY += 50;//заменить на высоту клетки
            posX = x;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, rect, Color.White);
        foreach (SubCell cell in subCellList)
        {
            if (cell.GetState() == 0)
                cell.Draw(spriteBatch);
        }
    }

    public int GetID()
    {
        return id;
    }

    public SubCell GetSubCell(Vector2 position)
    {

        int tempXID = (int)((position.X - rect.X) / 50.0);
        int tempYID = (int)((position.Y - rect.Y) / 50.0);
        int cellID = tempYID * 3 + tempXID;
        foreach (SubCell subCell in subCellList)
        {
            if (subCell.GetSubID() == cellID)
            {
                return subCell;
            }
        }
        return null;
    }

    public void SetSubCell(SubCell subCell)
    {
        int id = subCell.GetID() % 10;
        subCellList[id].Clone(subCell);
    }
}
