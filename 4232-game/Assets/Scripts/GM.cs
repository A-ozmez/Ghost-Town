using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static GM gm;

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    

    public IEnumerator RespawnPlayer()
    {
        Debug.Log("TODO: death audio");
        yield return new WaitForSeconds(spawnDelay);
        SceneManager.LoadScene("SampleScene");

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        
    }

    public static void KillPlayer(PlayerHealth player)
    {
        Destroy(player.gameObject);

        gm.StartCoroutine(gm.RespawnPlayer());
    }


    
}

