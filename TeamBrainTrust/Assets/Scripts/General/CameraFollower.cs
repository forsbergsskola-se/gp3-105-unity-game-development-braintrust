using Player;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject target;
    public float maxDistance = 0.5f;

    private void Start()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();
        target = player.gameObject;
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    
    private void FollowTarget()
    {
        Vector3 targetPosition = target.transform.position + new Vector3(0, 0, -7.5f);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * maxDistance);
    }
    
}
