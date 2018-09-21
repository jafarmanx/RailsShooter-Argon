using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {


    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
	{
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		Destroy(gameObject);
	}

}
