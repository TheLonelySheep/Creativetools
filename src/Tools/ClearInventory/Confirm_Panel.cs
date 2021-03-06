﻿using Creativetools.src.UI.Elements;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace Creativetools.src.Tools.ClearInventory
{
    class Confirm_Panel : UIState
    {
        public static bool Visible;
        public override void OnInitialize()
        {
            DragableUIPanel ConfirmPanel = new DragableUIPanel("Are you sure you want to delete all your items?", 550f, 100f);
            ConfirmPanel.SetPadding(0);
            ConfirmPanel.VAlign = ConfirmPanel.HAlign = 0.5f;
            ConfirmPanel.OnCloseBtnClicked += () => Visible = false;
            Append(ConfirmPanel);

            UIPanel YEPbutton = new UIPanel();
            YEPbutton.Width.Set(100, 0);
            YEPbutton.Height.Set(50, 0);
            YEPbutton.HAlign = 0.03f;
            YEPbutton.Top.Set(35, 0);
            YEPbutton.OnClick += YEPClicked;
            ConfirmPanel.Append(YEPbutton);

            UIPanel DelFavbutton = new UIPanel();
            DelFavbutton.Width.Set(300, 0);
            DelFavbutton.Height.Set(50, 0);
            DelFavbutton.HAlign = 0.5f;
            DelFavbutton.Top.Set(35, 0);
            DelFavbutton.OnClick += DelFavClicked;
            ConfirmPanel.Append(DelFavbutton);

            UIPanel NObutton = new UIPanel();
            NObutton.Width.Set(100, 0);
            NObutton.Height.Set(50, 0);
            NObutton.HAlign = 0.97f;
            NObutton.Top.Set(35, 0);
            NObutton.OnClick += NOClicked;
            ConfirmPanel.Append(NObutton);

            YEPbutton.Append(new UIText("Yes") { HAlign = 0.5f, VAlign = 0.5f });
            DelFavbutton.Append(new UIText("Delete all, exept favorited Items") { HAlign = 0.5f, VAlign = 0.5f });
            NObutton.Append(new UIText("NO!") { HAlign = 0.5f, VAlign = 0.5f });
        }
        private void YEPClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            //delete all items in the inventory
            for (int i = 0; i < Main.maxInventory; i++)
            {
                Main.LocalPlayer.inventory[i].TurnToAir();
                Main.PlaySound(SoundID.Grab);
            }
            Visible = false; //close
            Main.PlaySound(SoundID.MenuClose);
        }
        private void DelFavClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            //delete all exept favorited items
            for (int i = 0; i < Main.maxInventory; i++)
            {
                if (!Main.LocalPlayer.inventory[i].favorited)
                {
                    Main.LocalPlayer.inventory[i].TurnToAir();
                    Main.PlaySound(SoundID.Grab);
                }
            }
            Visible = false; //close
            Main.PlaySound(SoundID.MenuClose);
        }
        private void NOClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Visible = false; //close
            Main.PlaySound(SoundID.MenuClose);
        }
    }
}