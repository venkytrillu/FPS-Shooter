using System.Collections;
using System.Collections.Generic;


public enum GameState
{
    idle,play,pause
}
public class HelperClass 
{
    public static string mouseX= "Mouse X";
    public static string mouseY = "Mouse Y";
    public static string horizontalInput = "Horizontal";
    public static string verticalInput = "Vertical";
}


public class AnimationTags
{
    public static string ShootTrigger = "Shoot";
    public static string AimTrigger = "Aim";
    public static string ReloadTrigger = "Reload";

    public static string ZoomIn_Anim = "ZoomIn";
    public static string ZoomOut_Anim = "ZoomOut";
}


public class Tags
{
    public static string LookRoot = "Look Root";
    public static string ZoomCamera = "FPCamera";
    public static string Crosshair = "Cross_hair";
    public static string Ground = "Ground";
    public static string Player_Tag = "Player";
    public static string Enemy_Tag = "Enemy";

}

public enum WeaponAim
{
    None, SelfAim, Aim
}

public enum WeaponFireType
{
    Single, Multiple
}

public enum WeaponBulletType
{
    Bullet
}

public enum WeaponSelected
{
    Revolver,AssultRifile,ShotGun
}


