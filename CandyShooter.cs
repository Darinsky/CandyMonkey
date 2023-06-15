using MelonLoader;
using Harmony;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using System;
using System.Text.RegularExpressions;
using System.IO;

using UnityEngine;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Simulation.Track;
using static Il2CppAssets.Scripts.Models.Towers.TargetType;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Models.Towers.Pets;
using Il2CppAssets.Scripts.Unity.Bridge;
using System.Windows;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;

using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using CandyShooter.Displays;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2Cpp;

namespace CandyShooter
{
     public class CandyShooter000 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.BoomerangMonkey, 0, 0, 0);

         public override void ModifyDisplayNode(UnityDisplayNode node) {
            this.SetMeshTexture(node, "CandyShooter000");
              
            node.RemoveBone("SuperMonkeyRig:Dart");
            }
    }
     public class CandyShooter400 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.MortarMonkey, 0, 0, 0);

         public override void ModifyDisplayNode(UnityDisplayNode node) {
            this.SetMeshTexture(node, "CandyShooter400");
            
           
            }
    }
     public class CandyShooter500 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.MortarMonkey, 0, 4, 0);

         public override void ModifyDisplayNode(UnityDisplayNode node) {
            this.SetMeshTexture(node, "CandyShooter400");
            
           
            }
    }
    public class CandyShooter300 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.BoomerangMonkey, 0, 0, 0);

         public override void ModifyDisplayNode(UnityDisplayNode node) {
             node.RemoveBone("SuperMonkeyRig:Dart");
            this.SetMeshTexture(node, "CandyShooter000");
            
           
            }
    }
   /* public class CandyShooter004 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.BoomerangMonkey, 5, 0, 0);

         public override void ModifyDisplayNode(UnityDisplayNode node) {
            SetMeshTexture(node, "CandyShooterCape",1);
            SetMeshTexture(node, "CandyShooterBaseDisplay",2);
            
            
            node.PrintInfo();
           // node.RemoveBone("BoomerangMoarCape");
            node.RemoveBone("SuperMonkeyRig:Dart");
           
            }
    }
    public class CandyShooter005 : ModDisplay
    {
        public override string BaseDisplay => this.GetDisplay(TowerType.BoomerangMonkey, 5, 0, 0);

         public override void ModifyDisplayNode(UnityDisplayNode node) {
             node.SaveMeshTexture();
            this.SetMeshTexture(node, "CandyShooter500");
            node.RemoveBone("SuperMonkeyRig:Dart");
           
            }
    }*/
    
   

   
  

    public class CandyShooter : ModTower
    {



        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override string Icon => base.Icon;
        

        public override int Cost => 395;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Throws Sharp Peppermints at the bloons";

        
        
    

       //public override ParagonMode ParagonMode => ParagonMode.Base000;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
           towerModel.ApplyDisplay<CandyShooter000>();
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<PeppermintDisplayRed>(); 
                     projectile.GetDamageModel().damage =1;
            var candy = towerModel.GetWeapon();
              foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce = 4 + towerModel.tier;
                 towerModel.range += 12;
            attackModel.range += 12;
            }
              projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.2f;
            
                
             
            
        }
        
       
        
    }
}
namespace CandyShooter.Upgrades.TopPath
{
    public class PointyCandy : ModUpgrade<CandyShooter>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 400;

        public override string DisplayName => "Hard Candy";
        public override string Description => "Candy deals more damage";
        
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                
               
            }
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=1;
                
                            
        }

    }
     public class SharpCandy : ModUpgrade<CandyShooter>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 325;

        public override string DisplayName => "Sharp Candy";
        public override string Description => "Candy pierces through more bloons";
        public override string Icon => "SharpCandy";


        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                
               
            }
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                projectile.pierce +=1;
                
                            
        }

    }
    public class CandyGlove : ModUpgrade<CandyShooter>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1600;

        public override string DisplayName => "Candy Glove";
        public override string Description => "Shoots Candy from a bionic glove";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=3;
                towerModel.range += 15;
            attackModel.range += 15;
               towerModel.ApplyDisplay<CandyShooter300>();
            }
                
                
                            
        }

    }
     public class CandyMortar : ModUpgrade<CandyShooter>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 9000;
       
        public override string DisplayName => "Candy Mortar";
        public override string Description => "Shoots cotton candy from a high power mortar";
         

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=25;
                towerModel.range += 15;
            attackModel.range += 15;
               towerModel.ApplyDisplay<CandyShooter400>();
               
                
                
                if (towerModel.tier == 4)
                { 
                    towerModel.GetWeapon().emission = new InstantDamageEmissionModel("InstantDamageEmissionModel_", null);
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                 attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 15.0f;
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 85.0f;
                    // attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.radius = 1.0f;
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
                   weaponModel.projectile.pierce = 1;

                    projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.01f;
                    projectile.ApplyDisplay<PeppermintDisplayInvisible>(); 
               }
            }
                
                
                            
        }

    }
    public class CandyStorm : ModUpgrade<CandyShooter>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 45500;

        public override string DisplayName => "Candy Storm";
        public override string Description => "Rains different candy from above";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                projectile.GetDamageModel().damage +=55;
                towerModel.range += 15;
                weaponModel.rate *= 0.21f;
            attackModel.range += 15;
               towerModel.ApplyDisplay<CandyShooter500>();
               
               
                
                
                if (towerModel.tier == 5)
                { 
                    towerModel.GetWeapon().emission = new InstantDamageEmissionModel("InstantDamageEmissionModel_", null);
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                 attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 15.0f;
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 85.0f;
                    attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.radius *= 1.4f;
                weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                   weaponModel.projectile.pierce = 1;
                  
                    projectile.ApplyDisplay<PeppermintDisplayInvisible>(); 
               }
            }
                
                
                            
        }

    }
}



