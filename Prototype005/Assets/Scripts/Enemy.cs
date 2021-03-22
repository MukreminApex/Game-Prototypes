using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public enum BehaviourState
    {
        Patrolling,
        Attacking,
        Idling,
        Despawn,
    }

    bool isIdle;

    private float walkSpeed = 30.0f;
    private float walkLeft = 0.0f;
    private float walkRight = 20.0f;
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    Vector2 distanceToPlayer;
    bool foundPlayer;
    private GameObject player;
    public BehaviourState currentState = BehaviourState.Idling;
    public LayerMask layerMask;

    public Projectile projectile;
    public Transform launchPoint;
    public float waitBetweenShots;
    private float shotCounter;
    float timeSpentIdling;
    float timeSpentPatrol;

    public GameObject LostPlayerEffect;
    public GameObject GoIdleEffect;
    public GameObject FoundPlayerEffect;
    public GameObject DespawnEffect;
    public GameObject AttackEffect;
    public GameObject PatrolEffect;

    // Use this for initialization
    void Start () {
        currentState = BehaviourState.Patrolling;
        player = Player.Instance.gameObject;

        shotCounter = -1;
    }
	
	// Update is called once per frame
	void Update () {

        switch (currentState)
        {
            case BehaviourState.Patrolling:
                Patrolling();
                LookForPlayer();
                GoToAttackIfFound();
                GoToDespawnIfNotFound();
                break;

            case BehaviourState.Attacking:
                Attack();
                LookForPlayer();
                GoToIdleIfLost();
                break;

            case BehaviourState.Idling:
                Idling();
                LookForPlayer();
                GoToAttackIfFound();
                break;
            case BehaviourState.Despawn:
                Despawn();
                break;
        }
    }

    void Despawn()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= 0.0f + walkRight)
        {
            walkingDirection = -1.0f;
        }
        transform.Translate(walkAmount);
        EnemySpawner.enemyCount--;
        //if (transform.position.x <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }
    void GoToDespawnIfNotFound()
    {
        if (foundPlayer == false && timeSpentPatrol > 5)
        {
            currentState = BehaviourState.Despawn;
            LostPlayerEffect.SetActive(false);
            GoIdleEffect.SetActive(false);
            FoundPlayerEffect.SetActive(false);
            DespawnEffect.SetActive(true);
            AttackEffect.SetActive(false);
            PatrolEffect.SetActive(false);
        }
    }
    void GoToAttackIfFound(float delayFirstAttackTime = -1f)
    {
        if (foundPlayer == true)
        {
            shotCounter = delayFirstAttackTime;
            Invoke("switchToAttack", 0.5f);
            isIdle = false;
            LostPlayerEffect.SetActive(false);
            GoIdleEffect.SetActive(false);
            FoundPlayerEffect.SetActive(true);
            DespawnEffect.SetActive(false);
            AttackEffect.SetActive(false);
            PatrolEffect.SetActive(false);
        }
    }
    void switchToAttack()
    {
        currentState = BehaviourState.Attacking;
    }
    void GoToIdleIfLost()
    {
        if (foundPlayer == false)
        {
            timeSpentIdling = 0;
            isIdle = true;
            currentState = BehaviourState.Idling;
            LostPlayerEffect.SetActive(true);
            GoIdleEffect.SetActive(false);
            FoundPlayerEffect.SetActive(false);
            DespawnEffect.SetActive(false);
            AttackEffect.SetActive(false);
            PatrolEffect.SetActive(false);
        }
    }

    void Patrolling()
    {
        timeSpentPatrol += Time.deltaTime;
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= player.transform.position.x + walkRight)
        {
            walkingDirection = -1.0f;
        }
        else if (walkingDirection < 0.0f && transform.position.x < player.transform.position.x + walkLeft)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
        LostPlayerEffect.SetActive(false);
        GoIdleEffect.SetActive(false);
        FoundPlayerEffect.SetActive(false);
        DespawnEffect.SetActive(false);
        AttackEffect.SetActive(false);
        PatrolEffect.SetActive(true);
    }

    void Idling()
    {
        timeSpentIdling += Time.deltaTime;
        if (timeSpentIdling > 0.5f)
        {
            currentState = BehaviourState.Patrolling;
            timeSpentPatrol = 0;
            LostPlayerEffect.SetActive(false);
            GoIdleEffect.SetActive(true);
            FoundPlayerEffect.SetActive(false);
            DespawnEffect.SetActive(false);
            AttackEffect.SetActive(false);
            PatrolEffect.SetActive(false);
        }  
    }
    void LookForPlayer()
    {
        Vector2 start = transform.position;
        Vector2 direction = player.transform.position - transform.position;
        float castDistance = Mathf.Min(35, direction.magnitude);
        
        direction.Normalize();

        float distance = castDistance;
        RaycastHit2D[] hits = Physics2D.RaycastAll(start, direction, distance, layerMask);
        foundPlayer = false;

        for (int it = 0; it < hits.Length; it++)
        {
            if (hits[it].collider != null && hits[it].collider.tag == "Player")
            {
                foundPlayer = true;
            }
            else
            {
                break;
            }
        }
        if (foundPlayer)
        {
            Debug.DrawLine(start, start + (direction * distance), Color.green);
        }
        else
        {
            Debug.DrawLine(start, start + (direction * distance), Color.red);
        }
    }
    void Attack()
    {
        if (shotCounter < 0)
        {
            Vector2 direction = player.transform.position - launchPoint.position;
            direction.Normalize();
            var bullet = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            bullet.Shoot(direction, launchPoint.position);
            shotCounter = waitBetweenShots;
        }
        shotCounter -= Time.deltaTime;
        LostPlayerEffect.SetActive(false);
        GoIdleEffect.SetActive(false);
        FoundPlayerEffect.SetActive(false);
        DespawnEffect.SetActive(false);
        AttackEffect.SetActive(true);
        PatrolEffect.SetActive(false);
    }
}
