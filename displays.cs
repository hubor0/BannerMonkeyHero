using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using static Il2CppAssets.Scripts.Simulation.SMath.Vector3;
using MelonLoader.Utils;
using BannerMonkey;
using BTD_Mod_Helper.Extensions;


namespace looks
{
  public class Displays
  {

        public class basedisplay : ModCustomDisplay
        {
            public override string AssetBundleName => "banner";
            public override string PrefabName => "bb1";

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 75;

 
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(73 / 255f, 36 / 255f, 14 / 255f));
                }
            }
        }
        public class level3 : ModCustomDisplay
        {
            public override string AssetBundleName => "banner";
            public override string PrefabName => "bb3";

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 75;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(73 / 255f, 36 / 255f, 14 / 255f));
                }
            }
        }
        public class level7 : ModCustomDisplay
        {
            public override string AssetBundleName => "banner";
            public override string PrefabName => "bb7";

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 75;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(73 / 255f, 36 / 255f, 14 / 255f));
                }
            }
        }
        public class level10 : ModCustomDisplay
        {
            public override string AssetBundleName => "banner";
            public override string PrefabName => "bb10";

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 75;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(73 / 255f, 36 / 255f, 14 / 255f));
                }
            }
        }
        public class level20 : ModCustomDisplay
        {
            public override string AssetBundleName => "banner";
            public override string PrefabName => "bb20";

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 75;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(73 / 255f, 36 / 255f, 14 / 255f));
                }
            }
        }

        public class px2 : ModBuffIcon
        {
            protected override int Order => 1;
            public override string Icon => "piercex2";
            public override int MaxStackSize => 100;
        }
        public class dx2 : ModBuffIcon
        {
            protected override int Order => 3;
            public override string Icon => "dmgx2";
            public override int MaxStackSize => 100;
        }
        public class rx2 : ModBuffIcon
        {
            protected override int Order => 2;
            public override string Icon => "ratex2";
            public override int MaxStackSize => 100;
        }

        public class px3 : ModBuffIcon
        {
            protected override int Order => 1;
            public override string Icon => "piercex3";
            public override int MaxStackSize => 100;
        }
        public class dx3 : ModBuffIcon
        {
            protected override int Order => 3;
            public override string Icon => "dmgx3";
            public override int MaxStackSize => 100;
        }
        public class rx3 : ModBuffIcon
        {
            protected override int Order => 2;
            public override string Icon => "ratex3";
            public override int MaxStackSize => 100;
        }

        public class px4 : ModBuffIcon
        {
            protected override int Order => 1;
            public override string Icon => "piercex4";
            public override int MaxStackSize => 100;
        }
        public class dx4 : ModBuffIcon
        {
            protected override int Order => 3;
            public override string Icon => "dmgx4";
            public override int MaxStackSize => 100;
        }
        public class rx4 : ModBuffIcon
        {
            protected override int Order => 2;
            public override string Icon => "ratex4";
            public override int MaxStackSize => 100;
        }

        public class px5 : ModBuffIcon
        {
            protected override int Order => 1;
            public override string Icon => "piercex5";
            public override int MaxStackSize => 100;
        }
    }
}

