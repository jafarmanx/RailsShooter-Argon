using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX = null;


    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
