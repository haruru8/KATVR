using UnityEngine;
using UnityEngine.Events;

public class MoveEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        Wait,
        Patrol,
        Chase
    }

    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] private float waitTime = 5f;

    private CharacterController enemyController;
    private Animator animator;
    private SetPosition setPosition;

    private Vector3 destination;
    private Vector3 velocity;
    private Vector3 direction;

    private bool arrived;
    private float elapsedTime;

    private EnemyState currentState;
    private Transform playerTransform;

    public event UnityAction<EnemyState, Transform> OnStateChanged;

    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        destination = setPosition.GetDestination();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        currentState = EnemyState.Wait;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Wait:
                Wait();
                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
        }
    }

    public void SetState(EnemyState newState, Transform target = null)
    {
        if (newState == currentState) return;
        currentState = newState;
        playerTransform = target;
        OnStateChanged?.Invoke(newState, target);
    }

    private void Wait()
    {
        animator.SetFloat("Speed", 0.0f);
        elapsedTime += Time.deltaTime;

        if (elapsedTime > waitTime)
        {
            setPosition.CreateRandomPosition();
            destination = setPosition.GetDestination();
            arrived = false;
            elapsedTime = 0f;
            SetState(EnemyState.Patrol);
        }
    }

    private void Patrol()
    {
        if (!arrived)
        {
            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                direction = (destination - transform.position).normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * walkSpeed;
                animator.SetFloat("Speed", walkSpeed);
            }
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination) < 0.5f)
            {
                arrived = true;
                animator.SetFloat("Speed", 0.0f);
                SetState(EnemyState.Wait);
            }
        }
    }

    private void Chase()
    {
        if (playerTransform == null) return;

        if (enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            direction = (playerTransform.position - transform.position).normalized;
            transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
            velocity = direction * walkSpeed;
            animator.SetFloat("Speed", walkSpeed);
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }
}
