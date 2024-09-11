using Newtonsoft.Json;

class Evapi {
    public string ApiKey { get; }
    private int n { get; set; } = 0;
    public Evapi(string apiKey) {
        ApiKey = apiKey;
    }

    private async Task<dynamic> GetRequest(string endpoint) {
        using (HttpClient client = new HttpClient()) {
            try {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                string ResponseBody = await response.Content.ReadAsStringAsync();
                dynamic ParsedBody = JsonConvert.DeserializeObject(ResponseBody);

                return ParsedBody;
            } catch (HttpRequestException e) {
                return $"Error en tu solicitud: {e.Message}";
            }
        }
    }

    public async Task<dynamic> GetPlayerDataByUser(string user, string tag) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v2/account/{user}/{tag}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPlayerDataByPUUID(string puuid) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v2/by-puuid/account/{puuid}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetContent() {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/content?api_key={ApiKey}");
    }

    public async Task GetCrosshair(string crosshairId) {
        using (HttpClient Client = new HttpClient()) {
            try {
                n++;
                byte[] ImageBytes = await Client.GetByteArrayAsync($"https://api.henrikdev.xyz/valorant/v1/crosshair/generate?api_key={ApiKey}&id={crosshairId}");
                await File.WriteAllBytesAsync($"crosshair{n}.png", ImageBytes);
                Console.WriteLine("All bytes wrote");
            } catch (HttpRequestException e) {
                Console.WriteLine(e);
            }
        }
    }

    public async Task<dynamic> GetEsportsSchedule(string region, string league) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/esports/schedule?api_key={ApiKey}&region={region}&league={league}");
    }

    public async Task<dynamic> GetLeaderboardByUser(string name, string tag, string platform, string region, string season) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v3/leaderboard/{region}/{platform}?api_key={ApiKey}&name={name}&tag={tag}&session_short={season}");
    }

    public async Task<dynamic> GetLeaderboardByPUUID(string puuid, string platform, string region, string season) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v3/leaderboard/{region}/{platform}?api_key={ApiKey}&puuid={puuid}&session_short={season}");
    }

    public async Task<dynamic> GetMatchHistoryByUser(string name, string tag, string platform, string region, string? mode, string? map, int? size) {
        if (mode == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}&map={map}&size={size}");
        } else if (map == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}&mode={mode}&size={size}");
        } else if (size == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}&mode={mode}&map={map}");
        } else if (mode == null && map == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}&size={size}");  
        } else if (mode == null && size == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}&map={map}");
        } else if (map == null && size == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}&mode={mode}");
        } else {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/matches/{region}/{platform}/{name}/{tag}?api_key={ApiKey}");
        }
    }

    public async Task<dynamic> GetMatchHistoryByPUUID(string puuid, string platform, string region, string? mode, string? map, int? size) {
        if (mode == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}&map={map}&size={size}");
        } else if (map == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}&mode={mode}&size={size}");
        } else if (size == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}&mode={mode}&map={map}");
        } else if (mode == null && map == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}&size={size}");  
        } else if (mode == null && size == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}&map={map}");
        } else if (map == null && size == null) {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}&mode={mode}");
        } else {
            return await GetRequest($"https://api.henrikdev.xyz/valorant/v4/by-puuid/matches/{region}/{platform}/{puuid}?api_key={ApiKey}");
        }
    }

    public async Task<dynamic> GetMatchByID(string matchID) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v2/match/{matchID}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetMMRHistoryByUser(string name, string tag, string region) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/mmr-history/{region}/{name}/{tag}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetMMRHistoryByPUUID(string puuid, string region) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/by-puuid/mmr-history/{region}/{puuid}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetMMRByUser(string name, string tag, string region, string platform) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v3/mmr/{region}/{platform}/{name}/{tag}?api_key={ApiKey}");
    } 

    public async Task<dynamic> GetMMRByPUUID(string puuid, string region, string platform) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v3/by-puuid/mmr/{region}/{platform}/{puuid}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPremierDetailsByTeamName(string team_name, string team_tag) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/{team_name}/{team_tag}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPremierHistoryByTeamName(string team_name, string team_tag) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/{team_name}/{team_tag}/history?api_key{ApiKey}");
    }

    public async Task<dynamic> GetPremierDetailsByTeamID(string team_id) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/{team_id}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPremierHistoryByTeamID(string team_id) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/{team_id}/history?api_key={ApiKey}");
    }

    public async Task<dynamic> GetCurrentPremierTeams() {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/search?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPremierConferences() {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/conferences?api_key={ApiKey}");
    }

    public async Task<dynamic> GetAllPremierSeasons(string region) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/seasons/{region}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPremierLeaderboard(string region) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/leaderboard/{region}?api_key={ApiKey}");
    }

    public async Task<dynamic> GetPemierLeaderboardByConference(string region, string conference) {
        return await GetRequest($"https://api.henrikdev.xyz/valorant/v1/premier/leaderboard/{region}/{conference}?api_key={ApiKey}");
    }
}