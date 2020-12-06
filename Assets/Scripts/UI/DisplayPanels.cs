using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanels : MonoBehaviour
{
   
    [SerializeField] private GameObject panel;
    private int counter = 0;
    // Start is called before the first frame update
    private void Start()
    {
        panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            showHidePanel();
    }

    private void showHidePanel()
    {
        if (counter % 2 == 1)
            panel.SetActive(false);
        else
            panel.SetActive(true);
        counter++;
    }
}
