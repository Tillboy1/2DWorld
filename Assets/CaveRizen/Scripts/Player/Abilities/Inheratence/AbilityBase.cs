using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    public float Range;

    public GameObject playerObject;
    public abstract void Activate();
}
