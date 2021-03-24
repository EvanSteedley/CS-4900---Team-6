﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


class Poison : StatusEffects
{
    Turns t;
    void Start()
    {
        t = FindObjectOfType<Turns>();
        t.TurnEnded += Action;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Action(object sender, EventArgs e)
    {
        Enemy e2 = this.transform.GetComponent<Enemy>();
        Player p = this.transform.GetComponent<Player>();
        if (turnsLeft > 0)
        {
            if (p != null)
            {
                p.TakeDamage(20);
                turnsLeft--;
            }

            else if (e2 != null)
            {
                e2.TakeDamage(20);
                turnsLeft--;
            }
        }
        else
        {
            t.TurnEnded -= Action;
            Destroy(this);
        }

    }
}
