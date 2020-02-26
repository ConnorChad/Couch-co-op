using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int greenPadCount;
    public int redPadCount;

    public GameObject greenDoorRight;
    public GameObject greenDoorLeft;

    public GameObject redDoorRight;
    public GameObject redDoorLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (greenPadCount == 2)
        {
            greenDoorRight.gameObject.SetActive(false);
            greenDoorLeft.gameObject.SetActive(false);
        }

        if (redPadCount == 2)
        {
            redDoorRight.gameObject.SetActive(false);
            redDoorLeft.gameObject.SetActive(false);
        }
    }
}
