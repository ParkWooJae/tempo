using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Save : MonoBehaviour
{
    public TMP_Text PowerText, HpText, ArmerText, StatePoint;
    public GameObject State;
    
    // Start is called before the first frame update
    void Start()
    {
        StatusUpdate();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatusUpdate(){
        PowerText.text = StateField.Power.ToString();
        HpText.text = StateField.Hp.ToString();
        ArmerText.text = StateField.Armer.ToString();
        StatePoint.text = StateField.StatePoint.ToString();
    }
    void StateUp(){
        
        StateField.StatePoint--;
        StatusUpdate();
        
    }
    void StateDawn(){
        StateField.StatePoint++;
        StatusUpdate();
    }

    public void ApplyButton(){
        StateField.StateUpdate = true;
        State.SetActive(false);
        StateField.CheckStatePage = false;
    }

    public void ResetButton(){
        StateField.Power = StateField.DefaultPower;
        StateField.Hp = StateField.DefaultHp;
        StateField.Armer = StateField.DefaultArmer;
        StateField.StatePoint = StateField.DefaultStatePoint;
        StatusUpdate();
    }
    
    public void OnClickPowerUp(){
        if(StateField.StatePoint > 0){
            StateField.Power++;
            StateUp();
        }
    }
    public void PowerDawnButton(){
        if(StateField.DefaultPower < StateField.Power){
            StateField.Power--;
            StateDawn();
        }
    }

    public void HpUpButton(){
        if(StateField.StatePoint > 0){
            StateField.Hp ++;
            StateUp();
        }
    }
    public void HpDawnButton(){
        if(StateField.DefaultHp < StateField.Hp){
            StateField.Hp --;
            StateDawn();
        }
    }
    public void ArmerUpButton(){
        if(StateField.StatePoint > 0){
            StateField.Armer ++;
            StateUp();
        }
    }
    public void ArmerDawnButton(){
        if(StateField.DefaultArmer < StateField.Armer){
            StateField.Armer --;
            StateDawn();
        }
    }

}
public class StateField{
    public static int Power = 1,Hp = 15,Armer = 0,StatePoint = 0, DefaultPower = 1, DefaultHp = 15, DefaultArmer = 0, DefaultStatePoint = 0, OrcPower = 1, OrcHp = 5;
    public static bool StateUpdate = false, CheckStatePage = false, CheckEscapePage = false;
}
