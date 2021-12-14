using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] public float bulletTime = 0.3f;
    private bool bullets = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        //shoot fun
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        if (bullets == false)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                bullets = true;
                yield return new WaitForSeconds(bulletTime);
                bullets = false;
            }
            
        }
    }

    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }


}
