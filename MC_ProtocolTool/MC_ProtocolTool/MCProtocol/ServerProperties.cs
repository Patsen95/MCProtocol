using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;


namespace MCProtocol
{
	public class ServerProperties
	{
		public enum GameMode
		{
			Survival,
			Creative,
			Adventure,
			Spectator
		}

		public enum GameDifficulty
		{
			Peaceful,
			Easy,
			Normal,
			Hard
		}

		public enum WorldMapType
		{
			Default,
			Flat,
			LargeBiomes,
			Amplified,
			Buffet
		}

		// https://minecraft.gamepedia.com/Server.properties

		public int SpawnProtection { get; set; } = 16;
		public int MaxTickTime { get; set; } = 60000;
		public int QueryPort { get; set; } = 25565;
		public string GeneratorSettings { get; set; } = string.Empty;
		public bool ForceGamemode { get; set; } = false;
		public bool AllowNether { get; set; } = true;
		public bool EnforceWhitelist { get; set; } = false;
		public GameMode Gamemode { get; set; } = GameMode.Survival;
		public bool BroadcastConsoleToOps { get; set; } = true;
		public bool EnableQuery { get; set; } = false;
		public int PlayerIdleTimeout { get; set; } = 0;
		public GameDifficulty Difficulty { get; set; } = GameDifficulty.Easy;
		public bool SpawnMonsters { get; set; } = true;
		public bool BroadcastRconToOps { get; set; } = true;
		public int OpPermissionLevel { get; set; } = 4;
		public bool Pvp { get; set; } = true;
		public bool SnooperEnabled { get; set; } = true;
		public WorldMapType LevelType { get; set; } = WorldMapType.Default;
		public bool Hardcore { get; set; } = false;
		public bool EnableCommandBlock { get; set; } = false;
		public int MaxPlayers { get; set; } = 20;
		public int NetworkCompressionThreshold { get; set; } = 256;
		public string ResourcePackSha1 { get; set; } = string.Empty;
		public int MaxWorldSize { get; set; } = 29999984;
		public int FunctionPermissionLevel { get; set; } = 2;
		public int RconPort { get; set; } = 25575;
		public int ServerPort { get; set; } = 25565;
		public string ServerIp { get; set; } = string.Empty;
		public bool SpawnNpcs { get; set; } = true;
		public bool AllowFlight { get; set; } = false;
		public string LevelName { get; set; } = "This is test";
		public int ViewDistance { get; set; } = 10;
		public string ResourcePack { get; set; } = string.Empty;
		public bool SpawnAnimals { get; set; } = true;
		public bool Whitelist { get; set; } = false;
		public string RconPassword { get; set; } = string.Empty;
		public bool GenerateStructures { get; set; } = true;
		public int MaxBuildHeight { get; set; } = 256;
		public bool OnlineMode { get; set; } = true;
		public string LevelSeed { get; set; } = string.Empty;
		public bool UseNativeTransport { get; set; } = true;
		public bool PreventProxyConnections { get; set; } = false;
		public bool EnableRcon { get; set; } = false;
		public string Motd { get; set; } = "A Minecraft Server";

		private Dictionary<int, string> dictGamemode = new Dictionary<int, string>();
		private Dictionary<int, string> dictDifficulty = new Dictionary<int, string>();
		private Dictionary<int, string> dictWorldType = new Dictionary<int, string>();


		internal ServerProperties()
		{
			dictGamemode.Add((int)GameMode.Survival, "survival");
			dictGamemode.Add((int)GameMode.Creative, "creative");
			dictGamemode.Add((int)GameMode.Adventure, "adventure");
			dictGamemode.Add((int)GameMode.Spectator, "spectator");

			dictDifficulty.Add((int)GameDifficulty.Peaceful, "peaceful");
			dictDifficulty.Add((int)GameDifficulty.Easy, "easy");
			dictDifficulty.Add((int)GameDifficulty.Normal, "normal");
			dictDifficulty.Add((int)GameDifficulty.Hard, "hard");

			dictWorldType.Add((int)WorldMapType.Default, "default");		
			dictWorldType.Add((int)WorldMapType.Flat, "flat");		
			dictWorldType.Add((int)WorldMapType.LargeBiomes, "largebiomes");		
			dictWorldType.Add((int)WorldMapType.Amplified, "amplified");
			dictWorldType.Add((int)WorldMapType.Buffet, "buffet");
		}
		

