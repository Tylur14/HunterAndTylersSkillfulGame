using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        print(TextPrompter.PromptGenerics.TooFarAway.ToString());
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_player.position, this.transform.position) < 4)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, _player.position, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
