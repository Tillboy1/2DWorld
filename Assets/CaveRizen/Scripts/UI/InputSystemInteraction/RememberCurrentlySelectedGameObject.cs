using UnityEngine;
using UnityEngine.EventSystems;

public class RememberCurrentlySelectedGameObject : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject LastSelectedElement;


    public void Reset()
    {
        eventSystem = FindFirstObjectByType<EventSystem>();

        if (!eventSystem)
        {
            Debug.Log("There is no event system in this scene");
            return;
        }

        eventSystem.SetSelectedGameObject(LastSelectedElement.gameObject);
    }

    private void Update()
    {
        if (!eventSystem)
            return;

        if(eventSystem.currentSelectedGameObject &&  LastSelectedElement != eventSystem.currentSelectedGameObject)
            LastSelectedElement = eventSystem.currentSelectedGameObject;

        if (!eventSystem.currentSelectedGameObject && LastSelectedElement)
            eventSystem.SetSelectedGameObject(LastSelectedElement);
    }
}
