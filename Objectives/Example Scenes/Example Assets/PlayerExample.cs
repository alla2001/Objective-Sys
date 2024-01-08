using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    public List<Transform> targets;
    int index = 0;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        LoadTarget();


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,target.position)<0.1f)
        {
            LoadTarget();
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, 4f * Time.deltaTime);
    }

    void LoadTarget()
    {
        if(index>targets.Count-1) index = 0;
        target = targets[index];
        index++;
    }
}
