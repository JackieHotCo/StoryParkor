using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    public Vector2 startPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("die");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = startPosition;
        }
    }
}
