using System.IO;
using UnityEngine;

public class GameDataWriter
{
    BinaryWriter writer;

    public GameDataWriter(BinaryWriter writer)
    {
        this.writer = writer;
    }

    public void Write(int value)
    {
        writer.Write(value);
    }

    public void Write(float value)
    {
        writer.Write(value);
    }

    public void Write(Quaternion value)
    {
        writer.Write(value.x);
        writer.Write(value.y);
        writer.Write(value.z);
        writer.Write(value.w);
    }

    public void Write(Vector3 value)
    {
        writer.Write(value.x);
        writer.Write(value.y);
        writer.Write(value.z);
    }

    public void Write(Color color)
    {
        writer.Write(color.r);
        writer.Write(color.g);
        writer.Write(color.b);
        writer.Write(color.a);
    }

    public void Write(Random.State value)
    {
        writer.Write(JsonUtility.ToJson(value));
    }

    public void Write(ShapeInstance value)
    {
        writer.Write(value.IsValid ? value.Shape.SaveIndex : -1);
    }
}