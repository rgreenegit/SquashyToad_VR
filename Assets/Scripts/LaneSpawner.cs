using UnityEngine;
using System.Collections;

enum LaneType { Safe, Danger };

public class LaneSpawner : MonoBehaviour {

    public GameObject[] safeLanePrefabs;
    public GameObject[] dangerousLanePrefabs;
    LaneType lastLaneType = LaneType.Safe;
    public float safeLaneRunProbability = 0.2f;
    public float laneSpawnDistance = 50000;
    public GameObject player;


    int offset = 0;

    void Update () {

		// infinite lanes
        while (offset < laneSpawnDistance + player.transform.position.z)
        {
            CreateRandomLane(offset);
            offset += 1000;
        }

        // lane cleanup
        foreach (Transform laneTransform in this.transform)
        {
            if (laneTransform.position.z + laneSpawnDistance < player.transform.position.z)
            {
                Destroy(laneTransform.gameObject);
            }
        }
    }
   

    void CreateRandomLane(float offset)
    {
        GameObject lane;
        if (lastLaneType == LaneType.Safe)
        {
            if (Random.value < safeLaneRunProbability) // run of safe lanes
            {
                lastLaneType = LaneType.Safe;
                lane = InstantiateRandomLane(safeLanePrefabs);
            } else
            {
                lastLaneType = LaneType.Danger;
                lane = InstantiateRandomLane(dangerousLanePrefabs);
            }
        }
        else
        {
            lastLaneType = LaneType.Safe;
            lane = InstantiateRandomLane(safeLanePrefabs);
        }
        lane.transform.SetParent(transform, false);
        lane.transform.Translate(0, 0, offset);
    }

    GameObject InstantiateRandomLane(GameObject[] lanes)
    {
        int laneIndex = Random.Range(0, lanes.Length);
        return Instantiate(lanes[laneIndex]);
    }
}
