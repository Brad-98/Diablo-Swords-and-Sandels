using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]

public class ClickToMove : MonoBehaviour
{
    public CharacterController playerController;
    public Animator playerAnimations;

    private AudioSource audioSource;
    public AudioClip footstep;

    [SerializeField]
    private float idleMoveAnimationTimer = 0.0f;

    public float moveSpeed = 6.0f;

    public static bool isAttacking;

    public Vector3 newPlayerPosition;
    public LayerMask groundLayer;

    [SerializeField]
    private float playerRotationSpeed = 10.0f;

    void Start()
    {
        newPlayerPosition = transform.position;
        playerAnimations = this.gameObject.GetComponent<Animator>();
        idleMoveAnimationTimer = Random.Range(3.0f, 10.0f);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; //Can't move when skills and stats window is open

        if (!isAttacking)
        {
            if (Input.GetMouseButton(0))
            {
                mouseClickedPosition();
            }

            moveToPosition();
        }
        else
        {
            newPlayerPosition = transform.position;
        }
    }

    public void mouseClickedPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
            newPlayerPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, newPlayerPosition) > 1.1f)
        {
            Quaternion newPlayerRotation = Quaternion.LookRotation(newPlayerPosition - transform.position);

            newPlayerRotation.x = 0.0f;
            newPlayerRotation.z = 0.0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newPlayerRotation, Time.deltaTime * playerRotationSpeed);

            playerAnimations.SetBool("isRunning", true);
            playerController.SimpleMove(transform.forward * moveSpeed);
        }
        else
        {
            playerAnimations.SetBool("isRunning", false);

            idleMoveAnimationTimer -= Time.deltaTime;

            if (idleMoveAnimationTimer < 0)
            {
                idleMoveAnimationTimer = Random.Range(3.0f, 10.0f);
                playerAnimations.SetBool("IdleMove", true);
            }
            else
            {
                playerAnimations.SetBool("IdleMove", false);
            }
        }
    }

    public void setRotation()
    {
        Quaternion newPlayerRotation = Quaternion.LookRotation(newPlayerPosition - transform.position);

        newPlayerRotation.x = 0.0f;
        newPlayerRotation.z = 0.0f;

        transform.rotation = newPlayerRotation;
    }

    void footstepSound()
    {
        audioSource.PlayOneShot(footstep);
    }
}