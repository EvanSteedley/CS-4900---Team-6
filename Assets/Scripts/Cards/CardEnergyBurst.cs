using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEnergyBurst : ManaBuffCard
{

    // Start is called before the first frame update
    void Start()
    {
        id = 4;
        mana = 3;
        value = 2;
        turnsToLast = 2;
        name = "Energy Burst";
        description = "Increases Max Mana by 2 for the next 2 turns.";
        numberOfTargets = 1;
        Targeter = this.gameObject.GetComponent<SelectionGO>();
        Targeter.numberOfSelections = numberOfTargets;
        Targeter.exclusive = true;
        SetInfo();
    }
}
