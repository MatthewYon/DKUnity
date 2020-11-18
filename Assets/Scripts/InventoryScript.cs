using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (gameObject.GetComponent<Canvas>().enabled)
                gameObject.GetComponent<Canvas>().enabled = false;
            else
                gameObject.GetComponent<Canvas>().enabled = true;
        }
    }
}