namespace CandyShooter.Upgrades.MiddlePath
{
      public class FasterFiring : ModUpgrade<CandyShooter>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 375;

        public override string DisplayName => "Faster Firing";
        public override string Description => "Throws the candy faster";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.Rate *= .75f;
            }
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
               
                
                            
        }

    }
     public class LongerRange : ModUpgrade<CandyShooter>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 575;

        public override string DisplayName => "Longer Range";
        public override string Description => "Increases the range of the candy";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                
                weaponModel.Rate *= .95f;
                
               
            }
                var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
            
            towerModel.range += 25;
            attackModel.range += 25;
                
                            
        }

    }
     public class TrippleShot : ModUpgrade<CandyShooter>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 1950;

        public override int Priority => -1;

        public override string DisplayName => "Triple Shot";
        public override string Description => "Throws 3 Candies at the same time";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;

            
        
                towerModel.GetWeapons()[0].emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 17.5f, null, false, false);
              
            


              
                
                            
        }

    }
    public class SugarRush : ModUpgrade<CandyShooter>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 9500;

        public override string DisplayName => "Sugar rush";
        public override string Description => "Ability: Throws candies way faster for a short period of time";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            { weaponModel.rate *= 0.75f;
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                var candyshrapnel = attackModel.weapons[0].projectile.Duplicate();
            projectile.GetDamageModel().damage +=4;
               //towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 55, null, false);
                //attackModel.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("CreateProjectileOnContactModel_", candyshrapnel, new ArcEmissionModel("ArcEmissionModel_", 3, 0.0f, 75.0f, null, false), true, false, false));
                 
                 weaponModel.projectile.pierce -= 3;
                  towerModel.AddBehavior(Game.instance.model.GetTowerFromId("MortarMonkey-040").GetAbility().Duplicate());
                towerModel.GetAbility().name = "Sugar Rush";
                towerModel.GetAbility().GetBehavior<TurboModel>().extraDamage += 0;
                towerModel.GetAbility().GetBehavior<TurboModel>().multiplier *= 1.85f;
                towerModel.GetAbility().GetBehavior<TurboModel>().Lifespan = 6 + towerModel.tier * 3;
                towerModel.GetAbility().Cooldown = 142 - towerModel.tier * 3;
                towerModel.GetAbility().icon = GetSpriteReference(mod, "SugarRush-Icon");
               
            }
               
                
                
                            
        }

    }
    public class Ultrashot : ModUpgrade<CandyShooter>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 75500;

        public override string DisplayName => "Ultrasplit";
        public override string Description => "Throws 5 Candies at once, and will now split into more candy";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                var candyshrapnel = attackModel.weapons[0].projectile.Duplicate();
               
            projectile.GetDamageModel().damage +=4;
                weaponModel.rate *= 0.75f;
               towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 60, null, false, false);
                 attackModel.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("CreateProjectileOnContactModel_", candyshrapnel, new ArcEmissionModel("ArcEmissionModel_", 7, 0.0f, 75.0f, null, false, false), true, false, false));
                if (projectile == candyshrapnel) { projectile.GetDamageModel().damage = 0; }
              projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.3f;
                
                 
               
            }
               
                
                
                            
        }

    }
}
namespace CandyShooter.Upgrades.BottomPath
{
    public class StickyCandy : ModUpgrade<CandyShooter>
    {
      public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 550;

