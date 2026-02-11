using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<GameObject> Attackobject;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Attackobject.Add(collision.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Attackobject.Remove(collision.gameObject);
    }
}
