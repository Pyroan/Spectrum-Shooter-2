using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Constants for keys in playerprefs. Safety baby.
 * oh wait this is COMPLETELY useless.
 */
public class PreferenceKeys : MonoBehaviour
{
    public const string ZEN_MODE = "zen_mode";
    public const string FLASH_COLORS = "flash_colors";
    public const string SHAKE_SCREEN = "screen_shake";
    public const string CONTROL_HINTS = "control_hints";

    public const string PLAY_MUSIC = "music_enabled";
    public const string PLAY_SOUND = "sound_enabled";

    public const string HIGH_SCORE = "high_score";
}

public class Scenes : MonoBehaviour
{
    public const int WARNING = 0;
    public const int TITLE_SCREEN = 1;
    public const int GAME = 2;
    public const int SCORE_SCREEN = 3;
    public const int INSTRUCTIONS = 4;
    public const int OPTIONS = 5;
    public const int CREDITS = 6;
}
