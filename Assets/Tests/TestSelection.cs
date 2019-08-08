using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts;

namespace Tests
{
    public class TestSelection
    {
        

        private GameObject GetProjectorFromPlayer(GameObject player)
        {
            Transform projector = player.transform.Find("Projector");
            return projector.gameObject;
        }

        // A Test behaves as an ordinary method
        [Test]
        public void TestSelectionSelectPlayer()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = TestUtils.CreatePlayer("Player 1");
            GameObject player2 = TestUtils.CreatePlayer("Player 2");

            selection.SelectPlayer(player1.transform);

            Assert.That(GetProjectorFromPlayer(player1).activeSelf,
                "Player1 is not active - selected");
            Assert.That(! GetProjectorFromPlayer(player2).activeSelf,
                "Player 2 is active - not selected");

            selection.SelectPlayer(player2.transform);
            Assert.That(!GetProjectorFromPlayer(player1).activeSelf,
                "Player1 is active - not selected");
            Assert.That(GetProjectorFromPlayer(player2).activeSelf,
                "Player 2 is not active - selected");

            selection.SelectPlayer(player2.transform);
            Assert.That(!GetProjectorFromPlayer(player1).activeSelf,
                "Player1 is active - not selected");
            Assert.That(!GetProjectorFromPlayer(player2).activeSelf,
                "Player 2 is active - deselected");
        }

        [Test]
        public void TestSelectionMoveSelectedPlayer()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = TestUtils.CreatePlayer("Player1");

            selection.SelectPlayer(player1.transform);
            selection.MoveSelectedPlayer(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 destination = player1.GetComponent<Movement>().Destination;
            Assert.That(destination.x == 1.0f, 
                "X parameter incorrectly set");
            Assert.That(destination.y == 0.0f,
                "Y parameter incorrectly set");
            Assert.That(destination.z == 4.0f,
                "Z parameter incorrectly set");
        }

        [Test]
        public void TestSelectionMoveSelectedPlayerNoPlayerSelected()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = TestUtils.CreatePlayer("Player1");

            selection.MoveSelectedPlayer(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 destination = player1.GetComponent<Movement>().Destination;
            Assert.That(destination.x == 0.0f,
                "X parameter incorrectly set");
            Assert.That(destination.y == 0.0f,
                "Y parameter incorrectly set");
            Assert.That(destination.z == 0.0f,
                "Z parameter incorrectly set");
        }

        [Test]
        public void TestSelectionSetLookDirection()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = TestUtils.CreatePlayer("Player1");

            selection.SelectPlayer(player1.transform);
            selection.SetLookDirectionToSelectedPlayer(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 direction = player1.GetComponent<Movement>().Direction;
            Debug.Log(direction);
            Assert.That(direction.x == 1.0f, "X parameter incorrectly set");
            Assert.That(direction.y == 0.0f, "Y parameter incorrectly set");
            Assert.That(direction.z == 4.0f, "X parameter incorrectly set");
        }

        [Test]
        public void TestSelectionSetLookDirectionNoPlayerSelected()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = TestUtils.CreatePlayer("Player1");

            selection.SetLookDirectionToSelectedPlayer(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 direction = player1.GetComponent<Movement>().Direction;
            Debug.Log(direction);
            Assert.That(direction.x == 0.0f, "X parameter incorrectly set");
            Assert.That(direction.y == 0.0f, "Y parameter incorrectly set");
            Assert.That(direction.z == 0.0f, "X parameter incorrectly set");
        }
    }
}
