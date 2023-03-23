using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    [SerializeField]private List<GameObject> trackPrefabs;
    [SerializeField]private float trackLength;

    private int startTrackObjectsQuantity = 3;
    private float spawnDistanceY = 60;
    private float moveDuration = 1f;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    public void GenerateNewTrackObject(Vector3 currentTrackPosition){
        int trackIndex = Random.Range(0, trackPrefabs.Count);
        GameObject trackPrefab = trackPrefabs[trackIndex];
        float allTracksLength = -trackLength * (float)startTrackObjectsQuantity;
        Vector3 position = new Vector3(currentTrackPosition.x, currentTrackPosition.y - spawnDistanceY, currentTrackPosition.z + allTracksLength);
        GameObject newTrack = Instantiate(trackPrefab, position, Quaternion.identity);
        StartCoroutine(MoveToPoint(newTrack));
    }

    private IEnumerator MoveToPoint(GameObject track){
        Transform trackTransform = track.GetComponent<Transform>();
        Vector3 trackPos = trackTransform.position;
        float dir = trackPos.y + spawnDistanceY;
        float moveTime = 0;
        while(moveTime < moveDuration){
            float newPositionY = Mathf.Lerp(trackPos.y, dir, (moveTime / moveDuration));
            moveTime += Time.deltaTime;
            trackTransform.position = new Vector3(trackPos.x, newPositionY, trackPos.z);
            yield return null;
        }
        yield break;
    }

}