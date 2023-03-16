using UnityEngine;
     
namespace DebugStuff
{
    public class Global : MonoBehaviour
    {
        static string myLog = "";
        private string output;
        private string stack;

        private bool isGuiDIsplay = false;

        void OnEnable()
        {
            Application.logMessageReceived += Log;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= Log;
        }

        public void Log(string logString, string stackTrace, LogType type)
        {
            output = logString;
            stack = stackTrace;
            myLog = output + "\n" + myLog;
            if (myLog.Length > 5000)
            {
                myLog = myLog.Substring(0, 4000);
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                isGuiDIsplay = !isGuiDIsplay;
            }
            
            if (Input.GetKeyDown(KeyCode.F3))
            {
                if(Cursor.lockState == CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false; 
                }
                else{
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true; 
                }
            }
        }

        void OnGUI()
        {
            if(isGuiDIsplay){
                myLog = GUI.TextArea(new Rect(10, 10, Screen.width - 10, Screen.height / 2 - 10), myLog);
            }
        }
    }
}