using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRange : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    static public bool longRangeDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               
        Shoot();     
        
    }
    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(5.0f);
        longRangeDelay = false;
    }

    void Shoot(){
        // 마우스 우클릭시         
        if(Input.GetMouseButtonDown(1)){
            if(!longRangeDelay){
                Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0,0,z);
                Instantiate(bullet, pos.position,transform.rotation);;
                longRangeDelay = true;
                StartCoroutine(ShootDelay());
            }
        }
        
    }
}
