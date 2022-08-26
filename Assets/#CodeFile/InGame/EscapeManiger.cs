using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeManiger : MonoBehaviour
{
    public GameObject EscapePage, GameEndPage,State;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetTitle(){
        EnemyHurt.CountDie = 0;
        StateField.OrcHp = 5;
        StateField.OrcPower = 1;
        StateField.Hp = StateField.DefaultHp;
        StateField.Armer = StateField.DefaultArmer;
        StateField.Power = StateField.DefaultPower;
        StateField.StatePoint = 0;
        StateField.DefaultStatePoint = 0;
        StateField.CheckEscapePage = false;
        StateField.CheckStatePage = false;
        SceneManager.LoadScene("GameStart");
    }
    public void GetGameEnd(){
        EscapePage.SetActive(false);
        GameEndPage.SetActive(true);
    }
    public void Cancel(){
        EscapePage.SetActive(false);
        StateField.CheckEscapePage = false;
        if(StateField.CheckStatePage){
            State.SetActive(true);
        }
    }
}