		public void Load(string path)
		{
			if(!File.Exists(path))
				throw new FileNotFoundException();

			List<string> _lines = new List<string>();
			_lines = File.ReadAllLines(path).ToList();

			for(int i = 2; i < _lines.Count; i++)
			{
				if(_lines[i] == string.Empty || _lines[i].StartsWith("#"))
					continue;

				string _param = _lines[i].Substring(0, _lines[i].LastIndexOf('='));
				Func<int, string> GetValue = (idx) =>
					{
						if(_lines[i].Length == 0)
							return null;
						return _lines[i].Substring(_lines[i].IndexOf('=') + 1, _lines[i].Length - _lines[i].IndexOf('=') - 1);
					};

				switch(_param)
				{
					case "spawn-protection":
						SpawnProtection = Convert.ToInt32(GetValue(i));
						break;

					case "max-tick-time":
						MaxTickTime = Convert.ToInt32(GetValue(i));
						break;

					case "query.port":
						QueryPort = Convert.ToInt32(GetValue(i));
						break;

					case "generator-settings":
						GeneratorSettings = GetValue(i);
						break;

					case "force-gamemode":
						ForceGamemode = (GetValue(i) == "true" ? true : false);
						break;

					case "allow-nether":
						AllowNether = (GetValue(i) == "true" ? true : false);
						break;

					case "enforce-whitelist":
						EnforceWhitelist = (GetValue(i) == "true" ? true : false);
						break;

					case "gamemode":
						{
							string _v = GetValue(i);
							if(_v == "survival") Gamemode = GameMode.Survival;
							if(_v == "creative") Gamemode = GameMode.Creative;
							if(_v == "adventure") Gamemode = GameMode.Adventure;
							if(_v == "spectator") Gamemode = GameMode.Spectator;
						}
						break;

					case "broadcast-console-to-ops":
						BroadcastConsoleToOps = (GetValue(i) == "true" ? true : false);
						break;

					case "enable-query":
						EnableQuery = (GetValue(i) == "true" ? true : false);
						break;

					case "player-idle-timeout":
						PlayerIdleTimeout = Convert.ToInt32(GetValue(i));
						break;

					case "difficulty":
						{
							string _v = GetValue(i);
							if(_v == "peaceful") Difficulty = GameDifficulty.Peaceful;
							if(_v == "easy") Difficulty = GameDifficulty.Easy;
							if(_v == "normal") Difficulty = GameDifficulty.Normal;
							if(_v == "hard") Difficulty = GameDifficulty.Hard;
						}
						break;

					case "spawn-monsters":
						SpawnMonsters = (GetValue(i) == "true" ? true : false);
						break;

					case "broadcast-rcon-to-ops":
						BroadcastRconToOps = (GetValue(i) == "true" ? true : false);
						break;

					case "op-permission-level":
						OpPermissionLevel = Convert.ToInt32(GetValue(i));
						break;

					case "pvp":
						Pvp = (GetValue(i) == "true" ? true : false);
						break;

					case "snooper-enabled":
						SnooperEnabled = (GetValue(i) == "true" ? true : false);
						break;

					case "level-type":
						{
							string _v = GetValue(i);
							if(_v == "default") LevelType = WorldMapType.Default;
							if(_v == "flat") LevelType = WorldMapType.Flat;
							if(_v == "largebiomes") LevelType = WorldMapType.LargeBiomes;
							if(_v == "amplified") LevelType = WorldMapType.Amplified;
							if(_v == "buffet") LevelType = WorldMapType.Buffet;
						}
						break;

					case "hardcore":
						Hardcore = (GetValue(i) == "true" ? true : false);
						break;

					case "enable-command-block":
						EnableCommandBlock = (GetValue(i) == "true" ? true : false);
						break;

					case "max-players":
						MaxPlayers = Convert.ToInt32(GetValue(i));
						break;

					case "network-compression-threshold":
						NetworkCompressionThreshold = Convert.ToInt32(GetValue(i));
						break;

					case "resource-pack-sha1":
						ResourcePackSha1 = GetValue(i);
						break;

					case "max-world-size":
						MaxWorldSize = Convert.ToInt32(GetValue(i));
						break;

					case "function-permission-level":
						FunctionPermissionLevel = Convert.ToInt32(GetValue(i));
						break;

					case "rcon.port":
						RconPort = Convert.ToInt32(GetValue(i));
						break;

					case "server-port":
						ServerPort = Convert.ToInt32(GetValue(i));
						break;

					case "server-ip":
						ServerIp = GetValue(i);
						break;

					case "spawn-npcs":
						SpawnNpcs = (GetValue(i) == "true" ? true : false);
						break;

					case "allow-flight":
						AllowFlight = (GetValue(i) == "true" ? true : false);
						break;

					case "level-name":
						LevelName = GetValue(i);
						break;

					case "view-distance":
						ViewDistance = Convert.ToInt32(GetValue(i));
						break;

					case "resource-pack":
						ResourcePack = GetValue(i);
						break;

					case "spawn-animals":
						SpawnAnimals = (GetValue(i) == "true" ? true : false);
						break;

					case "white-list":
						Whitelist = (GetValue(i) == "true" ? true : false);
						break;

					case "rcon.password":
						RconPassword = GetValue(i);
						break;

					case "generate-structures":
						GenerateStructures = (GetValue(i) == "true" ? true : false);
						break;

					case "max-build-height":
						MaxBuildHeight = Convert.ToInt32(GetValue(i));
						break;

					case "online-mode":
						OnlineMode = (GetValue(i) == "true" ? true : false);
						break;

					case "level-seed":
						LevelSeed = GetValue(i);
						break;

					case "use-native-transport":
						UseNativeTransport = (GetValue(i) == "true" ? true : false);
						break;

					case "prevent-proxy-connections":
						PreventProxyConnections = (GetValue(i) == "true" ? true : false);
						break;

					case "enable-rcon":
						EnableRcon = (GetValue(i) == "true" ? true : false);
						break;

					case "motd":
						Motd = GetValue(i);
						break;
				}
			}
		}

