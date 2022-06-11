using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ResolutionText : MonoBehaviour
{
    public List<Resolution> resolutions = new List<Resolution>();
    public TMP_Text TMP_ResolutionText;
    public int NowResolution;
    // Start is called before the first frame update
    void Start()
    {
        GetResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetResolution(){
        for (int i = 0; i<Screen.resolutions.Length; i++){
            if((Screen.resolutions[i].width + Screen.resolutions[i].height) % 25 == 0 
            && Screen.resolutions[i].width > 1000 
            && Screen.resolutions[i].height != 1200
            && Screen.resolutions[i].width < 3500){
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        for (int i = 0; i< resolutions.Count; i++){
            // Debug.Log(resolutions[i] + "" + i);
             if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
                    TMP_ResolutionText.text = (resolutions[i].width + "x" + resolutions[i].height);
                    NowResolution = i;
                    // Debug.Log(NowResolution);
            }
        }             
    }


}
