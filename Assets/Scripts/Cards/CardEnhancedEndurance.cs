using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEnhancedEndurance : Card
{
    public List<Player> Targets;

    // Start is called before the first frame update
    void Start()
    {
        id = 7;
        mana = 5;
        value = 25; //will icrease max hp 25
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Action()
    {
        Player p = FindObjectsOfType<Player>()[0];
        p.BuffHealth(value);
        Destroy(this.gameObject);
    }

    override public void ClearSelections()
    {
        Targeter.Selections = new List<GameObject>();
    }
}
