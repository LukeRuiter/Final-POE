using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour {

    public Text health;

    Form1 form1;
    void Start()
    {

        try
        {

            health = (Text)GameObject.Find("Canvas").GetComponentInChildren<Text>();
            
        }
        catch
        {
            Debug.Log("couldnt find text");
        }


        try
        {
            form1 = (Form1)GameObject.Find("Main").GetComponent<Form1>();
            
        }
        catch
        {
            Debug.Log("Couldnt find main camera");
        }
    }

    // Update is called once per frame


    private void OnMouseDown()
    {

        Debug.Log("show");
        int x = (int)this.transform.position.x;
        int y = (int)this.transform.position.y;
       
        health.text = form1.FindUnit(x, y); ;

    }
}
