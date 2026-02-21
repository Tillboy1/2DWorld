using UnityEngine;

public class HitLever : MonoBehaviour
{
    public GameObject[] Gates;
    public float GateToYLevel;
    public float distToPoint;
    private bool GateMoving;
    public float speed;

    public bool OneTimeInteraction = true;
    private bool Activated = false;
    public bool hitToInteract;

    public void Start()
    {
        if (!Activated)
        {
            transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 4f);
        }
    }

    public void Update()
    {
        if (GateMoving)
        {
            Gatemovement();
        }
    }

    public void Gatemovement()
    {
        distToPoint = Vector2.Distance(Gates[0].transform.localPosition, new Vector3(Gates[0].transform.localPosition.x, GateToYLevel, Gates[0].transform.localPosition.y));

        for (int i = 0; i < Gates.Length; i++)
        {
            Gates[i].transform.localPosition = Vector2.MoveTowards(Gates[i].transform.localPosition, new Vector2(Gates[i].transform.localPosition.x, GateToYLevel), speed * Time.deltaTime);
        }

        if (distToPoint < 0.1f)
        {
            GateMoving = false;
        }
    }

    public void Interact()
    {
        if (OneTimeInteraction)
        {
            if (!Activated)
            {
                Activated = true;
                transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -4f);

                GateMoving = true;
            }
        }
    }
}
