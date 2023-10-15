using System;
using ECS;
using UnityEngine;

namespace UI
{
    public class StartPanel : MonoBehaviour
    {
        public EcsGameStartup Startup;
        public GameObject Count;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Startup.isStart = true;
                Count.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}