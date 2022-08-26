using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceLeftButton : MonoBehaviour
{
    Button button;
    public GameObject SoonPage, ReaperPage, LeftButton, RightButton;
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
        // if(SoonPage.activeSelf == true){

        // }
        SoonPage.SetActive(true);
        ReaperPage.SetActive(false);
        LeftButton.SetActive(false);

    }
}
