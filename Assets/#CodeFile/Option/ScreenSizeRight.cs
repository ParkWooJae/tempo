using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScreenSizeRight : MonoBehaviour
{
    int[] width = new int[10];
    int[] height = new int[10];
    int loop = 0;
    string[] MaxScreenSize = new string[10];
    Button button;
    public TMP_Text ScreenSizeText;
    
    bool FullScreen;
    GameObject ScreenText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
        ScreenText = GameObject.Find("ScreenSizeText");             
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }  

    public void LoadScreenSize(){
        ScreenText = GameObject.Find("ScreenSizeText");
        loop = ScreenText.GetComponent<ScreenSizeText>().loop;
        width = ScreenText.GetComponent<ScreenSizeText>().width;
        height = ScreenText.GetComponent<ScreenSizeText>().height;
        MaxScreenSize = ScreenText.GetComponent<ScreenSizeText>().MaxScreenSize;
    }

    public void OnClickButton(){
        LoadScreenSize();
        FullScreen = Screen.fullScreen;
        ScreenSizeText.text = width[loop].ToString(); 
        if (loop > 0){
            loop -=1;            
            // ScreenSizeText.text = MaxScreenSize[loop];            
            Screen.SetResolution(width[loop],height[loop],FullScreen);
            Debug.Log(width[loop]);
            
            ScreenText.GetComponent<ScreenSizeText>().loop -= 1;    
        }
        else {
            return;
        }        
        
         
       
    }
    
    
}
