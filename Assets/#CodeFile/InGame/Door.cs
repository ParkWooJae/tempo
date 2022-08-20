using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    StageManiger Stage;
    // Start is called before the first frame update
    void Start()
    {
        Stage = GameObject.Find("Manigement").GetComponent<StageManiger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "Player"){
            Stage.NextStage = true;
        }
    }
}
