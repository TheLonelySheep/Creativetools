﻿using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Creativetools.src.Tools.CreativeFly
{
    class MovePlayer : ModPlayer
    {
        public static bool CreativeFly;
        public bool creativeFly;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            creativeFly = CreativeFly;
            CreativeFly = creativeFly;
            if (CreativeFly)
            {
                player.gravity = 0f; //player doesn't fall
                player.controlJump = false; //player can't jump
                player.noFallDmg = true; //player doesn't take fall damage
                player.moveSpeed = 0f; //player can't move
                player.noKnockback = true; //player doesn't take knockback
                player.velocity.Y = -0.00000000001f; //fix confusing bug

                float modifier = 1f;
                if (Main.keyState.IsKeyDown(Keys.LeftShift) | Main.keyState.IsKeyDown(Keys.RightShift))
                {
                    modifier = 2f; //go faster
                }
                if (Main.keyState.IsKeyDown(Keys.LeftControl) | Main.keyState.IsKeyDown(Keys.RightControl))
                {
                    modifier = 0.5f; //go slower
                }
                if (Main.keyState.IsKeyDown(Keys.W))
                {
                    player.position.Y -= 8 * modifier; //move up
                }
                if (Main.keyState.IsKeyDown(Keys.S))
                {
                    player.position.Y += 8 * modifier; //move down 
                }
                if (Main.keyState.IsKeyDown(Keys.A))
                {
                    player.position.X -= 8 * modifier; //move left
                }
                if (Main.keyState.IsKeyDown(Keys.D))
                {
                    player.position.X += 8 * modifier; //move right
                }
            }
        }
    }
}
