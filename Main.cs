using BTD_Mod_Helper;
using CandyShooter;
using MelonLoader;

[assembly: MelonModInfo(typeof(CandyShooter.CandyShooterMain), "The Candy Shooter", "1.1.0", "Darinsky")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CandyShooter
{
    public class CandyShooterMain : BloonsTD6Mod
    {
        // No Harmony Patches or hooks required for this whole tower!
    }
}