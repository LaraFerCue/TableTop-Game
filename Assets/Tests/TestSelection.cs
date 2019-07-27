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
    }
}
