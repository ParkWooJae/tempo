using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HpUp : MonoBehaviour
{
    public TMP_Text  HPText;
    Button HpUpButton;
    
    // Start is called before the first frame update
    void Start()
    {
        StateField state = new StateField();
        HpUpButton = GetComponent<Button>();
        HpUpButton.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickButton(){
        StateField.Hp ++;
        HPText.text = StateField.Hp.ToString();        
    }
}
