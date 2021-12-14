using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 4f;
    [Header("Attack")]
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1.5f;
    private float canAttack;

    [Header("Health")]
    private float health;
    [SerializeField] private float maxHealth;

    private Transform target;
    public static int dead = 0;

    //EnemyFollow enemy = new EnemyFollow();
    public static EnemyFollow bro;

    

    private void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        //Debug.Log("enemy health" + health);

        if (health <= 0 && gameObject != null)
        {
            Destroy(gameObject);
            dead++;
            Debug.Log("dead"+dead); 
        }
         
    }

    /*
    public static int getDead()
    {
        return bro.getDead() ;
    }*/

    private void Update()
    {   
            if (target != null)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
