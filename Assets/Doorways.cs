using UnityEngine;

public enum Direction
{
    Left,
    Right, 
    Down
}
public class Doorways : MonoBehaviour
{
    public Vector2 LocationToGo;
    public Direction Direct;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered field");

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.transform.position = new Vector3(LocationToGo.x, LocationToGo.y, collision.transform.position.z);

            switch (Direct)
            {
                case Direction.Left:
                    Debug.Log("Going Left");
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-900, 1600));
                    break;
                case Direction.Right:
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(900, 1600));
                    break;
                case Direction.Down:
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
                    break;
            }
        }
    }
}
