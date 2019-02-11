using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}
