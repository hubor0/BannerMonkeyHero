using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity;
using System.Collections;
using UnityEngine.UI;
using BTD_Mod_Helper;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using System;
using Il2CppAssets.Scripts;
using BannerMonkey;
using Il2CppAssets.Scripts.Models.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem.Reflection;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Events;
using System.Threading;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppTMPro;
using Il2CppAssets.Scripts.Models;
using Object = UnityEngine.Object;
using Il2CppSystem;
using Boolean = Il2CppSystem.Boolean;
using Action = System.Action;
using Math = System.Math;
using subtowers;

namespace ui
{
    [RegisterTypeInIl2Cpp(false)]
    public class flag : MonoBehaviour
    {
        public static ModHelperText TowersText = null!;
        public static flag? instance = null;
        public void Close()
        {
            if (gameObject)
            {
                gameObject.Destroy();
            }
        }
        public static void CreatePanel()
        {
            if (InGame.instance != null)
            {
                RectTransform rect = InGame.instance.uiRect;
                var panel = rect.gameObject.AddModHelperPanel(new("Panel_", 0, 0, 000, 000), VanillaSprites.BrownInsertPanel);
                instance = panel.AddComponent<flag>();
                List<Il2CppAssets.Scripts.Simulation.Towers.Tower> towers = InGame.instance.GetTowers();

                var text = panel.AddText(new("Title", 1330, -1150, 400, 300), $"test1", 70);
                TowersText = text;
                text.SetText("TOWERS" + "=" + towers.Count);
                panel.AddImage(new Info("towercount", 1050, -1150, 170, 170), ModContent.GetTextureGUID<BannerMonkey.BannerMonkey>("icontowercount"));

            }
        }
    }
    public class flag2 : MonoBehaviour
    {
        public static ModHelperText TowersText = null!;
        public static flag? instance = null;
        public void Close()
        {
            if (gameObject)
            {
                gameObject.Destroy();
            }
        }
        public static void CreatePanel2()
        {
            if (InGame.instance != null)
            {
                RectTransform rect = InGame.instance.uiRect;
                var panel = rect.gameObject.AddModHelperPanel(new Info("switchpanel", -200, 0, 1000, 700), VanillaSprites.BrownInsertPanel);
                instance = panel.AddComponent<flag>();
                var button = panel.AddButton(new("Button_", -380, 0, 300, 300), VanillaSprites.GreenBtnSquare, new Action(() =>
                {
                    instance?.Close();
                    var Towers = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-bbb"));
                    var Gizmos1 = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-AA"));
                    foreach (var Tower in Towers)
                    {
                        foreach (var behavior in Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetAttackModels().ToArray())
                        {
                            if (behavior.name.Contains("Spawner"))
                            {

                                var towerModel = Tower.tower.rootModel.Duplicate().Cast<TowerModel>();
                                var spawner2 = behavior.Duplicate();
                                towerModel.RemoveBehavior<OverrideCamoDetectionModel>();
                                var onebefore = towerModel.GetAttackModel("blackholespawn");
                                var twobefore = towerModel.GetAttackModel("rocketspawn");
                                var threebefore = towerModel.GetAttackModel("beaconspawn");
                                towerModel.RemoveBehavior(onebefore);
                                towerModel.RemoveBehavior(twobefore);
                                towerModel.RemoveBehavior(threebefore);
                                spawner2.RemoveBehavior<RotateToTargetModel>();
                                spawner2.weapons[0].rate = 135;
                                spawner2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                                spawner2.name = "rocketspawn";
                                spawner2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Gizmoblackholeplace2", ModContent.GetTowerModel<boostprimary>().Duplicate(), 0f, true, true, false, true, false));
                                towerModel.AddBehavior(spawner2);
                                foreach (var Gizmo in Gizmos1)
                                {
                                    Gizmo.tower.SellTower();
                                }

                                Tower.tower.UpdateRootModel(towerModel);
                            }
                        }
                    }

                }));
                var button2 = panel.AddButton(new("Button_", 0, 0, 300, 300), VanillaSprites.GreenBtnSquare, new Action(() =>
                {
                    instance?.Close();
                    var Towers = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-bbb"));
                    var Gizmos1 = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-AA"));
                    foreach (var Tower in Towers)
                    {
                        foreach (var behavior in Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetAttackModels().ToArray())
                        {
                            if (behavior.name.Contains("Spawner"))
                            {

                                var towerModel = Tower.tower.rootModel.Duplicate().Cast<TowerModel>();
                                var spawner2 = behavior.Duplicate();
                                towerModel.RemoveBehavior<OverrideCamoDetectionModel>();
                                var onebefore = towerModel.GetAttackModel("blackholespawn");
                                var twobefore = towerModel.GetAttackModel("rocketspawn");
                                var threebefore = towerModel.GetAttackModel("beaconspawn");
                                towerModel.RemoveBehavior(onebefore);
                                towerModel.RemoveBehavior(twobefore);
                                towerModel.RemoveBehavior(threebefore);
                                spawner2.RemoveBehavior<RotateToTargetModel>();
                                spawner2.weapons[0].rate = 135;
                                spawner2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                                spawner2.name = "blackholespawn";
                                spawner2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Gizmoblackholeplace", ModContent.GetTowerModel<boostmilitary>().Duplicate(), 0f, true, true, false, true, false));
                                towerModel.AddBehavior(spawner2);
                                foreach (var Gizmo in Gizmos1)
                                {
                                    Gizmo.tower.SellTower();
                                }

                                Tower.tower.UpdateRootModel(towerModel);
                            }
                        }
                    }
                }));
                var button3 = panel.AddButton(new("Button_", 380, 0, 300, 300), VanillaSprites.GreenBtnSquare, new Action(() =>
                {
                    instance?.Close();
                    var Towers = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-bbb"));
                    var Gizmos1 = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-AA"));
                    foreach (var Tower in Towers)
                    {
                        foreach (var behavior in Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetAttackModels().ToArray())
                        {
                            if (behavior.name.Contains("Spawner"))
                            {

                                var towerModel = Tower.tower.rootModel.Duplicate().Cast<TowerModel>();
                                var spawner2 = behavior.Duplicate();
                                towerModel.RemoveBehavior<OverrideCamoDetectionModel>();
                                var onebefore = towerModel.GetAttackModel("blackholespawn");
                                var twobefore = towerModel.GetAttackModel("rocketspawn");
                                var threebefore = towerModel.GetAttackModel("beaconspawn");
                                towerModel.RemoveBehavior(onebefore);
                                towerModel.RemoveBehavior(twobefore);
                                towerModel.RemoveBehavior(threebefore);
                                spawner2.RemoveBehavior<RotateToTargetModel>();
                                spawner2.weapons[0].rate = 135;
                                spawner2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                                spawner2.name = "beaconspawn";
                                spawner2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Gizmoblackholeplace87", ModContent.GetTowerModel<boostmagic>().Duplicate(), 0f, true, true, false, true, false));
                                towerModel.AddBehavior(spawner2);
                                foreach (var Gizmo in Gizmos1)
                                {
                                    Gizmo.tower.SellTower();
                                }

                                Tower.tower.UpdateRootModel(towerModel);
                            }
                        }
                    }
                }));
                button.AddImage(new Info("rocketsign", 0, 0, 280, 280), ModContent.GetTextureGUID<BannerMonkey.BannerMonkey>("primary"));
                button2.AddImage(new Info("blackholesign", 0, 0, 280, 280), ModContent.GetTextureGUID<BannerMonkey.BannerMonkey>("military"));
                button3.AddImage(new Info("Camodetsign", 0, 0, 280, 280), ModContent.GetTextureGUID<BannerMonkey.BannerMonkey>("magic"));
            }
        }
        public static void CreatePanel3()
        {
            if (InGame.instance != null)
            {
                RectTransform rect = InGame.instance.uiRect;
                var panel = rect.gameObject.AddModHelperPanel(new Info("switchpanel", -200, 0, 1200, 800), VanillaSprites.BrownInsertPanel);
                instance = panel.AddComponent<flag>();
                var button = panel.AddButton(new("Button_", -350, 0, 370, 370), VanillaSprites.GreenBtnSquare, new Action(() =>
                {
                    instance?.Close();
                    var Towers = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-bbb"));
                    var Gizmos1 = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-AA"));
                    foreach (var Tower in Towers)
                    {
                        foreach (var behavior in Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetAttackModels().ToArray())
                        {
                            if (behavior.name.Contains("Spawner"))
                            {

                                var towerModel = Tower.tower.rootModel.Duplicate().Cast<TowerModel>();
                                var spawner2 = behavior.Duplicate();
                                towerModel.RemoveBehavior<OverrideCamoDetectionModel>();
                                var onebefore = towerModel.GetAttackModel("blackholespawn");
                                var twobefore = towerModel.GetAttackModel("rocketspawn");
                                towerModel.RemoveBehavior(onebefore);
                                towerModel.RemoveBehavior(twobefore);
                                spawner2.RemoveBehavior<RotateToTargetModel>();
                                spawner2.weapons[0].rate = 135;
                                spawner2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                                spawner2.name = "blackholespawn564";
                                spawner2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Gizmoblackholeplace", ModContent.GetTowerModel<boosttowers>().Duplicate(), 0f, true, true, false, true, false));
                                towerModel.AddBehavior(spawner2);
                                foreach (var Gizmo in Gizmos1)
                                {
                                    Gizmo.tower.SellTower();
                                }

                                Tower.tower.UpdateRootModel(towerModel);
                            }
                        }
                    }
                }));
                var button2 = panel.AddButton(new("Button_", 350, 0, 370, 370), VanillaSprites.GreenBtnSquare, new Action(() =>
                {
                    instance?.Close();
                    var Towers = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-bbb"));
                    var Gizmos1 = InGame.instance.GetAllTowerToSim().FindAll(sim => sim.tower.towerModel.name.Contains("BannerMonkey-AA"));
                    foreach (var Tower in Towers)
                    {
                        foreach (var behavior in Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetAttackModels().ToArray())
                        {
                            if (behavior.name.Contains("Spawner"))
                            {

                                var towerModel = Tower.tower.rootModel.Duplicate().Cast<TowerModel>();
                                var spawner2 = behavior.Duplicate();
                                towerModel.RemoveBehavior<OverrideCamoDetectionModel>();
                                var onebefore = towerModel.GetAttackModel("blackholespawn");
                                var twobefore = towerModel.GetAttackModel("rocketspawn");
                                towerModel.RemoveBehavior(onebefore);
                                towerModel.RemoveBehavior(twobefore);
                                spawner2.RemoveBehavior<RotateToTargetModel>();
                                spawner2.weapons[0].rate = 135;
                                spawner2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                                spawner2.name = "blackholespawn54";
                                spawner2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Gizmoblackholeplace", ModContent.GetTowerModel<boostparagons>().Duplicate(), 0f, true, true, false, true, false));
                                towerModel.AddBehavior(spawner2);
                                foreach (var Gizmo in Gizmos1)
                                {
                                    Gizmo.tower.SellTower();
                                }

                                Tower.tower.UpdateRootModel(towerModel);
                            }
                        }
                    }
                }));
                button.AddImage(new Info("rocketsign", 0, 0, 280, 280), ModContent.GetTextureGUID<BannerMonkey.BannerMonkey>("primary"));
                button2.AddImage(new Info("blackholesign", 0, 0, 280, 280), ModContent.GetTextureGUID<BannerMonkey.BannerMonkey>("paragon"));
            }
        }
    }
}