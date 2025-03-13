using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    Vector2 startPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = startPosition;
        }
    }
}
