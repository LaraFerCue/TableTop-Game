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
        private GameObject CreatePlayer(string name)
        {
            GameObject player = new GameObject(name);
            player.tag = "Player";
            player.AddComponent<Movement>();
            GameObject projector = new GameObject("Projector");
            projector.transform.SetParent(player.transform);
            projector.name = "Projector";
            projector.AddComponent<Projector>();

            return player;
        }

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
            GameObject player1 = CreatePlayer("Player 1");
            GameObject player2 = CreatePlayer("Player 2");

            selection.SelectPlayer(player1.transform);

            Assert.That(GetProjectorFromPlayer(player1).activeSelf);
            Assert.That(! GetProjectorFromPlayer(player2).activeSelf);

            selection.SelectPlayer(player2.transform);
            Assert.That(!GetProjectorFromPlayer(player1).activeSelf);
            Assert.That(GetProjectorFromPlayer(player2).activeSelf);

            selection.SelectPlayer(player2.transform);
            Assert.That(!GetProjectorFromPlayer(player1).activeSelf);
            Assert.That(!GetProjectorFromPlayer(player2).activeSelf);
        }

        [Test]
        public void TestSelectionMoveSelectedPlayer()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = CreatePlayer("Player1");

            selection.SelectPlayer(player1.transform);
            selection.MoveSelectedPlayer(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 destination = player1.GetComponent<Movement>().Destination;
            Assert.That(destination.x == 1.0f);
            Assert.That(destination.y == 0.0f);
            Assert.That(destination.z == 4.0f);
        }

        [Test]
        public void TestSelectionSetLookDirection()
        {
            GameObject gameController = new GameObject("GameController");
            Selection selection = gameController.AddComponent<Selection>();
            GameObject player1 = CreatePlayer("Player1");

            selection.SelectPlayer(player1.transform);
            selection.SetLookDirectionToSelectedPlayer(new Vector3(1.0f, 0.0f, 4.0f));

            Vector3 direction = player1.GetComponent<Movement>().Direction;
            Debug.Log(direction);
            Assert.That(direction.x == 1.0f);
            Assert.That(direction.y == 0.0f);
            Assert.That(direction.z == 4.0f);
        }
    }
}
