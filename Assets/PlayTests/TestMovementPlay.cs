using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts;

namespace Tests
{
    public class TestMovementPlay
    {

        [UnityTest]
        public IEnumerator TestMovementMoveObject()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();
            movement.speed = 1.0f;

            movement.Destination = new Vector3(1.0f, 0.0f, 4.0f);

            while (movement.IsMoving)
                yield return null;
            Assert.That(pawn.transform.position.x > 0.8f && pawn.transform.position.x < 1.2f);
            Assert.That(pawn.transform.position.z > 3.8f && pawn.transform.position.z < 4.2f);
            Assert.That(!movement.IsMoving);
        }

        [UnityTest]
        public IEnumerator TestMovementRotateObject()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();
            movement.speed = 1.0f;


            while (movement.IsRotating)
                yield return null;

            Debug.Log(pawn.transform.rotation);
        }
    }
}
