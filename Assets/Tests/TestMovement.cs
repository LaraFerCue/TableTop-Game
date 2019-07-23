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

            Assert.That(movement.Direction.x == 0.0f);
            Assert.That(movement.Direction.y < 0.39f && movement.Direction.y > 0.38f);
            Assert.That(movement.Direction.z == 0.0f);
            Assert.That(movement.Direction.w > 0.92f && movement.Direction.w < 0.93f);
            Assert.That(movement.IsRotating);
        }

        [Test]
        public void TestMovementMove()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();

            movement.SetDestination(new Vector3(1.0f, 0.0f, 4.0f));

            Assert.That(movement.Destination.x == 1.0f);
            Assert.That(movement.Destination.y == 0.0f);
            Assert.That(movement.Destination.z == 4.0f);
            Assert.That(movement.IsMoving);
        }

    }
}
