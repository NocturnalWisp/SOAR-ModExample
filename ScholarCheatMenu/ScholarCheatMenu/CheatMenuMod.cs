using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

namespace ScholarCheatMenu
{
    public class CheatMenuMod : MelonMod
    {
        PlayerHealth playerHealth = null;
        PlayerMovement playerMovement = null;
        SaveData saveData = null;
        string health = "Unavailable";
        string maxHealth = "Unavailable";
        string playerSpeed = "Unavailable";

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
            saveData = GameObject.FindObjectOfType<SaveData>();

            if (playerHealth == null)
            {
                health = "Unavailable";
                maxHealth = "Unavailable";
            }
            else
            {
                playerHealth.StartCoroutine(WaitForSaveData());
            }

            playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

            if (playerMovement == null)
            {
                playerSpeed = "Unavailable";
            }
            else
            {
                if (playerSpeed == "Unavailable")
                {
                    playerSpeed = playerMovement.moveSpeed.ToString();
                }
                else
                {
                    if (float.TryParse(playerSpeed, out float newSpeed))
                    {
                        playerMovement.moveSpeed = newSpeed;
                        playerMovement.normalSpeed = newSpeed;
                    }
                }
            }
        }

        IEnumerator WaitForSaveData()
        {
            yield return new WaitUntil(() => saveData.loadComplete);

            health = playerHealth.CurrentHealthPoints.ToString();
            maxHealth = playerHealth.StartingHealthPoints.ToString();

            if (!saveData.inventory.itemList.Any(o => o.spellID == 31))
            {
                saveData.inventory.AddScrollToInventory(31, 5, 15, 7);
            }
        }

        public override void OnGUI()
        {
            base.OnGUI();

            GUILayout.BeginArea(new Rect(0, 0, 200, 400));
            
            GUI.UnfocusWindow();

            GUI.Label(new Rect(20, 20, 200, 100), "Cheat Menu Loaded");

            var maxHealthField = GUI.TextField(new Rect(20, 100, 150, 20), maxHealth);

            if (playerHealth != null && maxHealthField != health)
            {
                maxHealth = maxHealthField;

                if (float.TryParse(maxHealth, out float newMaxHealth))
                {
                    playerHealth.StartingHealthPoints = newMaxHealth;
                    playerHealth.UpdateHealthBar();
                }
            }

            var healthField = GUI.TextField(new Rect(20, 60, 150, 20), health);

            if (playerHealth != null && healthField != health)
            {
                health = healthField;

                if (float.TryParse(health, out float newHealth))
                {
                    playerHealth.CurrentHealthPoints = newHealth;
                    playerHealth.UpdateHealthBar();
                }
            }

            var speedField = GUI.TextField(new Rect(20, 140, 150, 20), playerSpeed);

            if (playerMovement != null && speedField != playerSpeed)
            {
                playerSpeed = speedField;

                if (float.TryParse(playerSpeed, out float newSpeed))
                {
                    playerMovement.moveSpeed = newSpeed;
                    playerMovement.normalSpeed = newSpeed;
                }
            }

            GUILayout.EndArea();

        }
    }
}
