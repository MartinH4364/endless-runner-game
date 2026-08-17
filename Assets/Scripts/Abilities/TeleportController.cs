using UnityEngine;
using UnityEngine.VFX;

public class TeleportController : MonoBehaviour
{
    public VisualEffect teleportEffect;
    public VisualEffect teleportBall;

    float elapsedTime = 0;

    public float bounceDuration = 5;

    bool teleported = false;

    public Vector3 velocity;
    new Rigidbody rigidbody;
    PlayerMovement playerMovement;

    public float gravityDivisor = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(elapsedTime >= bounceDuration)
        {
            teleportBall.Stop();
            teleportEffect.enabled = true;
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);
            velocity.y += playerMovement.gravity / gravityDivisor * Time.deltaTime;
        }

        if(elapsedTime >= bounceDuration + 0.5f && !teleported)
        {
            playerMovement.queuedTeleport = true;
            playerMovement.teleportPosition = transform;
            teleported = true;
        }
        if(elapsedTime >= bounceDuration + 4.5)
        {
            Destroy(gameObject);
        }
        
        elapsedTime += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
        }
    }
}
