using UnityEngine;

public class DisplayPanels : MonoBehaviour
{
   
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject EquipmentPanel;
    private int counter = 0;

    // Start is called before the first frame update
    private void Start()
    {
        InventoryPanel.SetActive(false);
        EquipmentPanel.SetActive(false);
    }
    // Update is called once per frame
    public void showHidePanel()
    {
        if (counter % 2 == 1)
        {
            InventoryPanel.SetActive(false);
            EquipmentPanel.SetActive(false);
        }
        else
        {
            InventoryPanel.SetActive(true);
            EquipmentPanel.SetActive(true);
        }
        counter++;
    }
}
