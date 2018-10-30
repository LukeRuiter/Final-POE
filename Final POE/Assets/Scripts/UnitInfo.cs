using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public GameObject Info;

    public Text health;
    Map_01 form1;
    void Start()
    {
        health = (Text)GameObject.Find("Canvas").GetComponentInChildren<Text>();
        form1 = (Map_01)GameObject.Find("Main Camera").GetComponent<Map_01>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        string info = "";

        int x = (int)this.transform.position.x;
        int y = (int)this.transform.position.y;

        foreach (MeleeUnit u in form1.MeleeList)
        {
            if ((u.X == x) && (u.Y == y))
            {
                info = u.ToString();
            }
        }



    }
}
