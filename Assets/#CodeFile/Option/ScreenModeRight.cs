using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenModeRight : MonoBehaviour
{
    Button button;
    public GameObject FullScreen;
    public GameObject WindowScreen;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickButton(){
        int setWidth = Screen.width;
        int setHeight = Screen.height;

        if (WindowScreen.activeSelf == true){
            WindowScreen.SetActive(false);
            FullScreen.SetActive(true);
            Screen.SetResolution(setWidth,setHeight,true);
        }
        
        else if(WindowScreen.activeSelf == false){
            WindowScreen.SetActive(true);
            FullScreen.SetActive(false);
            Screen.SetResolution(setWidth,setHeight,false);
        }
    }

}
