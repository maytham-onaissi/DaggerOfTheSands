using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offSet;

    //Range() Constraints the values an int or float can be initialized with. 
    [Range(1,10)]
    [SerializeField] private float smoothFactor;

    //Updates every physical change (e.g; gravity, player movement).  
    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        //Player.postion -> the postion of the player. \\ offSet -> -10 away from the Player.position on the Z axis.
        Vector3 targetPosition = Player.position + offSet;

        //fixedDeltaTime is used to be compatible with different devices.
        //Vector3.Lerp() moves from an initial position to a final position, according to a factor (smoothFactor). 

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);

        //Change the postion of the camera in accordance to the player.
        transform.position = smoothPosition;

    }
}
