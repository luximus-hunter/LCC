using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace LCC.Cards
{
    class Sniper : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats,
            CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{LCC.ModInitials}][Card] {GetTitle()} has been setup.");
            
            gun.reloadTimeAdd = 0.125f;
            gun.projectileSpeed = 11f;
            gun.ammo = -1000;

            cardInfo.allowMultiple = false;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data,
            HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{LCC.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data,
            HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{LCC.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Sniper";
        }

        protected override string GetDescription()
        {
            return "Deadly accurate";
        }

        protected override GameObject GetCardArt()
        {
            return null!;
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[]
            {
                new CardInfoStat
                {
                    positive = true,
                    stat = "Bullet Speed",
                    amount = "+1000%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat
                {
                    positive = false,
                    stat = "Reload Speed",
                    amount = "-400%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat
                {
                    positive = false,
                    amount = "1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Bullet"
                },
            };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }

        public override string GetModName()
        {
            return LCC.ModInitials;
        }
    }
}