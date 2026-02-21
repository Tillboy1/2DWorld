using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetUiSelectOnInteraction : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Selectable elementToSelect;

    [Header("Visualisation")]
    [SerializeField] private bool showVisulisation;
    [SerializeField] private Color navigationColour = Color.cyan;

    private void OnDrawGizmos()
    {
        if(!showVisulisation)
            return;

        if (elementToSelect != null)
            return;

        Gizmos.color = navigationColour;
        Gizmos.DrawLine(gameObject.transform.position, elementToSelect.gameObject.transform.position);
    }

    private void Reset()
    {
        eventSystem = FindFirstObjectByType<EventSystem>();

        if (eventSystem == null)
            Debug.Log("There is no event system");
    }

    public void JumpToElement()
    {
        Debug.Log(elementToSelect.gameObject.name);
        if (eventSystem == null)
            Debug.Log("There is no event system");
        if (elementToSelect == null)
            Debug.Log("there is no destionation");

        eventSystem.SetSelectedGameObject(elementToSelect.gameObject);
    }
}