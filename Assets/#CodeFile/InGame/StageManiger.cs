using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManiger : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    EnemyNum SelectEnemyNum;
    private int MaxStage = 5;
    int NowStage = 0;
    int NowStageMaxEnemy,MadeMaxEnemy,NowSpawnEnemyNum;
    Vector3 SpawnPoint;
    float RandomX,RandomY;
    public bool NextStage = false;
    // Start is called before the first frame update
    void Start()
    {
        SelectEnemyNum = GameObject.Find("EnemyNum").GetComponent<EnemyNum>();
        MaxEnemy();
    }

    

    // Update is called once per frame
    void Update()
    {
        StageChange();
    }

    void StageChange(){
        if(NextStage){
            if(NowStage < 5){
                Player.transform.position = new Vector3(0.18f,-5.65f,0);
                NowStage++;
                MakeEnemy();
                NextStage = false;
                Debug.Log("남은 마릿수" + MadeMaxEnemy);
            }
            // else{
            //     // 스텟창 열기 추가 해야함
            // }
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
            yield return new WaitForSeconds(DelayTime);
        }
        Debug.Log(NowSpawnEnemyNum);
        
    }
    void SpawnPointRange(){
        RandomX = Random.Range(9f,-9f);
        RandomY = Random.Range(3f,-4f);
        SpawnPoint = new Vector3(RandomX,RandomY,0);
        float CheckX, CheckY;
        CheckX = RandomX - Player.transform.position.x;
        CheckY = RandomY - Player.transform.position.y;
        if(0.5f > Mathf.Abs(CheckX) || 0.5f > Mathf.Abs(CheckY)){
            SpawnPointRange();
        }
                
    }
    void SpawnEnemyRange(){
        if(NowStage == 5){
            NowSpawnEnemyNum = MadeMaxEnemy;
        }
        else{
            NowSpawnEnemyNum = Random.Range(SelectEnemyNum.EnemyNumber, MadeMaxEnemy -(MaxStage - NowStage)*SelectEnemyNum.EnemyNumber +1); 
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
