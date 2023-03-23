using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    [SerializeField]private Player player;
    [SerializeField]private StackEffect stackEffect;
    [SerializeField]private CollectCubeText collectCubeText;
    [SerializeField]private List<Transform> cubesTransform;
    [SerializeField]private List<Cube> cubes;
    [SerializeField]private float moveSpeed = 10f;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    public void AddCubeToTower(Transform cubeTransform, Cube cube){
        AddCubeToLists(cubeTransform, cube);
        stackEffect.CallStackEffect();
        collectCubeText.CallCollectCubeText();
        player.Jump(GetTopCubePos());
    }

    private void AddCubeToLists(Transform cubeTransform, Cube cube){
        cubesTransform.Add(cubeTransform);
        cubes.Add(cube);
    }

    public void RemoveCubeFromLists(Transform cubeTransform, Cube cube){
        cubesTransform.Remove(cubeTransform);
        cubes.Remove(cube);
    }

    public Vector3 GetTopCubePos(){
        return cubesTransform[cubesTransform.Count - 1].position;
    }

    public void MoveTower(float direction){
        Vector3 playerMoveDirection = new Vector3(direction * moveSpeed, player.transform.position.y, -moveSpeed);
        player.MovePlayer(playerMoveDirection);
        foreach (var cube in cubes){
            cube.MoveCube(player.transform);
        }
    }

}
