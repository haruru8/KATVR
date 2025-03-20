using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
namespace KATVR
{
    public class KATDevice_Walk : Singleton<KATDevice_Walk>
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }
        #region Basic Variable - 基础变量

        /* Runtime是否启动 */
        //public static bool Launched;
        public bool Launched;

        /* 身体转向角度 */
        //public static int bodyYaw;
        public int bodyYaw;

        /* 是否移动 */
        //public static int isMoving;
        public int isMoving;

        /* 前进方向 -1 为前进 0 为停止 1 为倒退 */
        //public static int moveDirection;
        public int moveDirection;

        /* 默认移动速度 从0到1*/
        //public static float moveSpeed;
        public float moveSpeed;

        /* 行走的能量值 */
        //public static double WalkPower;
        public double WalkPower;

        /* 玩家在现实中行走的距离 单位是米 */
        //public static float meter;
        public int meter;

        /* 最大移动能量 */
        //public static float maxMovePower, bodyRotation;
        public float maxMovePower, bodyRotation;

        //private static float newBodyYaw, newCameraYaw;
        private float newBodyYaw, newCameraYaw;




        #region Rec
        //[HideInInspector]
        public float data_bodyYaw, data_meter, data_moveSpeed, data_DisplayedSpeed;
        //[HideInInspector]
        public double data_walkPower;
        //[HideInInspector]
        public int data_moveDirection, data_isMoving;
        #endregion

        #endregion


        #region Function - 函数使用
        public void Initialize()
        {
            if (!Launched)
            {
                int Result = Loco_Init();
                if (Result >= 0)
                {
                    Launched = true;
                }
            }
        }
        public void UpdateData()
        {
            if (Launched)
            {
                Get_Loco_Data(ref bodyYaw, ref WalkPower, ref moveDirection, ref isMoving, ref meter);
                bodyYaw = (int)Math.Floor((float)bodyYaw / 1024 * 360);
                //bodyRotation = newCameraYaw;
                bodyRotation = (float)bodyYaw - newBodyYaw + newCameraYaw;
                WalkPower = Math.Round((double)WalkPower, 2);
                //moveSpeed = (float)WalkPower / 3000f;
                moveSpeed = (float)WalkPower / 10f;
                moveDirection = -moveDirection;
                //if (moveSpeed > 1) moveSpeed = 1;
                //else if (moveSpeed < 0.3f) moveSpeed = 0;
                data_bodyYaw = bodyRotation;
                data_walkPower = WalkPower;
                data_moveSpeed = data_DisplayedSpeed = moveSpeed * Time.deltaTime;
                data_moveDirection = moveDirection;
                data_isMoving = isMoving;
                data_meter = meter;
            }
            else
            {
                Initialize();
            }
        }

        public void ResetCamera(Transform handset)
        {
            if (handset != null)
            {
                newCameraYaw = handset.transform.localEulerAngles.y;
                //newCameraYaw = handset.transform.eulerAngles.y;
                int Yaw2 = 0;
                Get_Loco_Data(ref Yaw2, ref WalkPower, ref moveDirection, ref isMoving, ref meter);
                Yaw2 = (int)Math.Floor((float)Yaw2 / 1024 * 360);
                newBodyYaw = (float)Yaw2;
            }
            else
            {
                Debug.LogError("数据不存在");
            }
        }
        #endregion


        #region Interface
        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <returns>
        /// -1:内存开辟失败
        /// -2:线程启动失败
        /// 0:初始化成功
        /// 1:已初始化
        /// </returns>
        [DllImport("WalkerBase_Loco.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Loco_Init();

        /// <summary>
        /// 获取行走数据
        /// </summary>
        /// <param name="Bodyyaw">角度</param>
        /// <param name="WalkPower">速度</param>
        /// <param name="MoveDirection">方向 -1：前进/1：后退</param>
        /// <param name="IsMoving">是否在行走：1：是 0：否</param>
        /// <param name="Distance">总路程（暂不生效）</param>
        /// <returns>
        /// -1:未初始化
        /// 0:获取成功
        /// </returns>
        [DllImport("WalkerBase_Loco.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Get_Loco_Data(ref int Bodyyaw, ref double WalkPower, ref int MoveDirection, ref int IsMoving, ref int Distance);

        /// <summary>
        /// 获取特殊动作数据
        /// </summary>
        /// <param name="Action">-1：左平移 1：右平移 0：其他</param>
        /// <returns>
        /// -1:未初始化
        /// 0:获取成功
        /// </returns>
        [DllImport("WalkerBase_Loco.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Get_Loco_Action(ref int Action);

        #endregion
    }
}

