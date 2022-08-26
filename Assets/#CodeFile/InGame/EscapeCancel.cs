using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeCancel : MonoBehaviour
{
    public GameObject Exit,EscapePage;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton(){
        Exit.SetActive(false);
        EscapePage.SetActive(true);
        
    }
    
}
