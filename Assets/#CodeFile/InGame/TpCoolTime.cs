using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TpCoolTime : MonoBehaviour
{
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Ability1();
    }
    IEnumerator CoolTime(){
        while(cooldown1 > 1.0f){
            cooldown1 -= Time.deltaTime;
            abilityImage1.fillAmount = (1.0f / cooldown1);
            yield return new WaitForFixedUpdate();
        }
    }

    void Ability1(){
        if (Input.GetKey(ability1) && isCooldown == false){
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }
        if (isCooldown){
            cooldown1 = 5;
            StartCoroutine(CoolTime());

            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0){
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
