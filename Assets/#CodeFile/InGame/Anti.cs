using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti : MonoBehaviour
{
    Rigidbody2D rid2D;
    // Start is called before the first frame update
    void Start()
    {
        rid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rid2D.velocity = Vector3.zero;
    }
}
