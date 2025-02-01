using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Display;
using BannerMonkey;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Stats;
using Il2CppAssets.Scripts.Simulation.Input;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace subtowers
{
    public class dupson : ModBuffIcon
    {
        protected override int Order => 1;
        public override string Icon => "iconab1";
        public override int MaxStackSize => 100;
    }
    public class dupsonka : ModBuffIcon
    {
        protected override int Order => 1;
        public override string Icon => "iconab2";
        public override int MaxStackSize => 100;
    }

    public class boost1 : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "flag boost";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 65;
            towerModel.AddBehavior( new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 2f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            var buff = new PierceSupportModel("", true, 1, "grafitti", null, false, "", "");
            buff.ApplyBuffIcon<dupson>();
            buff.maxStackSize = 1000;
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijak", false, 1, null, "", "");
            buff2.maxStackSize = 1000;
            var buff3 = new DamageSupportModel("", true, 1, "gramofon", null, false, false, 0f);
            buff3.maxStackSize = 1000;
            towerModel.AddBehavior(buff);
            towerModel.AddBehavior(buff2);
            towerModel.AddBehavior(buff3);
        }

    }
    public class boost2 : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "flag boost2";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 65;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 5f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            var buff = new PierceSupportModel("", true, 1, "grafitti", null, false, "", "");
            buff.ApplyBuffIcon<dupson>();
            buff.maxStackSize = 1000;
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijak", false, 1, null, "", "");
            buff2.maxStackSize = 1000;
            var buff3 = new DamageSupportModel("", true, 1, "gramofon", null, false, false, 0f);
            buff3.maxStackSize = 1000;
            towerModel.AddBehavior(buff);
            towerModel.AddBehavior(buff2);
            towerModel.AddBehavior(buff3);
        }

    }
    public class boost3 : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "flag boost3";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 65;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 7f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            var buff = new PierceSupportModel("", true, 1, "grafitti", null, false, "", "");
            buff.ApplyBuffIcon<dupson>();
            buff.maxStackSize = 1000;
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijak", false, 1, null, "", "");
            buff2.maxStackSize = 1000;
            var buff3 = new DamageSupportModel("", true, 1, "gramofon", null, false, false, 0f);
            buff3.maxStackSize = 1000;
            towerModel.AddBehavior(buff);
            towerModel.AddBehavior(buff2);
            towerModel.AddBehavior(buff3);
        }

    }
    public class boostmilitary : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "AA 1";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 75;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 200f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            TowerFilterModel filtr55 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.SniperMonkey, TowerType.MonkeyAce, TowerType.MortarMonkey, TowerType.HeliPilot, TowerType.DartlingGunner, TowerType.MonkeyBuccaneer, TowerType.MonkeySub });
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijak", false, 1, null, "", "");
            buff2.ApplyBuffIcon<dupsonka>();
            buff2.maxStackSize = 1000;
            buff2.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr55 });
            towerModel.AddBehavior(buff2);
        }

    }
    public class boostprimary : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "AA 2";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 75;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 200f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            TowerFilterModel filtr5 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.DartMonkey, TowerType.TackShooter, TowerType.BoomerangMonkey, TowerType.BombShooter, TowerType.GlueGunner, TowerType.IceMonkey });
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijakprim", false, 1, null, "", "");
            buff2.ApplyBuffIcon<dupsonka>();
            buff2.maxStackSize = 1000;
            buff2.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr5 });
            towerModel.AddBehavior(buff2);
        }

    }
    public class boostmagic : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "AA 3";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 75;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 200f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            TowerFilterModel filtr54 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.WizardMonkey, TowerType.Druid, TowerType.Alchemist, TowerType.SuperMonkey, TowerType.NinjaMonkey, TowerType.Mermonkey });
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijakmagic", false, 1, null, "", "");
            buff2.ApplyBuffIcon<dupsonka>();
            buff2.maxStackSize = 1000;
            buff2.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr54 });
            towerModel.AddBehavior(buff2);
        }

    }

    public class boosttowers : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "AA 13";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 6665;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 200f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            var buff2 = new RateSupportModel("", 0.3f, true, "podbijak", false, 1, null, "", "");
            buff2.ApplyBuffIcon<dupsonka>();
            buff2.maxStackSize = 1000;
            towerModel.AddBehavior(buff2);
        }

    }
    public class boostparagons : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "AA 17";
        public override bool DontAddToShop => true;
        public override string Description => "A";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 6665;
            towerModel.AddBehavior(new SelectParentOnSelectedModel("dupka"));
            towerModel.isSubTower = true;
            towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha).radius;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 200f, 9, false, false));
            towerModel.display = new PrefabReference() { guidRef = "" };
            towerModel.RemoveBehaviors<AttackModel>();
            var buff2 = new RateSupportModel("", 0.7f, true, "podbijak", false, 1, null, "", "");
            buff2.onlyAffectParagon = true;
            buff2.ApplyBuffIcon<dupsonka>();
            buff2.maxStackSize = 1000;
            towerModel.AddBehavior(buff2);
        }

    }
}
