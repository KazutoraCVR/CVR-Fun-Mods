using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KazutoraMods.PlayerRotate
{
    class PlayerRotater : MelonMod
    {
        public static Quaternion DefaultRotation = new Quaternion(0, 90, 0 , 0);
        public static bool Rotate;
        public static float RotationSpeed = 50;
        public static GameObject GetLocalPlayer;
        public static GameObject[] GetAllGameObjects()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }
        public static GameObject LocalPlayer()
        {
            return GameObject.Find("_PLAYERLOCAL");
        }

        public override void OnApplicationStart()
        {
            
        }

        public override void OnUpdate()
        {
            try
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    if (Rotate == false)
                    {
                        Rotate = true;
                        MelonLogger.Msg("Rotater On");
                    }
                    else if (Rotate == true)
                    {
                        Rotate = false;
                        LocalPlayer().transform.rotation = DefaultRotation;
                        MelonLogger.Msg("Rotater Off");
                    }
                        
                }
                if (Rotate)
                {
                    if (Input.anyKey)
                    {
                        if (Input.GetKey(KeyCode.UpArrow))
                        {
                            LocalPlayer().transform.Rotate(Vector3.right, RotationSpeed * Time.deltaTime);
                        }
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            LocalPlayer().transform.Rotate(Vector3.left, RotationSpeed * Time.deltaTime);
                        }
                        if (Input.GetKey(KeyCode.RightArrow))
                        {
                            LocalPlayer().transform.Rotate(Vector3.back, RotationSpeed * Time.deltaTime);
                        }
                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            LocalPlayer().transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}
