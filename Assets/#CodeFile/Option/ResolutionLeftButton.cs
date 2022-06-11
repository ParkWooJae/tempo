using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionLeftButton : MonoBehaviour
{
    Button button;
    public GameObject text;
    public List<Resolution> resolutions_Right = new List<Resolution>();
    public int resolution_Now;
    public TMP_Text text_Tmp;
    bool FullScreen;
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
        GetResolution();

    }

    public void GetResolution(){
        resolutions_Right = text.GetComponent<ResolutionText>().resolutions;
        resolution_Now = text.GetComponent<ResolutionText>().NowResolution;   
        FullScreen = Screen.fullScreen;     
        if (resolution_Now < resolutions_Right.Count -1){
            text.GetComponent<ResolutionText>().NowResolution += 1;
            resolution_Now += 1;
            text_Tmp.text = (resolutions_Right[resolution_Now].width + "x" + resolutions_Right[resolution_Now].height).ToString();  
            Screen.SetResolution(resolutions_Right[resolution_Now].width, resolutions_Right[resolution_Now].height, FullScreen);
        }
    }
}
