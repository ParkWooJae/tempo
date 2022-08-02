using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongRangeCoolTime : MonoBehaviour
{
    public Image abilityImage2;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability2;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage2.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
    }
    void Ability1(){
        if (Input.GetKey(ability2) && isCooldown == false){
            isCooldown = true;
            abilityImage2.fillAmount = 1;
        }
        if (isCooldown){
            abilityImage2.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0){
                abilityImage2.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
