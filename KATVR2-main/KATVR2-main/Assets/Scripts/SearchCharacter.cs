using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    private void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        moveEnemy.OnStateChanged += OnEnemyStateChanged;
    }

    private void OnEnemyStateChanged(MoveEnemy.EnemyState newState, Transform target)
    {
        if (newState == MoveEnemy.EnemyState.Chase)
        {
            moveEnemy.SetState(MoveEnemy.EnemyState.Chase, target);
        }
        else if (newState == MoveEnemy.EnemyState.Wait)
        {
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }
}