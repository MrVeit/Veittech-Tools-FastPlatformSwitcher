using UnityEditor;
using UnityEngine;

namespace Veittech.Tools.Editor.FastPlatformSwitcher
{
    [HelpURL("https://github.com/MrVeit/Veittech-Tools-FastPlatformSwitcher")]
    public sealed class TargetPlatformSwitcher
    {
        [MenuItem("Fast Platform Switcher/To WebGL")]
        public static void SwitchToWebGL()
        {
            SwitchTo(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        }

        [MenuItem("Fast Platform Switcher/To Android")]
        public static void SwitchToAndroid()
        {
            SwitchTo(BuildTargetGroup.Android, BuildTarget.Android);
        }

        [MenuItem("Fast Platform Switcher/To IOS")]
        public static void SwitchToiOS()
        { 
            SwitchTo(BuildTargetGroup.iOS, BuildTarget.iOS);
        }

        [MenuItem("Fast Platform Switcher/To Desktop")]
        public static void SwitchToDesktop()
        {
            SwitchTo(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
        }

        public static void SwitchTo(BuildTargetGroup targetGroup, BuildTarget target)
        {
            if (IsTargetPlatformSelected(target))
            {
                Debug.Log($"[Fast Platform Switcher] The target platform {target} is already selected!");

                return;
            }

            Debug.Log($"[Fast Platform Switcher] Switching of the target platform to {targetGroup}");

            var switchResult = EditorUserBuildSettings.SwitchActiveBuildTargetAsync(targetGroup, target);

            if (switchResult)
            {
                Debug.Log($"[Fast Platform Switcher] Successfully switched the target platform to {targetGroup}");

                return;
            }

            Debug.LogWarning("[Fast Platform Switcher] Something got in the way of changing the current platform to the target platform");
        }

        public static bool IsTargetPlatformSelected(BuildTarget targetPlatform)
        {
            if (EditorUserBuildSettings.activeBuildTarget == targetPlatform)
            {
                return true;
            }

            return false;
        }
    }
}