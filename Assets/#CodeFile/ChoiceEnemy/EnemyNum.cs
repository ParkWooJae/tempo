using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyNum : MonoBehaviour
{
    public int EnemyNumber;
    SelectEnemy ChoiceEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "ChoiceEnemy"){
            GetEnemy();
        }
        
    }
    void GetEnemy(){
        ChoiceEnemy = GameObject.Find("Button").GetComponent<SelectEnemy>();
        if(EnemyNumber != ChoiceEnemy.ChoiceEnemyNum){
            EnemyNumber = ChoiceEnemy.ChoiceEnemyNum;
        }
        
    }
}
