﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int realDamage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", realDamage);
        }
    }
}
