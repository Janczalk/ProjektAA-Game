﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPickUp : MonoBehaviour
{
    CounterController counterController;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);

        }
    }
}
