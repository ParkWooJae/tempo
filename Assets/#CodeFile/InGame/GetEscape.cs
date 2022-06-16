using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetEscape : MonoBehaviour
{
    public GameObject Exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetEscapeButton();
    }

    public void GetEscapeButton(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Exit.SetActive(true);
        }
    }
}