        public override string DisplayName => "Sticky Candy";
        public override string Description => "Candy will stick to bloons, slowing them down";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 
                
          
              
              
          
              
               
            }
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
            if (towerModel.tier < 3) { 
                attackModel.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModifierForTagModel>().Duplicate());
                foreach (var beh in Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehaviors<AddBehaviorToBloonModel>())
                {
                    attackModel.weapons[0].projectile.AddBehavior(beh.Duplicate());
                }}
               projectile.ApplyDisplay<PeppermintDisplayPink>(); 
                
            
           
                
                            
        }   
         public class MagicCandy : ModUpgrade<CandyShooter>
    {
      public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 775;
            public override int Priority => -1;

            public override string DisplayName => "Magical Candy";
        public override string Description => "Candy can strip Lead and Camo properties away from bloons";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 
                
          
              weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
              
          
              
               
            }
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
              attackModel.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());
               // attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
               // attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModifierForTagModel>().Duplicate());
                foreach (var beh in Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehaviors<AddBehaviorToBloonModel>())
                {
                    attackModel.weapons[0].projectile.AddBehavior(beh.Duplicate());
                }
                 towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
               
                if (towerModel.tier < 4) { 
                projectile.ApplyDisplay<PeppermintDisplayPurple>(); 
                
            }
          } 
                
              
    public class WeakeningCandy : ModUpgrade<CandyShooter>
    {
      public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 2450;

        public override string DisplayName => "Weakening Candy";
        public override string Description => "Bloons hit by the candy will be weakened";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 
                
          
              
              
          
              
               
            }
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                attackModel.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
                    if (towerModel.tier ==3) { 
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-203").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-203").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-203").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModifierForTagModel>().Duplicate());
                foreach (var beh in Game.instance.model.GetTowerFromId("GlueGunner-203").GetAttackModel().weapons[0].projectile.GetBehaviors<AddBehaviorToBloonModel>())
                {
                    attackModel.weapons[0].projectile.AddBehavior(beh.Duplicate());
                }
               
                          projectile.ApplyDisplay<PeppermintDisplayPink>();
                    projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("a", "b", 10f, 1, 15, true, false,false));
                }
            
           
               } 
                            
        }                 
        } 
    }
     public class ElementalCandy : ModUpgrade<CandyShooter>
    {
      public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 7550;

        public override string DisplayName => "Elemental Candy";
        public override string Description => "Candies are infused with elemental power";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 
                 towerModel.ApplyDisplay<CandyShooter000>();
          
              
              
          
              
               
            }
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                attackModel.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
                    if (towerModel.tier  == 4) { 
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-302").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-302").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModifierForTagModel>().Duplicate());
                foreach (var beh in Game.instance.model.GetTowerFromId("GlueGunner-302").GetAttackModel().weapons[0].projectile.GetBehaviors<AddBehaviorToBloonModel>())
                {
                    attackModel.weapons[0].projectile.AddBehavior(beh.Duplicate());
                }
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-300").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                 attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 4.0f;
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 25.0f;
                     attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("IceMonkey-320").GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().layers = 10;
                attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().speed = 0.25f;
               attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<TrackTargetModel>().maxSeekAngle = 90f;
                 attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<WindModel>().chance = 0.175f;
                
               projectile.ApplyDisplay<PeppermintDisplayElemental>();
                    projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("a", "b", 10f, 3, 15, true, false,false));
                     }
            
           
               
                            
        }                 
        
    }
     public class MultiversalCandy : ModUpgrade<CandyShooter>
    {
      public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 97500;

        public override string DisplayName => "Multiversal Candy";
        public override string Description => "The bloons will be melted with the power of the Multiverse";
        

        public override void ApplyUpgrade(TowerModel towerModel)
          { 
               foreach (var weaponModel in towerModel.GetWeapons())
            {
                 
                
                       weaponModel.projectile.pierce = 4 + towerModel.tier;
              towerModel.ApplyDisplay<CandyShooter000>();
              
          
              
               
            }
                 var attackModel = towerModel.GetAttackModel();
               var projectile = attackModel.weapons[0].projectile;
                attackModel.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
                    projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.3f;
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-502").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-502").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-502").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModifierForTagModel>().Duplicate());
                foreach (var beh in Game.instance.model.GetTowerFromId("GlueGunner-502").GetAttackModel().weapons[0].projectile.GetBehaviors<AddBehaviorToBloonModel>())
                {
                    attackModel.weapons[0].projectile.AddBehavior(beh.Duplicate());
                }
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                 attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 16.0f;
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 65.0f;
                     attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("IceMonkey-420").GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().layers = 100;
                attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().speed = 0.1f;
               attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<TrackTargetModel>().maxSeekAngle = 90f;
                 attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<WindModel>().chance = 0.75f;
                
               projectile.ApplyDisplay<PeppermintDisplayElemental>();
                    projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("a", "b", 10f, 10, 15, true, false,false));
            projectile.GetBehavior<TravelStraitModel>().Speed = 1350f;
           
                     
            
           
               
                            
        }                 
        
    }
}
  





    



