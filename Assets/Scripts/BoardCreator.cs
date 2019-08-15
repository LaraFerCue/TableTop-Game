using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class BoardCreator : MonoBehaviour
    {
        public GameObject boardFloor;
        public GameObject floorTile;

        private void Awake()
        {
            Vector3 boardSize = boardFloor.GetComponent<Collider>().bounds.size;
            Vector3 tileSize = floorTile.GetComponent<BoxCollider>().size;
            int[] numberOfTiles = new int[2] { (int)(boardSize.x / tileSize.x), (int)(boardSize.z / tileSize.y) };

            Debug.Log("number of tiles = " + numberOfTiles[0] + "x" + numberOfTiles[1]);
            for (int idx = 0; idx <= numberOfTiles[0]; idx++)
            {
                for (int idy = 0; idy < numberOfTiles[1]; idy++)
                {
                    GameObject tile = Instantiate(floorTile);
                    tile.transform.parent = transform;
                    tile.transform.position = new Vector3(
                        boardFloor.transform.position.x  + idx * tileSize.x * 0.75f - (numberOfTiles[0] -1) * tileSize.x * 0.5f,
                        floorTile.transform.position.y,
                        boardFloor.transform.position.z + (idx % 2) * tileSize.y * 0.5f - (numberOfTiles[1] - 0.5f) * tileSize.y * 0.5f + idy * tileSize.y
                        );
                }
            }
        }
    }
}
