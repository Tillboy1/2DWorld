using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimiter : MonoBehaviour
{
    [Header("Direction Exemption")]
    public bool north;
    public bool east;
    public bool south;
    public bool west;

    [Header("Size Of Space")]
    public Vector2 SizeCapasity;
}
