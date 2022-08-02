using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maptest : MonoBehaviour
{
    public GameObject defaultMap;
    public GameObject sizeMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)){
            defaultMap.SetActive(false);
            sizeMap.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F3)){
            defaultMap.SetActive(true);
            sizeMap.SetActive(false);
        }
    }
}
