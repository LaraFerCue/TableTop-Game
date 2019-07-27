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

        [Test]
        public void TestMovementDestination()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();

            movement.Destination = new Vector3(1.0f, 0.0f, 4.0f);

            Assert.That(movement.Destination.x == 1.0f);
            Assert.That(movement.Destination.y == 0.0f);
            Assert.That(movement.Destination.z == 4.0f);
            Assert.That(movement.IsMoving);
        }

        [Test]
        public void TestMovementDirection()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();

            movement.Direction = new Vector3(1.0f, 0.0f, 4.0f);

            Assert.That(movement.Direction.x == 1.0f);
            Assert.That(movement.Direction.y == 0.0f);
            Assert.That(movement.Direction.z == 4.0f);
            Assert.That(movement.IsRotating);
        }

        [Test]
        public void TestMovementMoveTorwards()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();
            movement.speed = 1.0f;

            movement.Destination = new Vector3(1.0f, 0.0f, 4.0f);

            int seconds = 0;
            while (movement.IsMoving && seconds < 10)
            {
                movement.MoveTorwards(1.0f);
                seconds++;
            }
            Assert.That(Vector3.Distance(pawn.transform.position, new Vector3(1.0f, 0.0f, 4.0f)) < 0.1f);
        }

        [Test]
        public void TestMovementLookTorwards()
        {
            GameObject pawn = new GameObject();
            Movement movement = pawn.AddComponent<Movement>();
            movement.angularSpeed = 1.0f;

            movement.Direction = new Vector3(1.0f, 0.0f, 4.0f);

            int seconds = 0;
            while (movement.IsRotating && seconds < 10)
            {
                movement.LookTorwards(1.0f);
                seconds++;
            }
            Assert.That(Quaternion.Angle(pawn.transform.rotation, new Quaternion(0.0f, 0.1f, 0.0f, 1.0f)) < 5.0f);
        }
    }
}
