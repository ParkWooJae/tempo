using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageManiger : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject StatePage;
    public GameObject CloseDoor;
    public GameObject OpenDoor;
    EnemyNum SelectEnemyNum;
    private int MaxStage = 5;
    int NowStage = 0;
    int NowStageMaxEnemy,MadeMaxEnemy,NowSpawnEnemyNum;
    Vector3 SpawnPoint;
    float RandomX,RandomY;
    public bool NextStage = false;
    public GameObject StatusPage;
    public TMP_Text  StageText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SelectEnemyNum = GameObject.Find("EnemyNum").GetComponent<EnemyNum>();
        MaxEnemy();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(!StateField.CheckStatePage){
            if(!StateField.CheckEscapePage){
                LivingEnemy();
                StageChange();
            }
        }
        
    }

    void LivingEnemy(){
        if(EnemyHurt.CountDie <= 0){
            CloseDoor.SetActive(false);
            OpenDoor.SetActive(true);
        }
    }

    void StageChange(){
        if(NextStage){
            CloseDoor.SetActive(true);
            OpenDoor.SetActive(false);
            if(NowStage < 5){
                Player.transform.position = new Vector3(0.18f,-5.65f,0);
                NowStage++;
                MakeEnemy();
                NextStage = false;
                StateField.OrcPower ++;
                StateField.OrcHp ++;
            }
            else{
                StateField.StatePoint += SelectEnemyNum.EnemyNumber * 2;
                StateField.DefaultStatePoint += SelectEnemyNum.EnemyNumber * 2;
                StatusPage.GetComponent<Save>().StatusUpdate();
                StatePage.SetActive(true);
                StateField.CheckStatePage = true;
                NextStage = false;
                NowStage = 0;
                MaxEnemy();
            }
            if(NowStage == 0){
                StageText.text = ("Ready");
            }
            else{
                StageText.text = NowStage.ToString() + (" Stage");
            }
            
        }
    }

    
    void MakeEnemy(){
        SpawnEnemyRange();
        StartCoroutine(SpawnDelay());
        MadeMaxEnemy -= NowSpawnEnemyNum;
    }
    IEnumerator SpawnDelay(){
        float DelayTime = Random.Range(1,6);
        for(int i = 1; i <= NowSpawnEnemyNum ; i++){
            SpawnPointRange();
            Instantiate(Enemy, SpawnPoint, transform.rotation);
            EnemyHurt.CountDie ++;
            yield return new WaitForSeconds(DelayTime);
        }       
    }
    void SpawnPointRange(){
        RandomX = Random.Range(9f,-9f);
        RandomY = Random.Range(3f,-4f);
        SpawnPoint = new Vector3(RandomX,RandomY,0);
        float CheckX, CheckY;
        CheckX = RandomX - Player.transform.position.x;
        CheckY = RandomY - Player.transform.position.y;
        if(0.8f > Mathf.Abs(CheckX) && 0.8f > Mathf.Abs(CheckY)){
            SpawnPointRange();
        }
                
    }
    void SpawnEnemyRange(){
        if(NowStage == 5){
            NowSpawnEnemyNum = MadeMaxEnemy;
        }
        else{
            NowSpawnEnemyNum = Random.Range(SelectEnemyNum.EnemyNumber, MadeMaxEnemy -(MaxStage - NowStage)*SelectEnemyNum.EnemyNumber); 
        }       
    }
    void MaxEnemy(){
        switch(SelectEnemyNum.EnemyNumber){
            case 1:
                MadeMaxEnemy = Random.Range(5,11);
                break;
            case 2:
                MadeMaxEnemy = Random.Range(10,16);
                break;
            case 3:
                MadeMaxEnemy = Random.Range(15,21);
                break;
            case 4:
                MadeMaxEnemy = Random.Range(20,26);
                break;
            case 5:
                MadeMaxEnemy = Random.Range(25,31);
                break;
        }
    }


}
