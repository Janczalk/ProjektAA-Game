using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    public Transform startPoint;
    public AudioClip death;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.position = startPoint.position;
            AudioSource.PlayClipAtPoint(death, transform.position);
        }
    }

}
    
