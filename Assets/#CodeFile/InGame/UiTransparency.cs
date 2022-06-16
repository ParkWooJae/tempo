using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTransparency : MonoBehaviour
{
    SpriteRenderer ui;
    

    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            ui.color = new Color (1,1,1,0.4f);        
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            ui.color = new Color (1,1,1,1f);        
        }
    }

}
