using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1.0f, 1.0f)]
    public float startAngle;

    [SerializeField]
    private float cycleTime=5;

    private float time = 0;
    void Start()
    {
        time += startAngle * cycleTime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,0.5f*Mathf.Sin(time/cycleTime),1);
            
    }
}
