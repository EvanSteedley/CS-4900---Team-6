using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject selected;
    public bool somethingSelected = false;



    public GameObject Selected
    {
        get { return this.selected; }
        set { this.selected = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //If there is a card selected, then Play that card!
    public void PlayCard()
    {
        if(Selected != null)
        {
            Card c = Selected.GetComponent<Card>();
            c.Action();
        }
    }

}
