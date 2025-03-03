using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats{

    private static float playerLevel;
    private static int vitorias;
    private static Color playerColor = Color.white;

    public static float PlayerLevel {
        set { playerLevel = value; }
        get { return playerLevel; }
    }

    public static int PlayerVitorias {
        set { vitorias = value; }
        get { return vitorias; }
    }

    public static Color PlayerColor {
        set { playerColor = value; }
        get { return playerColor; }
    }

}
