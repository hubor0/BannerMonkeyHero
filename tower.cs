using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System.Linq;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Stats;
using Il2CppAssets.Scripts.Simulation.Input;
using BTD_Mod_Helper.Api.Components;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Behaviors;
using Il2CppAssets.Scripts.Simulation.Display;
using Il2CppAssets.Scripts.Simulation.SMath;
using BTD_Mod_Helper.Api;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static BTD_Mod_Helper.Api.ModContent;
using BannerMonkey;
using UnityEngine.UIElements;
using subtowers;

[assembly: MelonInfo(typeof(BannerMonkey.BannerMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BannerMonkey
{
    public class balthazar : ModHero
    {
        public override string BaseTower => TowerType.DartMonkey;
        public override string Name => "bbb";
        public override int Cost => 820;
        public override string DisplayName => "Cyrus";
        public override string Title => "Banner Bearer";
        public override string Level1Description => "Gives additional pierce to nearby monkeys, depending on how many other towers are placed. Every 2 towers placed other than Cyrus upgrade the banners buffs. currently max tower stack is 4";
        public override string Description => "A masterful strategist who unites and empowers monkeys, commanding the battlefield with his inspiring banner!";
        public override string Icon => "heroportrait";
        public override string Portrait => "heroportrait";
        public override string Square => "squareicon";
        public override string Button => "Icon";
        public override string NameStyle => TowerType.AdmiralBrickell;
        public override string BackgroundStyle => TowerType.Sauda;
        public override string GlowStyle => TowerType.Rosalia;
        public override int MaxLevel => 20;
        public override float XpRatio => 1.71f;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var timertick = Game.instance.model.GetTowerFromId("MonkeySub-300").GetAttackModel(1).Duplicate();
            timertick.weapons[0].rate = 1f;
            timertick.weapons[0].projectile.maxPierce = 2137f;
            timertick.weapons[0].projectile.radius = 0.00001f;
            towerModel.AddBehavior(timertick);
            
            towerModel.radius = Game.instance.model.GetTower(TowerType.MonkeyVillage).radius;
            towerModel.range = 30;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 65;
            attackModel.weapons[0].Rate = 9.9f;
            attackModel.RemoveBehavior<RotateToTargetModel>();
            towerModel.ApplyDisplay<looks.Displays.basedisplay>();
            TowerFilterModel filtr1 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.NaturesWardTotem });
            var buff = new PierceSupportModel("", true, 1, "dupapierce2", null, true, "", "");
            buff.ApplyBuffIcon<BannerMonkey.gizmomegabuff>();
            buff.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr1 });
            buff.maxStackSize = 1000;
            towerModel.AddBehavior(buff);
        }
    }
    public class Lv2 : ModHeroLevel<balthazar>
    {
        public override string Description => "max Tower stack limit increased from 4 to 6";
        public override int Level => 2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
        }
    }
    public class Lv3 : ModHeroLevel<balthazar>
    {
        public override string Description => "Resurgence Ability: Boosts the Attack Speed, Damage and pierce of all monkeys in range for 2 seconds.";
        public override int Level => 3;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var Ability = Game.instance.model.GetTowerFromId("ObynGreenfoot 3").GetAbility().Duplicate();
            AttackModel[] support = { Game.instance.model.GetTowerFromId("Etienne 10").GetAttackModel(1).Duplicate() };
            support[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            support[0].RemoveBehavior<RotateToTargetModel>();
            support[0].weapons[0].rate = 32;
            support[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<subtowers.boost1>(), 0, true, false, false, true, false));
            Ability.GetBehavior<ActivateAttackModel>().attacks = support;
            Ability.RemoveBehavior<CreateSoundOnAbilityModel>();
            Ability.GetBehavior<ActivateAttackModel>().attacks[0].range = 9999;
            Ability.name = "dupenka";
            Ability.displayName = "dupenkowo";
            Ability.icon = GetSpriteReference("iconab1");
            Ability.AddBehavior(Game.instance.model.GetTowerFromId("MonkeyVillage-040").GetAbilities()[0].GetBehavior<CreateSoundOnAbilityModel>().Duplicate());
            Ability.cooldown = 55;
            towerModel.ApplyDisplay<looks.Displays.level3>();
            towerModel.AddBehavior(Ability);
        }
    }
    public class Lv4 : ModHeroLevel<balthazar>
    {
        public override string Description => "Incrases the banners range.";
        public override int Level => 4;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range = 50;
        }
    }
    public class Lv5 : ModHeroLevel<balthazar>
    {
        public override string Description => "Resurgance ability cooldown decreased for 5 seconds.";
        public override int Level => 5;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
           // towerModel.GetAbility(0).cooldown = -5f;
        }
    }
    public class Lv6 : ModHeroLevel<balthazar>
    {
        public override string Description => "max Tower stack limit increased from 6 to 8";
        public override int Level => 6;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
        }
    }
    public class Lv7 : ModHeroLevel<balthazar>
    {
        public override string Description => "Extending Pole: The Banners pole extends with every tower placed. A taller banner allows to cover more area";
        public override int Level => 7;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<looks.Displays.level7>();
        }
    }
    public class Lv8 : ModHeroLevel<balthazar>
    {
        public override string Description => "the Banner now grants additional attack speed to nearby monkeys aswell";
        public override int Level => 8;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TowerFilterModel filtr5 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.NaturesWardTotem });
            var buff = new RateSupportModel("", 0.8f, true, "duparate2", false, 1, null, "", "");
            //buff.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr5 });
            buff.maxStackSize = 1000;
            buff.ApplyBuffIcon<BannerMonkey.portrait2>();
            towerModel.AddBehavior(buff);

        }
    }
    public class Lv9 : ModHeroLevel<balthazar>
    {
        public override string Description => "max Tower stack limit increased from 8 to 10";
        public override int Level => 9;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
        }
    }
    public class Lv10 : ModHeroLevel<balthazar>
    {
        public override string Description => "Aspect Amplifier Ability: Choose between buffing all Primary, Military or Magic towers nearby.";
        public override int Level => 10;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<looks.Displays.level10>();
            AttackModel[] attack = { Game.instance.model.GetTowerFromId("SniperMonkey").GetBehavior<AttackModel>().Duplicate() };
            var Ability = Game.instance.model.GetTowerFromId("Mermonkey-040").GetAbility().Duplicate();
            Ability.name = "dupka";
            Ability.displayName = "dupenk324a";
            attack[0].weapons[0].projectile.maxPierce = 311320;
            attack[0].weapons[0].fireWithoutTarget = true;
            attack[0].weapons[0].Rate = 199f;
            attack[0].weapons[0].projectile.GetBehavior<AgeModel>().lifespan = 0.00001f;
            attack[0].range = 999999f;
            attack[0].RemoveBehavior<RotateToTargetModel>();
            Ability.GetBehavior<ActivateAttackModel>().attacks = attack;
            Ability.addedViaUpgrade = "BannerMonkey-bbb Level 10";
            Ability.icon = GetSpriteReference("iconab2");
            towerModel.AddBehavior(Ability);
        }
    }
    public class Lv11 : ModHeroLevel<balthazar>
    {
        public override string Description => "the Banner now slows down all Bloons nearby";
        public override int Level => 11;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.AddBehavior(new SlowBloonsZoneModel("SlowZone", 13, "Ice:Regular:ArcticWind", true, new Il2CppReferenceArray<FilterModel>(new FilterModel[] { new FilterInvisibleModel("Camo", true, false) }), 0.8f, 0, true, 5, "", false));
        }
    }
    public class Lv12 : ModHeroLevel<balthazar>
    {
        public override string Description => "the Banner now buffs Damage of nearby monkeys aswell.";
        public override int Level => 12;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TowerFilterModel filtr5 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.NaturesWardTotem });
            var buff = new DamageSupportModel("", true, 1, "dupadmg2", null, false, false, 0f);
            //buff.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr5 });
            buff.maxStackSize = 1000;
            buff.ApplyBuffIcon<BannerMonkey.gdmgbuff>();
            towerModel.AddBehavior(buff);
            var camo = new VisibilitySupportModel("", true, "VisionSupportZone", true, null, "", "");
            camo.ApplyBuffIcon<BannerMonkey.gdmgbuff>();
            towerModel.AddBehavior(camo);

        }
    }
    public class Lv13 : ModHeroLevel<balthazar>
    {
        public override string Description => "max Tower stack limit increased from 10 to 12";
        public override int Level => 13;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
        }
    }
    public class Lv14 : ModHeroLevel<balthazar>
    {
        public override string Description => "Resurgance ability cooldown decreased for another 8 seconds";
        public override int Level => 14;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetAbility(0).cooldown = -8f;
        }
    }
    public class Lv15 : ModHeroLevel<balthazar>
    {
        public override string Description => "Resurgance ability now lasts for 3 seconds longer";
        public override int Level => 15;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAbility(0).GetBehavior<ActivateAttackModel>().attacks[0].weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<subtowers.boost2>();
        }
    }
    public class Lv16 : ModHeroLevel<balthazar>
    {
        public override string Description => "max Tower stack limit increased from 12 to 14";
        public override int Level => 16;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
        }
    }
    public class Lv17 : ModHeroLevel<balthazar>
    {
        public override string Description => "the Banner now regenerates lives each round";
        public override int Level => 17;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var dupa = Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<BonusLivesPerRoundModel>();
            dupa.amount = 10;
            towerModel.AddBehavior(dupa);
        }
    }
    public class Lv18 : ModHeroLevel<balthazar>
    {
        public override string Description => "max Tower stack limit increased from 12 to 16";
        public override int Level => 18;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
        }
    }
    public class Lv19 : ModHeroLevel<balthazar>
    {
        public override string Description => "Resurgance ability now lasts for 7 seconds now";
        public override int Level => 19;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAbility(0).GetBehavior<ActivateAttackModel>().attacks[0].weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<subtowers.boost3>();
        }
    }
    public class Lv20 : ModHeroLevel<balthazar>
    {
        public override string Description => "with Aspect Amplifier you can now choose to buff the attack speed of all Paragon Grade towers, or grant near-hypersonic attack speed to all other monkey categories. ";
        public override int Level => 20;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<looks.Displays.level20>();
            towerModel.GetAbility(1).GetBehavior<ActivateAttackModel>().attacks[0].weapons[0].projectile.maxPierce = 1311320f;
        }
    }
}
