using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        Time.timeScale = 0;
    }

    public void Clickon()
    {
        Time.timeScale = 1;
    }
}
