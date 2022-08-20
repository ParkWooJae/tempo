using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectEnemy : MonoBehaviour
{
    Button button;
    public Toggle N5To10,N10To15,N15To20,N20To25,N25To30;
    public int ChoiceEnemyNum;
    public GameObject EnemyNum;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        CheckToggle();
    }
    public void OnClickButton(){
        if(ChoiceEnemyNum != 0){
            SceneManager.LoadScene("InGame");
            DontDestroyOnLoad(EnemyNum);
        }
    }
    void CheckToggle(){
        if(N5To10.isOn == true){
            if(ChoiceEnemyNum != 1){
                ChoiceEnemyNum = 1;
            }
        }
        else if(N10To15.isOn){
            if(ChoiceEnemyNum != 2){
                ChoiceEnemyNum = 2;
            }
        }
        else if(N15To20.isOn){
            if(ChoiceEnemyNum != 3){
                ChoiceEnemyNum = 3;
            }
        }
        else if(N20To25.isOn){
            if(ChoiceEnemyNum != 4){
                ChoiceEnemyNum = 4;
            }
        }
        else if(N25To30.isOn){
            if(ChoiceEnemyNum != 5){
                ChoiceEnemyNum = 5;
            }
        }
    }
}
