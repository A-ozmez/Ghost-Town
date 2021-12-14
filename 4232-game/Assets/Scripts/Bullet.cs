using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 5;

    public float bulletDamage;
    [SerializeField] Rigidbody2D rb;

    private Vector2 direction;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 4f);
        direction = GameObject.Find("Direction").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //Debug.Log("enemy attacked");
            EnemyFollow enemy = other.gameObject.GetComponent<EnemyFollow>();
            enemy.TakeDamage(bulletDamage);
        }
    }
}
