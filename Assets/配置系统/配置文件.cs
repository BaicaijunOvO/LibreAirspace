using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using ս�׸���.Configuration.Object;

namespace ս�׸���.Configuration {
    namespace Object {
        //The root object in the JSON document.
        [JsonObject]
        public sealed class LibreAirspaceClientConfiguration {
            [JsonProperty(PropertyName = "KeyBind", Required = Required.Always)]
            internal KeyBind _KeyBind;

            [JsonProperty(PropertyName = "NetworkingConfig", Required = Required.Always)]
            internal NetworkingConfig _NetworkingConfig;

            [JsonIgnore]
            public KeyBind KeyBind { get => this._KeyBind; }

            [JsonIgnore]
            public NetworkingConfig NetworkingConfig { get => this._NetworkingConfig; }
        }

        [JsonObject]
        public sealed class KeyBind {

        }

        [JsonObject]
        public sealed class NetworkingConfig {
            [JsonProperty(PropertyName = "RoomListServerIp", Required = Required.Always)]
            internal string _RoomListServerIp;
            [JsonProperty(PropertyName = "RoomListServerTcpPort", Required = Required.Always)]
            internal ushort _RoomListServerTcpPort;
            [JsonProperty(PropertyName = "DefaultMatchServerKcpPort", Required = Required.Always)]
            internal ushort _DefaultMatchServerKcpPort;

            [JsonIgnore]
            internal IPAddress m_RoomLitServerIp_Resolved;

            [JsonIgnore]
            public IPAddress RoomListServerIp {
                get {
                    IPAddress _parsedIpAddress = null;
                    if (m_RoomLitServerIp_Resolved is null) {
                        if (IPAddress.TryParse(_RoomListServerIp, out _parsedIpAddress)) {
                            m_RoomLitServerIp_Resolved = _parsedIpAddress;
                        } else {
                            TGZG.�����ռ�.logerror("�޷����������б������IP��ַ���ع������ػػ���ַ��");
                            m_RoomLitServerIp_Resolved = IPAddress.Loopback;
                        }
                    }
                    return m_RoomLitServerIp_Resolved;
                }
            }
            [JsonIgnore]
            public ushort RoomListServerTcpPort { get => _RoomListServerTcpPort; }
            [JsonIgnore]
            public ushort DefaultMatchServerKcpPort { get => _DefaultMatchServerKcpPort; }
        }
    }

    namespace Handler {

        public static class ClientConfigurationResolver {
            private static LibreAirspaceClientConfiguration CreateDefaultConfiguration() =>
                new LibreAirspaceClientConfiguration() {
                    _KeyBind = new KeyBind(),
                    _NetworkingConfig = new NetworkingConfig() {
                        _RoomListServerIp = "47.97.112.35",
                        _RoomListServerTcpPort = 16313,
                        _DefaultMatchServerKcpPort = 16314
                    },
                };

            /// <summary>
            /// Resolve configuration from configuration file, create and use default configuration if file is not existed
            /// </summary>
            /// <param name="configurationFilePath">Where the configuration file?</param>
            /// <returns>The configuration readed or created</returns>
            private static LibreAirspaceClientConfiguration ResolveCfgFromCfgFileReadOrCreate(string configurationFilePath) {
                if (File.Exists(configurationFilePath)) {
                    LibreAirspaceClientConfiguration _cfg = null;
                    try {
                        _cfg = JsonConvert.DeserializeObject<LibreAirspaceClientConfiguration>(File.ReadAllText(configurationFilePath));
                    } catch (JsonException ex) {
                        TGZG.�����ռ�.logerror($"�޷������ͻ��������ļ����ع���Ĭ�������ļ���{Environment.NewLine}" +
                            $"���޸������ļ���");
                        return CreateDefaultConfiguration();
                    }
                    return _cfg;
                } else {
                    TGZG.�����ռ�.log("û�пͻ��������ļ����Զ�����Ĭ�������ļ���");
                    LibreAirspaceClientConfiguration _cfg = CreateDefaultConfiguration();
                    //�Ƴ����һ����б�ܣ�����·������
                    Directory.CreateDirectory(configurationFilePath.Substring(0, configurationFilePath.LastIndexOf('\\')));
                    File.WriteAllText(configurationFilePath, JsonConvert.SerializeObject(_cfg));
                    return _cfg;
                }
            }

            public static LibreAirspaceClientConfiguration ResolveConfiguration() =>
                ResolveCfgFromCfgFileReadOrCreate(Path.Combine(Application.dataPath, "Config", "LibreAirspaceClientConfiguration.json"));
        }
    }
}
