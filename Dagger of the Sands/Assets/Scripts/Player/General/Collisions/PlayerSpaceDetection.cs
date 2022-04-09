using UnityEngine;

public class PlayerSpaceDetection : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask groundLayer;

    [Header("RayCast")]
    [SerializeField] private string[] dashIgnoreTag;
    [SerializeField] private Transform originPoint;
    [SerializeField] private float rayDistance;

    [Header("is Falling")]
    private float currentVelocity;
    private float previousVelocity;

    void Start()
    {
        //Debug.Log("Space Detection Script");
    }
     
    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGamePaused)
        {
            IsGrounded();
            isFallingDown();
            //GetCollisionLayer();
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerController.boxCollider.bounds.center, playerController.boxCollider.bounds.size,
            0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool isFallingDown()
    {
        if (playerController.rigidBody.velocity.y < 0) return true;

        return false;
    }

    public int GetCollisionLayer()
    {

        //Debug.DrawRay(originPoint.position, transform.TransformDirection(new Vector3(transform.localScale.x, 0, 0)) * 10f, Color.red);

        RaycastHit2D rayCastHit = Physics2D.Raycast(originPoint.position,
          transform.TransformDirection(new Vector3(transform.localScale.x, 0, 0)),
          rayDistance);

        if (rayCastHit)
        {
            foreach (string s in dashIgnoreTag)
            {
                if (rayCastHit.collider.tag == s && playerController.serpentStep.isDashing)
                {
                    //rayCastHit.collider.enabled = false;
                    return rayCastHit.collider.gameObject.layer;
                }
            }
            //rayCastHit.collider.enabled = true;
        }
        return 0;
    }
}
