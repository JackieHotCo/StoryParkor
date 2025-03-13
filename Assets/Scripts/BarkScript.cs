using UnityEngine;
using System.Collections.Generic;

public class BarkScript : MonoBehaviour
{

    List<GameObject> breakable;
    public AudioSource bark;
    public AudioSource breakingSound;

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

            if (breakable.Count > 0)
            {
                breakingSound.Play();
                foreach (GameObject stone in breakable)
                {
                    Destroy(stone);
                }
                breakable = new List<GameObject>();
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
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
