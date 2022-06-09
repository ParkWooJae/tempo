using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpExitButton : MonoBehaviour
{
    Button button;
    public GameObject HelpPanel;
    public GameObject SystemPanel;
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
        HelpPanel.SetActive(false);
        SystemPanel.SetActive(false);
    }
}
