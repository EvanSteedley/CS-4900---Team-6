﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class EnemyDefenseDown: EnemyCard
    {

    void Start()
    {
        value = 10;
        p = FindObjectOfType<Player>();
        e = GetComponent<Enemy>();
        cardName = "DefenseDown";
    }


    public override void Action()
    {
        p.gameObject.AddComponent<DefenseDown>();
        e.anim.SetTrigger("Attack");

    }

}

