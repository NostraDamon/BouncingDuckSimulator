using UnityEngine;
using System.Collections;

public class _HTTP : MonoBehaviour
{
    private _CP CP;
    //private GUIText guiInfo;

    // Use this for initialization
    void Start()
    {
        CP = GameObject.Find("_CP").GetComponent<_CP>();
        //guiInfo = GameObject.Find("GUI_Info").guiText;

        //// Connect
        Application.ExternalCall("Connect", "Connected!");
    }
	
    //// Update is called once per frame
    //void Update ()
    //{
	    
    //}

    //// JAVASCRIPT CALLS

    void Connect(string arg)
    {
        //Application.ExternalEval("alert('" + arg + "');");
    }

    //// UNITY CALLS

    public void UpdateBounces()
    {
        Application.ExternalCall("UpdateBounces", CP.bounces.ToString());
    }
}
