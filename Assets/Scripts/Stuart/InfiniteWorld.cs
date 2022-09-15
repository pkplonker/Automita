using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StuartH
{
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
            for (var i = 0; i < startPieces - 1; i++)
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
                    if (spawnedPieceTypesArr.Length > 2 &&
                        (spawnedPieceTypesArr[spawnedPieceTypesArr.Length - 1] == pieceType &&
                         spawnedPieceTypesArr[spawnedPieceTypesArr.Length - 2] == pieceType))
                    {
                        requestedPrefab = null;
                        Debug.Log("Rerolling");
                        continue;
                    }
                }
                

                CalculateDirection(pieceType);
                SpawnPiece(requestedPrefab, pieceType);
                DespawnOldPiece();
                break;
                
            }
        }

        private void DespawnOldPiece()
        {
            if (spawnedPieces.Count > maxSpawnedPieces) Destroy(spawnedPieces.Dequeue());
        }

        private void SpawnPiece(GameObject requestedPrefab, PieceType pieceType)
        {
            GameObject spawnedObject;
            spawnedPieceTypes.Enqueue(pieceType);
            spawnedObject = Instantiate(requestedPrefab, currentPosition, Quaternion.Euler(0, 90 * (int)compass, 0),
                transform);
            spawnedObject.GetComponent<Tile>().Init(DeleteCallback);
            currentPosition += currentDirection;
            spawnedPieces.Enqueue(spawnedObject);
        }

        private void CalculateDirection(PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.Left:
                {
                    compass -= 1;
                    if (compass < Compass.North) compass = Compass.West;
                    break;
                }
                case PieceType.Right:
                {
                    compass += 1;
                    if (compass > Compass.West) compass = Compass.North;
                    break;
                }
            }

            currentDirection = directions[(int)compass];
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
            go = Random.Range(0f, 1f) > 0.5f ? leftPieces[Random.Range(0, leftPieces.Count)] : rightPieces[Random.Range(0, rightPieces.Count)];
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
}
