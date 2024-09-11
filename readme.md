# An Easy Valorant API for C#, for you! ❤️

### About

- This API is based on [Henrik Dev's Valorant API](https://docs.henrikdev.xyz).
- This API just make the HTTP Requests to the original API endpoints and return their responses, it does not add any new endpoint.
- This API requires an API KEY, you can get one [here](https://discord.gg/X3GaVkX2YN)

### Available endpoints

- ```Evapi.GetPlayerDataByUser``` 

	- [ PARAMS ]: `name: string`, `tag: string`

- ```Evapi.GetPlayerDataByPUUID```

	- [ PARAMS ]: `puuid: string`

- ```Evapi.GetContent```

- ```Evapi.GetCrosshair```

	- [ PARAMS ]: `crooshairId: string`

- ```Evapi.GetEsportsSchedule```

	- [ PARAMS ]: `region: string`, `league: string`

- ```Evapi.GetLeaderboardByUser```

	- [ PARAMS ]: `name: string`, `tag: string`, `platform: string`, `region: string`, `season: string`

- ```Evapi.GetLeaderboardByPUUID```

	- [ PARAMS ]: `puuid: string`, `platform: string`, `region: string`, `season: string`

- ```Evapi.GetMatchHistoryByUser```

	- [ PARAMS ]: `name: string`, `tag: string`, `platform: string`, `region: string`, `mode?: string`, `map?: string`, `size?: string`

- ```Evapi.GetMatchHistoryByPUUID```

	- [ PARAMS ]: `puuid: string`, `platform: string`, `region: string`, `mode: string`, `map: string`, `size: string`

- ```Evapi.GetMatchByID```

	- [ PARAMS ]: `matchID: string`

- ```Evapi.GetMMRHistoryByUser```

	- [ PARAMS ]: `name: string`, `tag: string`, `region: string`

- ```Evapi.GetMMRHistoryByPUUID```

	- [ PARAMS ]: `puuid: string`, `region: string`

- ```Evapi.GetMMRByUser```

	- [ PARAMS ]: `name: string`, `tag: string`, `region: string`, `platform: string`

- ```Evapi.GetMMRByPUUID```

	- [ PARAMS ]: `puuid: string`, `region: string`, `platform: string`

- ```Evapi.GetPremierDetailsByTeamName```

	- [ PARAMS ]: `team_name: string`, `team_tag: string`

- ```Evapi.GetPremierHistoryByTeamName```

	- [ PARAMS ]: `team_name: string`, `team_tag: string`

- ```Evapi.GetPremierDetailsByTeamID```

	- [ PARAMS ]: `team_id: string`

- ```Evapi.GetPremierHistoryByTeamID```

	- [ PARAMS ]: `team_id: string`

- ```Evapi.GetCurrentPremierTeams```

- ```Evapi.GetPremierConferences```

- ```Evapi.GetAllPremierSeasons```

	- [ PARAMS ]: `region: string`

- ```Evapi.GetPremierLeaderboard```

	- [ PARAMS ]: `region: string`

- ```Evapi.GetPemierLeaderboardByConference```

	- [ PARAMS ]: `region: string`, `conference: string`

- ##### *There will be more soon!*

### Usage Example

```cs
using System;
using System.Threading.Tasks;
using EasyValorantAPI;

class Test {
   static async Task Main(string[] args] {
	
     Evapi Api = new Evapi("ApiKey");

     // Using this method to get User Info by           Name   &   Tag
     dynamic UserInfo = await Api.GetPlayerDataByUser("example", "12AB");
     
     // Printing value of "name" provided by JSON Response
     Console.WriteLine(UserInfo.data.name);
	
   }
}
```

### Notes

- You gotta put all params on the same order they are set here.
- Params with *`?`* in their names are not required.