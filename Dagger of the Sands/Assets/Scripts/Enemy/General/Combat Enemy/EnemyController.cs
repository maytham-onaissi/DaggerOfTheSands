using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] public EnemyCombat enemyCombat;
    [SerializeField] public EnemyHealth enemyHealth;
    [SerializeField] public EnemyPatrol enemyPatrol;
    [SerializeField] public GameObject enemyHandler;

    [Header("General")]
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D boxCollider;

    [Header("Animation")]
    public Animation animation;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
