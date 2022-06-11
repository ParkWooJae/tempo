using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScreenSizeText : MonoBehaviour
{
    public int[] width = new int[5];
    public int[] height = new int[10];
    public int loop = 0;
    public string[] MaxScreenSize = new string[10];
    string NowWidthSize,NowHeightSize,NowScreenSize;
    public TMP_Text ScreenText;
    int i;
    // Start is called before the first frame update
    void Start()
    {
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

    public void NowScreen(){
        NowWidthSize = (Screen.width).ToString();
        NowHeightSize = (Screen.height).ToString();
        NowScreenSize = NowWidthSize + "x" + NowHeightSize;
        ScreenText.text = (NowScreenSize);
        
        
       
    }
}
