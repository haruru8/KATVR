using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
namespace KATVR
{
    public static class KATVR_Basic
    {
        #region Basic Variable - 
        public enum LanguageList { Chinese, Engligh };
        public static LanguageList Language;
        #endregion
    }

    public class KATVR_Global
    {
        public static KATDevice_Walk KDevice_Walk;
    }

}