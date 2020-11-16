using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] levelpaths;

    private int pathIndex = 0;
    private bool isOnPath = false;

    [SerializeField]
    private float TimePerCurve = 3;

    private bool isAlive = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnPath)
            StartCoroutine(MoveOverPath(pathIndex));
    }
    public void Die()
    {
        if (!isAlive)
            return;
        GetComponent<ParticleSystem>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).parent = null;
        isAlive = false;
    }
    private IEnumerator MoveOverPath(int index)
    {


        isOnPath = true;
        Vector3 p0 = levelpaths[index].GetChild(0).position;
        Vector3 p1 = levelpaths[index].GetChild(1).position;
        Vector3 p2 = levelpaths[index].GetChild(2).position;
        Vector3 p3 = levelpaths[index].GetChild(3).position;

        float time = 0;
        while(time <1)
        {
            if(Input.GetMouseButton(0))
            {

                time += Time.deltaTime / TimePerCurve;

                var position = Mathf.Pow(1 - time, 3) * p0 +
                3 * Mathf.Pow(1 - time, 2) * time * p1 +
                3 * (1 - time) * Mathf.Pow(time, 2) * p2 +
                Mathf.Pow(time, 3) * p3;
                transform.position = position;
            }
            yield return new WaitForEndOfFrame();

        }
        pathIndex++;
        if(levelpaths.Length==pathIndex)
        {
            pathIndex = 0;
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%2);
        }
        isOnPath = false;

    }
}