		public void Save(string path)
		{
			/* First two lines are header:
			 *
			 * #Minecraft server properties - constant text
			 * #Wed Mar 11 03:39:33 CET 2020 - current DateTime in format: ddd MMM dd HH:mm:ss CET yyyy
			 * 
			 */
			CultureInfo _ci = new CultureInfo("en-US");
			List<string> _params = new List<string>
			{
				"#Minecraft server properties",
				DateTime.Now.ToString("#ddd MMM dd HH:mm:ss CET yyyy", _ci),
				"spawn-protection=" + SpawnProtection.ToString().ToLower(),
				"max-tick-time=" + MaxTickTime.ToString().ToLower(),
				"query.port=" + QueryPort.ToString().ToLower(),
				"generator-settings=" + GeneratorSettings,
				"force-gamemode=" + ForceGamemode.ToString().ToLower(),
				"allow-nether=" + AllowNether.ToString().ToLower(),
				"enforce-whitelist=" + EnforceWhitelist.ToString().ToLower(),
				"gamemode=" + dictGamemode[(int)Gamemode].ToLower(),
				"broadcast-console-to-ops=" + BroadcastConsoleToOps.ToString().ToLower(),
				"enable-query=" + EnableQuery.ToString().ToLower(),
				"player-idle-timeout=" + PlayerIdleTimeout.ToString().ToLower(),
				"difficulty=" + dictDifficulty[(int)Difficulty].ToLower(),
				"spawn-monsters=" + SpawnMonsters.ToString().ToLower(),
				"broadcast-rcon-to-ops=" + BroadcastRconToOps.ToString().ToLower(),
				"op-permission-level=" + OpPermissionLevel.ToString().ToLower(),
				"pvp=" + Pvp.ToString().ToLower(),
				"snooper-enabled=" + SnooperEnabled.ToString().ToLower(),
				"level-type=" + dictWorldType[(int)LevelType].ToLower(),
				"hardcore=" + Hardcore.ToString().ToLower(),
				"enable-command-block=" + EnableCommandBlock.ToString().ToLower(),
				"max-players=" + MaxPlayers.ToString().ToLower(),
				"network-compression-threshold=" + NetworkCompressionThreshold.ToString().ToLower(),
				"resource-pack-sha1=" + ResourcePackSha1,
				"max-world-size=" + MaxWorldSize.ToString().ToLower(),
				"function-permission-level=" + FunctionPermissionLevel.ToString().ToLower(),
				"rcon.port=" + RconPort.ToString().ToLower(),
				"server-port=" + ServerPort.ToString().ToLower(),
				"server-ip=" + ServerIp,
				"spawn-npcs=" + SpawnNpcs.ToString().ToLower(),
				"allow-flight=" + AllowFlight.ToString().ToLower(),
				"level-name=" + LevelName,
				"view-distance=" + ViewDistance.ToString().ToLower(),
				"resource-pack=" + ResourcePack,
				"spawn-animals=" + SpawnAnimals.ToString().ToLower(),
				"white-list=" + Whitelist.ToString().ToLower(),
				"rcon.password=" + RconPassword,
				"generate-structures=" + GenerateStructures.ToString().ToLower(),
				"max-build-height=" + MaxBuildHeight.ToString().ToLower(),
				"online-mode=" + OnlineMode.ToString().ToLower(),
				"level-seed=" + LevelSeed,
				"use-native-transport=" + UseNativeTransport.ToString().ToLower(),
				"prevent-proxy-connections=" + PreventProxyConnections.ToString().ToLower(),
				"enable-rcon=" + EnableRcon.ToString().ToLower(),
				"motd=" + Motd
			};
			File.WriteAllLines(path, _params);
		}
	}
}
