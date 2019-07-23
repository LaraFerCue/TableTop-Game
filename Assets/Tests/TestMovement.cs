using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts;


namespace Tests
{
    public class TestMovement
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestMovementRotate()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();

            movement.Rotate(new Vector3(4.0f, 0.0f, 4.0f));

            Assert.That(pawn.transform.rotation.x == 0.0f);
            Assert.That(pawn.transform.rotation.y < 0.39f && pawn.transform.rotation.y > 0.38f);
            Assert.That(pawn.transform.rotation.z == 0.0f);
            Assert.That(pawn.transform.rotation.w > 0.92f && pawn.transform.rotation.w < 0.93f);
        }

        [Test]
        public void TestMovementMove()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();

            movement.SetDestination(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 destination = movement.GetDestination();
            Assert.That(destination.x == 1.0f);
            Assert.That(destination.y == 0.0f);
            Assert.That(destination.z == 4.0f);
            Assert.That(movement.GetIsMoving());
        }

    }
}
