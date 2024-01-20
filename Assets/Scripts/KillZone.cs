using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    float dyingDuration;

    private void OnTriggerEnter(Collider other)
    {
        var shape = other.GetComponent<Shape>();
        if (shape)
        {
            if (dyingDuration <= 0f)
            {
                shape.Die();
            }
            else if (!shape.IsMarkedAsDying)
            {
                shape.AddBehavior<DyingShapeBehavior>().Initialize(shape, dyingDuration);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.matrix = transform.localToWorldMatrix;
        var c = GetComponent<Collider>();

        var b = c as BoxCollider;
        if (b != null)
        {
            Gizmos.DrawWireCube(b.center, b.size);
            return;
        }

        var s = c as SphereCollider;
        if (s != null)
        {
            Gizmos.DrawWireSphere(s.center, s.radius);
            return;
        }
    }
}
