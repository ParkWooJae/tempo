using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
 
    public GameObject SoonPage, ReaperPage, SoonLeftButton, SoonRightButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChoiceButton(){
        SceneManager.LoadScene("ChoiceEnemy");
    }
    public void ReaperLeft(){
        ReaperPage.SetActive(false);
        SoonPage.SetActive(true);
        SoonLeftButton.SetActive(false);
    }
    public void ReaperRight(){
        ReaperPage.SetActive(false);
        SoonPage.SetActive(true);
        SoonRightButton.SetActive(false);
    }

    public void SoonLeft(){
        SoonRightButton.SetActive(true);
        SoonPage.SetActive(false);
        ReaperPage.SetActive(true);
      
    }
    public void SoonRight(){
        ReaperPage.SetActive(true);
        SoonPage.SetActive(false);
        SoonLeftButton.SetActive(true);
    }
}
