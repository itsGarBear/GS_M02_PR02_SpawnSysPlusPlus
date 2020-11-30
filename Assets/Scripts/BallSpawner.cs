using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public void SpawnBall(GameObject sport)
    {
        Instantiate(sport);
    }
}
