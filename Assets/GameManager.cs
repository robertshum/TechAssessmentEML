using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Hide Cursor")]
    public bool showCursor;

    // Start is called before the first frame update
    void Start()
    {
        //if game manager gets more complicated, start de-coupling methods / classes
        //ex: move cursor logic to a method that handles cursor / display related code
        Cursor.visible = showCursor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
