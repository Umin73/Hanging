using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 5f;
    public float detectionRange = 10f;
    public float chaseRange = 15f;
    public float maxWanderDistance = 10f;
    public float wanderTimer = 5f;

    private Transform target;
    private Vector3 initialPosition;
    private float timer;
    private bool isChasing = false;
    private Vector3 wanderDestination;

    private void Start()
    {
        target = player;
        initialPosition = transform.position;
        timer = wanderTimer;
        wanderDestination = transform.position;
    }

    private void Update()
    {
        // �÷��̾���� �Ÿ� ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �÷��̾ ���� �Ÿ� �̳��� �ִ� ���
        if (distanceToPlayer <= detectionRange)
        {
            target = player;
            isChasing = true;
        }
        else if (isChasing && distanceToPlayer > chaseRange)
        {
            target = null;
            isChasing = false;
        }

        if (isChasing)
        {
            // �÷��̾ ���� �̵�
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += new Vector3(direction.x, 0f, direction.z) * movementSpeed * Time.deltaTime;
        }
        else
        {
            // �����ο� ������
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                // ���ο� ���� ��ġ ����
                wanderDestination = GetRandomPointInRange(maxWanderDistance);
                timer = 0f;
            }

            // �̵� ���� ����
            Vector3 wanderDirection = (wanderDestination - transform.position).normalized;
            float distanceToDestination = Vector3.Distance(transform.position, wanderDestination);

            if (distanceToDestination > 0.1f)
            {
                transform.position += new Vector3(wanderDirection.x, 0f, wanderDirection.z) * movementSpeed * Time.deltaTime;
            }
        }
    }

    private Vector3 GetRandomPointInRange(float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += initialPosition;
        Vector3 randomPoint = new Vector3(randomDirection.x, initialPosition.y + Random.Range(-range, range), randomDirection.z);
        return randomPoint;
    }
}
