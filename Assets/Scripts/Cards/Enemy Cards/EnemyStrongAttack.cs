﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class EnemyStrongAttack: EnemyCard
    {


    void Start()
    {
        value = (int)(gameObject.GetComponent<Enemy>().damage * 1.25f);
        p = FindObjectOfType<Player>();
        e = GetComponent<Enemy>();
        cardName = "StrongAttack";
    }


    public override void Action()
    {
        value = (int)(gameObject.GetComponent<Enemy>().damage * 1.25f);
        e.anim.SetTrigger("Attack");
        e.anim.SetTrigger("Attack 2");
        p.TakeDamage(value);
    }

}

