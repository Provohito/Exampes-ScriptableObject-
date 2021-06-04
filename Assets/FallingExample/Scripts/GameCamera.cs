using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Filling
{
    /// <summary>
    /// Расстояние до границы экрана
    /// </summary>
    public class GameCamera : MonoBehaviour
    {
        private static float border = 0;

        public static float Border
        {
            get
            {
                if (border == 0)
                {
                    var cam = Camera.main;
                    border = cam.aspect * cam.orthographicSize;
                }
                return border;
            }
            private set { }
        }
    }
}
