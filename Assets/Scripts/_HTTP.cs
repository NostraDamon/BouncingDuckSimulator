using UnityEngine;
using System.Collections;

public class _HTTP : MonoBehaviour
{
    private _CP CP;
    private GUIText guiInfo;

    // Use this for initialization
    void Start()
    {
        CP = GameObject.Find("_CP").GetComponent<_CP>();
        guiInfo = GameObject.Find("GUI_Info").guiText;

        //// Connect
        //Application.ExternalEval(
        //    "alert('connected');"
        //);
    }
	
    //// Update is called once per frame
    //void Update ()
    //{
	    
    //}

    void Connect(string msg)
    {
        guiInfo.text = msg;
    }
}
