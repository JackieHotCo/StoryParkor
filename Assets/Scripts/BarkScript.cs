using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarkScript : MonoBehaviour
{

    List<GameObject> breakable;
    public AudioSource bark;
    public AudioSource breakingSound;

    public Animator flower;

    public Animator cameraM;

    void Start()
    {
        breakable = new List<GameObject>();
    }

    void Update()
    {
        cameraM.SetBool("Shake", false);
        if (Input.GetKeyDown(KeyCode.E) && cameraM.GetBool("Shake"))
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

            Bark();
        }
    }

    private void Bark()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //ToDo: play animation
            cameraM.SetBool("Shake", true);
            BarkCoroutine();
        }
    }

    public IEnumerator BarkCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        
        yield return null;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            breakable.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Flower"))
        {
            flower.SetBool("IsCrouching", true);
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
