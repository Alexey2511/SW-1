using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SubCell
{
    Rectangle rect;
    Texture2D texture;
    int state;
    int ID;

    public SubCell(int x, int y, int id, Texture2D texture)
    {
        rect = new Rectangle(x, y, 50, 50);//размеры маленького квадрата
        this.texture = texture;
        ID = id;
        state = 0;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, rect, Color.White);
    }

    public int GetID()
    {
        return ID;
    }

    public int GetSubID()
    {
        return ID % 10;
    }

    public void Clone(SubCell subCell)
    {
        state = subCell.state;
        ID = subCell.ID;
        rect = subCell.rect;
        texture = subCell.texture;
    }

    public void ApplyTexture(Texture2D texture)
    {
        this.texture = texture;
    }

    public void ChangeState(int state)
    {
        this.state = state;
    }

    public int GetState()
    {
        return state;
    }
}

