using UnityEngine;

public class ObstacleSpwner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject player;

    [SerializeField] private float interval = 5.0f;
    private float nextTime;

    void FixedUpdate()
    {
        if (player != null)
        {
            if (Time.time >= nextTime)
            {
                Instantiate(obstacle, transform.position + new Vector3(0f, Random.Range(-4f, 5f), 0f), Quaternion.identity);
                nextTime = Time.time + interval;
                interval -= 0.1f;
            }
        }
    }
}
