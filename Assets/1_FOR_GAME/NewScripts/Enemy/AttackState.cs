using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

    public override void Enter()
    {
        enemy.animator.SetBool("IsShooting", true);
    }
    public override void Exit() 
    {
    
    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer()) //player can be seen
        {
            //lock the lose player timer and increment move and shot timers
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            
            //if shot timer > fireRate
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            //move the enemy to a random position after a random time
            if (moveTimer > Random.Range(3,7)) 
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else //lose sight of the player
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                //change to search State
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public void Shoot()
    {
        //store reference to gun barrel
        Transform gunbarrel = enemy.gunBarrel;

        //instantiate new bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/GymMembership") as GameObject, gunbarrel.position, enemy.transform.rotation);
        //calculate direction to player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        //add force rigidbody of bullet
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * shootDirection * 30;
        Debug.Log("Shoot");
        shotTimer = 0;
    }

}
