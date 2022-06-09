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
    string NowWidthSize,NowHeightSize,NowScreenSize;
    bool FullScreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
        NowScreen();
        getScreenSize();        
        
        
        
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void getScreenSize(){
        Resolution[] resolutions = Screen.resolutions;
        foreach(Resolution res in resolutions){
            if (res.width % 16 == 0 && res.height % 9 == 0 && (res.width - res.height) % 7 == 0){               
                MaxScreenSize[loop] = (res.width + "x" + res.height);
                width[loop] = res.width;
                height[loop] = res.height;
                loop += 1;   
            }
        }
        loop -=1;
    }   

    public void OnClickButton(){
        
        FullScreen = Screen.fullScreen;
        if (loop > 0){
            loop -=1;
            ScreenSizeText.text = MaxScreenSize[loop];
            Screen.SetResolution(width[loop],height[loop],FullScreen);
        }
        else {
            return;
        }
        
       
        
    }
    public void NowScreen(){
        NowWidthSize = (Screen.width).ToString();
        NowHeightSize = (Screen.height).ToString();
        NowScreenSize = NowWidthSize + "x" + NowHeightSize;
        ScreenSizeText.text = (NowScreenSize);
    }
    
}
