using UnityEngine;
using System.Collections.Generic;

public class BarkScript : MonoBehaviour
{

    List<GameObject> breakable;
    public AudioSource bark;

    void Start()
    {
        breakable = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bark.Play();
            foreach (GameObject stone in breakable)
            {
                Destroy(stone);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("stone");
        if (other.gameObject.tag == ("Breakable"))
        {
            
            breakable.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Breakable"))
        {
            breakable.Remove(other.gameObject);
        }
    }
}
