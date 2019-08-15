using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public enum TerrainType
    {
        REGULAR = 0,
        DIFFICULT = 1,
        VERY_DIFFICULT = 2,
        IMPASSABLE = 3,
        IMPOSSIBLE = 10
    }

    public class Object : MonoBehaviour
    {
        public TerrainType terrainType;
    }
}