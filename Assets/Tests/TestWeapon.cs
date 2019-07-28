using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts;

namespace Tests
{
    public class TestWeapon
    {
        [Test]
        public void TestWeaponSimpleDamage()
        {
            string[] tags = new string[1] { "Player" };
            GameObject player = TestUtils.CreatePlayer("Player1");
            GameObject weaponObject = TestUtils.CreateMeleeWeapon("Punch", tags);
            Weapon weapon = weaponObject.GetComponent<Weapon>();
            weapon.minDamage = weapon.maxDamage = 1;

            Character character = player.GetComponent<Character>();
            
            Assert.That(character.HitPoints == 10);
            weapon.Attack(player);
            Assert.That(character.HitPoints == 9);
        }

        [Test]
        public void TestWeaponRandomDamage()
        {
            string[] tags = new string[1] { "Player" };
            GameObject player = TestUtils.CreatePlayer("Player1");
            GameObject weaponObject = TestUtils.CreateMeleeWeapon("Punch", tags);
            Weapon weapon = weaponObject.GetComponent<Weapon>();
            weapon.minDamage = 1;
            weapon.maxDamage = 10;

            Character character = player.GetComponent<Character>();

            Assert.That(character.HitPoints == 10);
            weapon.Attack(player);
            Assert.That(character.HitPoints < 10 && character.HitPoints >= 0);
        }
    }
}
