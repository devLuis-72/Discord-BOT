using Cerberus.Comandos;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace Cerberus
{
    public class Program
    {
        private DiscordClient _client;
        static void Main(string[] args) => new Program().RunAsyncBot().GetAwaiter().GetResult();

        public async Task RunAsyncBot()
        {
            DiscordConfiguration cfg = new DiscordConfiguration
            {
                Token = "",
                TokenType = TokenType.Bot,
                ReconnectIndefinitely = true,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };

            _client = new DiscordClient(cfg);
            _client.Ready += Client_Ready;
            _client.ClientErrored += Client_ClientError;

            string[] prefix = new string[1];
            prefix[0] = "!";

            CommandsNextExtension cnt = _client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = prefix,
                EnableDms = false,
                CaseSensitive = false,
                EnableDefaultHelp = false,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = true

            });
            cnt.CommandExecuted += CntCommandExecuted;
            cnt.RegisterCommands<ComandosBasicos>();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task Client_Ready(DiscordClient sender, ReadyEventArgs e)
        {
            sender.Logger.LogInformation("Cliente está pronto para processador os eventos.");
            return Task.CompletedTask;
        }

        private Task Client_ClientError(DiscordClient sender, ClientErrorEventArgs e)
        {
            sender.Logger.LogError(e.Exception, "ERROR");
            return Task.CompletedTask;
        }

        private Task CntCommandExecuted(CommandsNextExtension sender, CommandExecutionEventArgs e)
        {
            e.Context.Client.Logger.LogInformation($"{e.Context.User.Username} executou com sucesso '{e.Command.QualifiedName}'");
            return Task.CompletedTask;
        }


    }

}
