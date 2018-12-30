using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameTools
{
    public static class UnityTool
    {
        public static GameObject FindGameObject(string gameObjectName) {
            GameObject tmpGameObject = GameObject.Find(gameObjectName);
            if (tmpGameObject == null) {
                Debug.LogWarning("Can not find Game Object [" + gameObjectName + "] in current scene.");
                return null;
            }
            return tmpGameObject;
        }

        public static GameObject FindChildGameObject(GameObject container, string gameObjectName) {
            if (container == null) {
                Debug.LogError("UnityTool.FindChildGameObject:container = null");
                return null;
            }
            Transform gameObjectTF = null;
            if (container.name == gameObjectName)
            {
                gameObjectTF = container.transform;
            }
            else {
                Transform[] allChildren = container.transform.GetComponentsInChildren<Transform>();
                foreach (var child in allChildren)
                {
                    if (child.name == gameObjectName) {
                        if (gameObjectTF == null)
                            gameObjectTF = child;
                        else
                            Debug.LogError(
                                "same child object below container["
                                + container.name +
                                "]"
                            );
                    }
                }
            }

            if (gameObjectTF == null) {
                Debug.LogError(
                    "can not find child component [" +
                    gameObjectName + "] below container [" +
                    container.name + "]"
                );
                return null;
            }
            return gameObjectTF.gameObject;
        }

    }
}
