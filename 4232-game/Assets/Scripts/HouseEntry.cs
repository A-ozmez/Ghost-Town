using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEntry : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public GameObject key;
    public GameObject player;
    public Rigidbody2D rb;
    public Transform playerTransform;
    //EnemyFollow instance = new EnemyFollow();
    
    void Update()
    {

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ENTER HOUSE
        if (collision.tag == "Player" && gameObject.tag == "House1" && EnemyFollow.dead == 0)
        {
            SceneManager.LoadScene("House1");
            EnemySpawner.spawned = 0;
            EnemyFollow.dead = 0;
            
            

        }
        else if (collision.tag == "Player" && gameObject.tag == "House2" && EnemyFollow.dead == 15)
        {
            SceneManager.LoadScene("House2");
            EnemySpawner.spawned = 0;
            EnemyFollow.dead = 0;
            

        } else if (collision.tag == "Player" && gameObject.tag == "House3" && EnemyFollow.dead == 20)
        {
            SceneManager.LoadScene("House3");
            EnemySpawner.spawned = 0;
            EnemyFollow.dead = 0;
            

        }
        else if (collision.tag == "Player" && gameObject.tag == "House4" && EnemyFollow.dead == 25)
        {
            SceneManager.LoadScene("House4");
            EnemySpawner.spawned = 0;
            EnemyFollow.dead = 0;
           

        }
        else if (collision.tag == "Player" && gameObject.tag == "House5" && EnemyFollow.dead == 30)
        {
            SceneManager.LoadScene("House5");
            EnemySpawner.spawned = 0;
            EnemyFollow.dead = 0;
            

        }
        else if (collision.tag == "Player" && gameObject.tag == "House6" && EnemyFollow.dead == 35)
        {
            SceneManager.LoadScene("House6");
            EnemySpawner.spawned = 0;
            EnemyFollow.dead = 0;
            

        //EXIT HOUSE
        }
        else if (collision.tag == "Player" && gameObject.tag == "Exit1" && EnemyFollow.dead == 15)
        {
            Debug.Log(EnemyFollow.dead);
            SceneManager.LoadScene("SampleScene");
            //play
            transition.SetTrigger("KeyStart");



        }
        else if (collision.tag == "Player" && gameObject.tag == "Exit2" && EnemyFollow.dead == 20)
        {

            SceneManager.LoadScene("SampleScene");
            //play
            transition.SetTrigger("KeyStart");


        }
        else if (collision.tag == "Player" && gameObject.tag == "Exit3" && EnemyFollow.dead == 25)
        {

            SceneManager.LoadScene("SampleScene");
            //play
            transition.SetTrigger("KeyStart");

        }
        else if (collision.tag == "Player" && gameObject.tag == "Exit4" && EnemyFollow.dead == 30)
        {

            SceneManager.LoadScene("SampleScene");
            //play
            transition.SetTrigger("KeyStart");

        }
        else if (collision.tag == "Player" && gameObject.tag == "Exit5" && EnemyFollow.dead == 35)
        {

            SceneManager.LoadScene("SampleScene");
            //play
            transition.SetTrigger("KeyStart");

        }
        else if (collision.tag == "Player" && gameObject.tag == "Exit6" && EnemyFollow.dead == 40)
        {

            Debug.Log(EnemyFollow.dead);
            SceneManager.LoadScene("SampleScene");
            //play
            transition.SetTrigger("KeyStart");


            /*
            Vector3 tempVect = new Vector3(0, 0, 1);
            tempVect = tempVect.normalized * 3 * Time.deltaTime;
           
            playerTransform.position = new Vector3(-5.23f, -1.57f, 0.0f);
            rb.MovePosition(player.transform.position + tempVect);

            Physics.SyncTransforms();*/

        }
        else if (collision.tag == "Player" && gameObject.tag == "FinalExt")
        {
            SceneManager.LoadScene("Win");
        }

       
    }


        public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
