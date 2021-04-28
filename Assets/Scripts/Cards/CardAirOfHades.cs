using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAirOfHades : AttackCard
{
    //WhiteSmoke Prefab used whenever this is selected. 
    void Start()
    {
        id = 17;
        value = 40;
        mana = 2;
        name = "Air of Hades";
        description = "Deals 40 damage to one enemy.";
        numberOfTargets = 1;
        Targeter = this.gameObject.GetComponent<SelectionGO>();
        Targeter.numberOfSelections = numberOfTargets;
        Targeter.exclusive = true;
        SetInfo();
    }
}


