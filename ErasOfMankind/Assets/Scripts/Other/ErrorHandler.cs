using UnityEngine;

public class ErrorHandler : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnEnable() {
        Application.logMessageReceivedThreaded += handleError;
        Debug.Log("Error Handler Activated");
    }

    void OnDisable() {
        Application.logMessageReceivedThreaded -= handleError;
        Debug.Log("Error Handler Deactivated");
    }

    private void handleError(string logString, string stackTrace, LogType type) {
        if (type == LogType.Exception) {
            MAIL.SEND(string.Format("EXCEPTION: {0}", logString), stackTrace);
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
