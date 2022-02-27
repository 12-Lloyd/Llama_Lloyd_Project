using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(new Vector3(0, 60 * Time.deltaTime, 0));
        transform.Rotate(50 * Time.deltaTime,0 , 0);
    }
    void DestroyObject()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Destroy(gameObject);
    }

}
