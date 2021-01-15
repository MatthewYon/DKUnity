using UnityEngine;

public class DisplayPanels : MonoBehaviour
{
    [SerializeField] private GameObject EquiScreen;
    [SerializeField] private GameObject InvScreen;
    [SerializeField] private GameObject Menu;

    private void Awake()
    {
        EquiScreen.SetActive(false);
        InvScreen.SetActive(false);
    }

    public void OnInventory()
    {
        EquiScreen.SetActive(!EquiScreen.activeSelf);
        InvScreen.SetActive(!InvScreen.activeSelf);
    }

    public void OnMenu()
    {
        Menu.SetActive(!Menu.activeSelf);
    }
}
