using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleTrigger : MonoBehaviour
{



    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerBehaviour>()!=null)
        {
            other.gameObject.GetComponent<PlayerBehaviour>().Die();
            Invoke("Restart", 2);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
