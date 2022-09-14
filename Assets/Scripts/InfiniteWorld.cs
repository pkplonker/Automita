using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
///InfiniteWorld - Handles creation and destruction of infinite world.
/// </summary>
public class InfiniteWorld : MonoBehaviour
{

    [SerializeField] private List<GameObject> straightPieces;
    [SerializeField] private List<GameObject> leftPieces;
    [SerializeField] private List<GameObject> rightPieces;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private bool isEnabled = true;
    [Range(0, 20)] [SerializeField] private int maxSpawnedPieces = 10;
    [Range(0, 10)] [SerializeField] private int startPieces = 4;
    [Range(0, 20)] [SerializeField] private int tileSize = 5;
    [Range(0, 1)] [SerializeField] private float cornerChance = 0.1f;

    private Queue<GameObject> spawnedPieces = new Queue<GameObject>();
    private Queue<PieceType> spawnedPieceTypes = new Queue<PieceType>();

    private Compass compass = Compass.North;
    private Vector3 currentPosition = new Vector3(0, 0, -2.5f);
    private Vector3 currentDirection;
    private List<Vector3> directions = new List<Vector3>();

    protected void Awake()
    {
        CreateDirections();
        currentDirection = directions[(int)compass];
        SpawnNext(straightPieces[0]);
        spawnedPieceTypes.Enqueue(PieceType.Straight);
        for (var i = 0; i < startPieces-1; i++)
        {
            spawnedPieceTypes.Enqueue(PieceType.Straight);
            SpawnNext(straightPieces[Random.Range(0, straightPieces.Count)]);
        }
    }

    private void CreateDirections()
    {
        directions.Add(new Vector3(0, 0, tileSize)); //n
        directions.Add(new Vector3(tileSize, 0, 0)); //e
        directions.Add(new Vector3(0, 0, -tileSize)); //s
        directions.Add(new Vector3(-tileSize, 0, 0)); //w
    }


    private void SpawnNext(GameObject requestedPrefab = null)
    {
        while (true)
        {
            GameObject spawnedObject = null;
            if (requestedPrefab == null) requestedPrefab = DetermineNext();
            PieceType pieceType;
            if (straightPieces.Contains(requestedPrefab))
                pieceType = PieceType.Straight;
            else if (leftPieces.Contains(requestedPrefab))
                pieceType = PieceType.Left;
            else
                pieceType = PieceType.Right;
            var spawnedPieceTypesArr = spawnedPieceTypes.ToArray();
            if (pieceType == PieceType.Left || pieceType == PieceType.Right)
            {
                if (spawnedPieceTypesArr.Length > 2&&(spawnedPieceTypesArr[spawnedPieceTypesArr.Length - 1] == pieceType && spawnedPieceTypesArr[spawnedPieceTypesArr.Length - 2] == pieceType))
                {
                    requestedPrefab = null;
                    continue;
                }
            }

            spawnedPieceTypes.Enqueue(pieceType);
            spawnedObject = Instantiate(requestedPrefab, currentPosition, Quaternion.Euler(0, 90 * (int)compass, 0), transform);
            spawnedObject.GetComponent<Tile>().Init(DeleteCallback);
            currentPosition += currentDirection;
            spawnedPieces.Enqueue(spawnedObject);
            if (spawnedPieces.Count > maxSpawnedPieces) Destroy(spawnedPieces.Dequeue());
            break;
        }
    }

    private void DeleteCallback(GameObject tile)
    {
        if (spawnedPieces.Peek() != tile) Debug.Log("Check this");
        Destroy(spawnedPieces.Dequeue());
        SpawnNext();
    }

    private GameObject DetermineNext()
    {
        GameObject go = null;
        if (!(Random.Range(0f, 1f) > 1f - cornerChance)) return straightPieces[Random.Range(0, straightPieces.Count)];
        if (Random.Range(0, 1) > 0.5f)
        {
            compass -= 1;
            if (compass < Compass.North) compass = Compass.West;
            currentDirection = directions[(int)compass];
            go = leftPieces[Random.Range(0, leftPieces.Count)];
        }
        else
        {
            compass += 1;
            if (compass > Compass.West) compass = Compass.North;
            currentDirection = directions[(int)compass];
            go = rightPieces[Random.Range(0, rightPieces.Count)];
        }
        return go;
    }
    
    private enum Compass
    {
        North,
        East,
        South,
        West
    }
    private enum PieceType
    {
       Straight,
       Left,
       Right
    }
}
