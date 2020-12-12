#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using UnityEngine;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace UnityEngine.Recorder.Examples
{
    /// <summary>
    /// Script sets up an Image Sequence recording session via script.
    /// To use, add the RecordImageSeq component to a GameObject.
    ///
    /// Entering playmode will start the recording.
    /// The recording will automatically stops when exiting playmode (or when the component is disabled).
    ///
    /// Recording outputs are saved in [Project Folder]/SampleRecordings.
    /// </summary>
    public class RecordImageSeq : MonoBehaviour
    {
        RecorderController m_RecorderController;
        public float frameRate = 60.0f;
        public int outputWidth = 1280; //1920;
        public int outputHeight = 720; //1080;
        public float contrastTresh = 0.05f;


        void OnEnable()
        {
            var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
            m_RecorderController = new RecorderController(controllerSettings);

            var mediaOutputFolder = Path.Combine(Application.dataPath, "..", "SampleRecordings");

            // Image Sequence Parameters
            var imageRecorder = ScriptableObject.CreateInstance<ImageRecorderSettings>();
            imageRecorder.name = "My Image Recorder";
            imageRecorder.Enabled = true;

            imageRecorder.OutputFormat = ImageRecorderSettings.ImageRecorderOutputFormat.PNG;
            imageRecorder.CaptureAlpha = true;

            imageRecorder.OutputFile = Path.Combine(mediaOutputFolder, "image_" + DefaultWildcard.Frame);

            imageRecorder.imageInputSettings = new CameraInputSettings
            {
                Source = ImageSource.MainCamera,
                OutputWidth = outputWidth,
                OutputHeight = outputHeight,
                CaptureUI = false,
                FlipFinalOutput = true
            };

            // Setup Recording
            controllerSettings.AddRecorderSettings(imageRecorder);

            controllerSettings.SetRecordModeToManual();
            controllerSettings.FrameRate = frameRate;

            RecorderOptions.VerboseMode = false;
            //m_RecorderController.PrepareRecording();
            //m_RecorderController.StartRecording();
        }

        void OnDisable()
        {
            //m_RecorderController.StopRecording();
            //ESIMCall();

        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 200, 80), "Start Recording"))
            {
                m_RecorderController.PrepareRecording();
                m_RecorderController.StartRecording();
            }

            if (GUI.Button(new Rect(10, 100, 200, 80), "Stop & Convert"))
            {
                m_RecorderController.StopRecording();
                ESIMCall();
            }
        }

        void ESIMCall(){
            string videoPath = Directory.GetCurrentDirectory();
            videoPath = videoPath + "/SampleRecordings";
            string esimPath = Path.Combine(Application.dataPath, "Scripts");

            string command = "cd " + esimPath + "; gnome-terminal -x ./scriptRos.sh " + videoPath + " " + contrastTresh;
            UnityEngine.Debug.Log("Print command: " + command);

            ExecuteCommand(command);
            UnityEngine.Debug.Log("ESIM conversion started.");
        }

        void ExecuteCommand(string command)
        {
            Process proc = new System.Diagnostics.Process ();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + command + " \"";
            proc.StartInfo.UseShellExecute = false; 
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start ();

            while (!proc.StandardOutput.EndOfStream) {
                Console.WriteLine (proc.StandardOutput.ReadLine ());
            }
        }

    }
}

#endif
