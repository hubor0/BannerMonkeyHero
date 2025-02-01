using MelonLoader;
using BTD_Mod_Helper;
using BannerMonkey;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Linq;
using System.Threading.Tasks;
using HarmonyLib;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2Cpp;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Display.Animation;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System;
using Il2CppAssets.Scripts.Data.Behaviors.Towers;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Unity.UI_New;
using JetBrains.Annotations;
using ui;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models.Artifacts.Behaviors;

[assembly: MelonInfo(typeof(BannerMonkey.BannerMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BannerMonkey;


public class BannerMonkey : BloonsTD6Mod
{
    public override void OnTowerCreated(Il2CppAssets.Scripts.Simulation.Towers.Tower tower, Entity target, Model modelToUse)
    {
        if (tower.towerModel.name.Contains("bbb"))
        {
            ui.flag.CreatePanel();
        }
    }
    public override void OnTowerSold(Il2CppAssets.Scripts.Simulation.Towers.Tower tower, float amount)
    {
        if (flag.instance != null)
        {
            flag.instance?.Close();
        }
    }


    public override void OnApplicationStart()
    {
        ModHelper.Msg<BannerMonkey>("BannerMonkey loaded!");
    }
    public class gizmomegabuff : ModBuffIcon
    {
        protected override int Order => 1;
        public override string Icon => "iconpierce";
        public override int MaxStackSize => 100;
    }
    public class gdmgbuff : ModBuffIcon
    {
        protected override int Order => 3;
        public override string Icon => "icondamage";
        public override int MaxStackSize => 100;
    }
    public class portrait2 : ModBuffIcon
    {
        protected override int Order => 2;
        public override string Icon => "iconrate";
        public override int MaxStackSize => 100;
    }
    public override void OnNewGameModel(GameModel gameModel) => gameModel.towers.AsParallel().ForAll(tower =>
{
    TowerFilterModel filtr = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { balthazar.TowerID<balthazar>() });
    var buff = new RangeSupportModel("", true, 0, 0, "duparange3", null, false, "", "");
    buff.ApplyBuffIcon<gizmomegabuff>();
    buff.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr });
    tower.AddBehavior(buff);
});
    public override void OnWeaponFire(Weapon weapon)
    {
        List<Il2CppAssets.Scripts.Simulation.Towers.Tower> towers = InGame.instance.GetTowers();
        if (weapon.weaponModel.projectile.maxPierce == 2137f)
        {
            var Towers = InGame.instance.GetAllTowerToSim("").FindAll(sim => sim.tower.towerModel.name.Contains("bbb"));
            foreach (var Tower in Towers)
            {
                var towerModel = Tower.tower.rootModel.Duplicate().Cast<TowerModel>();
                if (Tower.tower.IsMutatedBy("duparange3") && towerModel.baseId.Contains("bbb"))
                {
                    if (towers.Count >= 3)
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.filters = null;

                    }
                    if (towers.Count >= 5)
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 2f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px2>();

                    }
                    if (towers.Count >= 7 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 2"))
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 3f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px3>();
                    }
                    if (towers.Count >= 9 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 6"))
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 4f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px4>();
                    }
                    if (towers.Count >= 11 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 9"))
                    {
                        var bombaclat2 = towerModel.GetBehavior<RateSupportModel>();
                        bombaclat2.multiplier = 0.7f;
                        bombaclat2.ApplyBuffIcon<looks.Displays.rx2>();

                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 5f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px5>();

                    }
                    if (towers.Count >= 13 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 13"))
                    {
                        var bombaclat3 = towerModel.GetBehavior<DamageSupportModel>();
                        bombaclat3.increase = 2f;
                        bombaclat3.ApplyBuffIcon<looks.Displays.dx2>();

                        var bombaclat2 = towerModel.GetBehavior<RateSupportModel>();
                        bombaclat2.multiplier = 0.6f;
                        bombaclat2.ApplyBuffIcon<looks.Displays.rx3>();
                    }
                    if (towers.Count >= 15 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 16"))
                    {
                        var bombaclat3 = towerModel.GetBehavior<DamageSupportModel>();
                        bombaclat3.increase = 3f;
                        bombaclat3.ApplyBuffIcon<looks.Displays.dx3>();

                        var bombaclat2 = towerModel.GetBehavior<RateSupportModel>();
                        bombaclat2.multiplier = 0.5f;
                        bombaclat2.ApplyBuffIcon<looks.Displays.rx4>();
                    }
                    if (towers.Count >= 17 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 18"))
                    {
                        var bombaclat3 = towerModel.GetBehavior<DamageSupportModel>();
                        bombaclat3.increase = 4f;
                        bombaclat3.ApplyBuffIcon<looks.Displays.dx4>();

                        var zycie = towerModel.GetBehavior<BonusLivesPerRoundModel>();
                        zycie.amount = 25;
                    }


                    //########################################################################################//

                    if (towers.Count < 3)
                    {
                        TowerFilterModel filtr13 = new FilterInBaseTowerIdModel("BaseTowerFilter", new string[] { TowerType.NaturesWardTotem });
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filtr13 });
                        bombaclat.ApplyBuffIcon<gizmomegabuff>();
                    }
                    if (towers.Count < 5 && towers.Count > 3)
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 1f;
                        bombaclat.ApplyBuffIcon<gizmomegabuff>();
                    }
                    if (towers.Count < 7 && towers.Count > 5 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 2"))
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 2f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px2>();
                    }
                    if (towers.Count < 9 && towers.Count > 7 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 6"))
                    {
                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 3f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px3>();
                    }
                    if (towers.Count < 11 && towers.Count > 9 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 9"))
                    {
                        var bombaclat2 = towerModel.GetBehavior<RateSupportModel>();
                        bombaclat2.multiplier = 0.8f;
                        bombaclat2.ApplyBuffIcon<portrait2>();

                        var bombaclat = towerModel.GetBehavior<PierceSupportModel>();
                        bombaclat.pierce = 4f;
                        bombaclat.ApplyBuffIcon<looks.Displays.px4>();
                    }
                    if (towers.Count < 13 && towers.Count > 11 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 13"))
                    {
                        var bombaclat3 = towerModel.GetBehavior<DamageSupportModel>();
                        bombaclat3.increase = 1f;
                        var bombaclat32 = towerModel.GetBehavior<VisibilitySupportModel>();
                        bombaclat32.ApplyBuffIcon<gdmgbuff>();

                        var bombaclat2 = towerModel.GetBehavior<RateSupportModel>();
                        bombaclat2.multiplier = 0.7f;
                        bombaclat2.ApplyBuffIcon<looks.Displays.rx2>();
                    }
                    if (towers.Count < 15 && towers.Count > 13 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 16"))
                    {
                        var bombaclat3 = towerModel.GetBehavior<DamageSupportModel>();
                        bombaclat3.increase = 2f;
                        var bombaclat32 = towerModel.GetBehavior<VisibilitySupportModel>();
                        bombaclat32.ApplyBuffIcon<looks.Displays.dx2>();

                        var bombaclat2 = towerModel.GetBehavior<RateSupportModel>();
                        bombaclat2.multiplier = 0.6f;
                        bombaclat2.ApplyBuffIcon<looks.Displays.rx3>();
                    }
                    if (towers.Count < 17 && towers.Count > 15 && towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 18"))
                    {
                        var bombaclat3 = towerModel.GetBehavior<DamageSupportModel>();
                        var bombaclat32 = towerModel.GetBehavior<VisibilitySupportModel>();
                        bombaclat3.increase = 3f;
                        bombaclat32.ApplyBuffIcon<looks.Displays.dx3>();

                        var zycie = towerModel.GetBehavior<BonusLivesPerRoundModel>();
                        zycie.amount = 10;
                    }

                    //########################################################################################//

                    if (towerModel.appliedUpgrades.Contains("BannerMonkey-bbb Level 7"))
                    {
                        if (towers.Count >= 7)
                        {
                            towerModel.range = 50;
                        }
                        if (towers.Count >= 9)
                        {
                            towerModel.range = 60;
                        }
                        if (towers.Count >= 11)
                        {
                            towerModel.range = 70;
                        }
                        if (towers.Count >= 13)
                        {
                            towerModel.range = 80;
                        }
                        if (towers.Count >= 15)
                        {
                            towerModel.range = 90;
                        }
                    }



                }
                Tower.tower.UpdateRootModel(towerModel);
                

            }

        }
        if (weapon.weaponModel.projectile.maxPierce == 311320f)
        {
                ui.flag2.CreatePanel2();
        }
        if (weapon.weaponModel.projectile.maxPierce == 1311320f)
        {
            ui.flag2.CreatePanel3();
        }
    }
    public override void OnUpdate()
    {
        if (InGame.instance != null)
        {
            if (flag.instance != null)
            {
                List<Il2CppAssets.Scripts.Simulation.Towers.Tower> towers = InGame.instance.GetTowers();
                if (ui.flag.instance != null)
                {
                    ui.flag.TowersText.SetText("Towers" + "=" + towers.Count);
                }
            }
        }
    }
}