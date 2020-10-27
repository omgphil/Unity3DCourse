using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 3;

    ScoreBoard scoreBoard;
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
