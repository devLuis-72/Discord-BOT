using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Comandos
{
    public class ComandosBasicos : BaseCommandModule
    {

        [Command("avatar")]
        [Description("Exibe o avatar de alguém.")]
        [Aliases("av")]

        public async Task Avatar(CommandContext ctx, [RemainingText] DiscordUser user = null)
        {
            await ctx.TriggerTypingAsync();
            if (user == null) user = ctx.User;
            await ctx.RespondAsync(user.AvatarUrl);
        }


        [Command("ping")]
        [Description("Example ping command")]
        [Aliases("pong")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var emoji = DiscordEmoji.FromName(ctx.Client, ":ping_pong:");

            await ctx.RespondAsync($"{emoji} Pong! Ping: {ctx.Client.Ping}ms");
        }

        [Command("alef")]
        [Description("Example ping command")]
        [Aliases("aleph")]
        public async Task Alef(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var emoji = DiscordEmoji.FromName(ctx.Client, ":rainbow:");

            await ctx.RespondAsync($"{emoji} FUCK ALEFÍ.");
        }

    }
}
