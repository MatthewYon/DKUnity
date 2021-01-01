using UnityEngine;

public class DisplayPanels : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    public void OnInventory()
    {
        canvas.SetActive(!canvas.activeSelf);

    }

}
