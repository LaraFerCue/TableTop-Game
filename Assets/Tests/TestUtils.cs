using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Tests
{
    public class TestUtils
    {
        public static GameObject CreatePlayer(string name)
        {
            GameObject player = new GameObject(name);
            player.tag = "Player";
            player.AddComponent<Movement>();
            player.AddComponent<Character>();

            GameObject projector = new GameObject("Projector");
            projector.transform.SetParent(player.transform);
            projector.name = "Projector";
            projector.AddComponent<Projector>();

            return player;
        }

        public static GameObject CreateMeleeWeapon(string name, string[] targets)
        {
            GameObject weapon = new GameObject(name);
            MeleeWeapon meleeWeapon = weapon.AddComponent<MeleeWeapon>();
            meleeWeapon.targets = targets;

            return weapon;
        }
    }
}