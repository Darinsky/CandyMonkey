using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace CandyShooter.Displays
{
    // All the Card Projectile displays are so similar, I just kept them in one .cs file
    // I would've used the multiple instance loading like in CardMonkeyMultiDisplay,
    // but I wanted to be able to directly reference the different classes themselves

    public class PeppermintDisplayRed : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
     public class PeppermintDisplayInvisible : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            
            Set2DTexture(node, Name);
        }
    }
   public class PeppermintDisplayPink : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
    public class PeppermintDisplayPurple : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
     public class PeppermintDisplayBlue : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
    public class PeppermintDisplayElemental : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
}