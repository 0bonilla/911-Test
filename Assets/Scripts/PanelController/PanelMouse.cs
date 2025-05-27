using UnityEngine;
using UnityEngine.EventSystems;

public class PanelMouse : MonoBehaviour
{
    public delegate void BuildingClickHandler(Vector3 transform);
    public static event BuildingClickHandler OnBuildingClick;
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        OnBuildingClick?.Invoke(transform.position);
    }
}
