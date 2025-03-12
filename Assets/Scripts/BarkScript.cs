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
            try
            {
                bark.Play();
            } catch
            {
                Debug.Log("Need to add sound");
            }
            
            foreach (GameObject stone in breakable)
            {
                Destroy(stone);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("stone");
        if (other.gameObject.CompareTag("Breakable"))
        {
            
            breakable.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            breakable.Remove(other.gameObject);
        }
    }
}
