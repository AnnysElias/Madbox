using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1.0f, 1.0f)]
    public float startAngle;

    [SerializeField]
    private float cycleTime=5;

    private float time = 0;

    Vector3 OriginalPos;
    void Start()
    {
        OriginalPos = transform.position;
        time += startAngle * cycleTime ;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = OriginalPos+new Vector3(0, 3+3 * Mathf.Sin(time / cycleTime),0);
            
    }
}
