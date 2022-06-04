using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HelpButton : MonoBehaviour
{
    Button button;
    public GameObject HelpTab;
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
       HelpTab.SetActive(true);
    }
}
