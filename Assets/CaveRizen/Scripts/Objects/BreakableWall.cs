using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    int CurrentHealth = 3;
    public GameObject NextRoomBreakable;
    public GameObject[] Doorways;

    public void TakeDamage()
    {
        CurrentHealth--;
        if(CurrentHealth <= 0)
        {
            BreakWall();
        }
    }
    public void BreakWall()
    {
        if(NextRoomBreakable != null)
        {
            Destroy(NextRoomBreakable);
        }
        Destroy(this.gameObject);

        if (Doorways[0] != null)
        {
            Doorways[0].SetActive(true);
            Doorways[1].SetActive(true);
        }
    }
}
