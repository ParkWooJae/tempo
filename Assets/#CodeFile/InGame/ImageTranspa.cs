using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTranspa : MonoBehaviour
{
    Image UiImage;
    // Start is called before the first frame update
    void Start()
    {
        UiImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            UiImage.color = new Color (1,1,1,0.4f);        
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            UiImage.color = new Color (1,1,1,1f);        
        }
    }
}
