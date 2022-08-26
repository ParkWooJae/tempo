using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongRange : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    static public bool longRangeDelay;
    bool LongCoroutine = false;
    public Image LongImage;
    public float LongCool;
    
    // Start is called before the first frame update
    void Start()
    {
        LongImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();    
        LongImageTrans();        
    }
    void Awake(){
        longRangeDelay = false;
    }
    IEnumerator ShootDelay(){
        LongCoroutine = true;
        yield return new WaitForSeconds(LongCool);
        longRangeDelay = false;
        LongCoroutine = false;
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
                LongImage.fillAmount = 1;
                StartCoroutine(ShootDelay());
            }
        }
        
    }
    void LongImageTrans(){
        if(LongCoroutine){
            LongImage.fillAmount -= 1 / LongCool * Time.deltaTime;
            if (LongImage.fillAmount <= 0){
                LongImage.fillAmount = 0;
            }
        }
    }
}

