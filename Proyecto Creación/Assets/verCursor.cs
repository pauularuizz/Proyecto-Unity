using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible=true;
    }
    private void Awake()
    {
        Cursor.visible = true;
    }
}
