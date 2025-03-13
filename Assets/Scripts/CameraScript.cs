using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // The Speed in which the camera follows the player
    public float FollowSpeed = 3f;
    // How far on the x axis is the camera away from the player
    public float xOffset = 10f;
    // The y coordinates of the camera
    public float yOffset = 10f;

    public GameObject target;
    // Location of the player
    //public Transform target;
    Vector3 newPos;

    // Update is called once per frame
    void Update()
    {

        if (target.transform.localScale.y == 1)
        {
            newPos = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, -10f);
            // Changes the position of the camera to the new position
            
        } else
        {
            newPos = new Vector3(target.transform.position.x - xOffset, target.transform.position.y + yOffset, -10f);
        }
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
