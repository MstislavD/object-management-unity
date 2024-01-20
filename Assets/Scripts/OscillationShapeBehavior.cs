using UnityEngine;

public class OscillationShapeBehavior : ShapeBehavior
{
    float previousOscillation;

    public Vector3 Offset { get; set; }

    public float Frequency { get; set; }

    public override ShapeBehaviorType BehaviorType => ShapeBehaviorType.Oscillation;

    public override bool GameUpdate(Shape shape)
    {
        float oscillation = Mathf.Sin(2f * Mathf.PI * Frequency * shape.Age);
        shape.transform.localPosition += (oscillation - previousOscillation) * Offset;
        previousOscillation = oscillation;
        return true;
    }

    public override void Load(GameDataReader reader)
    {
        Offset = reader.ReadVector3();
        Frequency = reader.ReadFloat();
        previousOscillation = reader.ReadFloat();
    }

    public override void Recycle()
    {
        previousOscillation = 0f;
        ShapeBehaviorPool<OscillationShapeBehavior>.Reclaim(this);
    }

    public override void Save(GameDataWriter writer)
    {
        writer.Write(Offset);
        writer.Write(Frequency);
        writer.Write(previousOscillation);
    }
}
